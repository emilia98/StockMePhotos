using Microsoft.EntityFrameworkCore;
using StockMePhotos.Data;
using StockMePhotos.Data.Models;
using StockMePhotos.Services.Core.Interfaces;
using StockMePhotos.ViewModels.Category;
using StockMePhotos.ViewModels.Photo;

namespace StockMePhotos.Services.Core
{
    public class PhotoService : IPhotoService
    {
        private readonly StockMePhotosDbContext dbContext;

        public PhotoService(StockMePhotosDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Guid> AddNewPhoto(AddPhotoInputModel inputModel, string userId)
        {
            Photo photoEntity = new Photo()
            {
                Title = inputModel.Title,
                Slug = inputModel.Title,
                Description = inputModel.Description,
                UserId = userId
            };

            await this.dbContext.Photos.AddAsync(photoEntity);
            await this.dbContext.SaveChangesAsync();
            return photoEntity.Id;
        }

        public async Task<bool> DeletePhotoByIdAsync(string photoId)
        {
            // Get The Photo Entity
            Photo? photoEntity = await this.dbContext
                .Photos
                .FirstOrDefaultAsync(p => p.Id.ToString().ToLower() == photoId.ToLower() && p.IsDeleted == false);

            if (photoEntity == null)
                return false;

            photoEntity.IsDeleted = true;
            this.dbContext.Photos.Update(photoEntity);
            await this.dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<PhotoViewModel>> GetAll()
        {
            return await this.dbContext.Photos
                .AsNoTracking()
                .Where(p => p.IsDeleted == false)
                .Include(p => p.PhotoUpload)
                .Include(p => p.PhotoCategories)
                .OrderBy(p => p.DateAdded)
                .Select(p => new PhotoViewModel
                {
                    Id = p.Id.ToString(),
                    Title = p.Title,
                    ImageURL = p.PhotoUpload.ImageURL,
                    Categories = p.PhotoCategories.Select(c => c.Category.Name)
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<PhotoViewModel>> GetAllPhotosByUserAsync(string userId)
        {
            IEnumerable<PhotoViewModel> photosByUser = await this.dbContext
                .Photos
                .AsNoTracking()
                .Include(p => p.PhotoUpload)
                .Include(p => p.PhotoCategories)
                .Where(p => p.UserId == userId && p.IsDeleted == false)
                .OrderByDescending(p => p.DateAdded)
                .Select(p => new PhotoViewModel
                {
                    Id = p.Id.ToString(),
                    Title = p.Title,
                    ImageURL = p.PhotoUpload.ImageURL,
                    DateAdded = p.DateAdded.ToString("dd/MM/yyyy"),
                    Categories = p.PhotoCategories.Select(c => c.Category.Name)
                })
                .ToListAsync();

            return photosByUser;
        }

        public async Task<PhotoViewModel?> GetById(string id)
        {
            Photo? photoEntity = await this.GetPhotoEntityById(id);

            if (photoEntity != null)
            {
                return new PhotoViewModel
                {
                    Id = photoEntity.Id.ToString(),
                    ImageURL = photoEntity.PhotoUpload?.ImageURL,
                    Title = photoEntity.Title,
                    Categories = photoEntity.PhotoCategories.Select(c => c.Category.Name)
                };
            }

            return null;
        }

        public async Task<PhotoDetailsViewModel?> GetDetails(string id, string? currentUserId)
        {
            Photo? photoEntity = await this.GetPhotoEntityById(id);

            if (photoEntity == null)
            {
                return null;
            }

            PhotoDetailsViewModel viewModel = new PhotoDetailsViewModel
            {
                Id = photoEntity.Id.ToString(),
                Title = photoEntity.Title,
                Description = photoEntity.Description,
                DateAdded = photoEntity.DateAdded.ToString("dd/MM/yyyy"),
                ImageURL = photoEntity!.PhotoUpload?.ImageURL,
                Categories = photoEntity!.PhotoCategories.Select(pc => new CategoryViewModel
                {
                    Id = pc.CategoryId,
                    Name = pc.Category.Name,
                }) ?? new List<CategoryViewModel>(),
                UserName = photoEntity.User?.UserName?.ToLower() ?? "default@user.com",
                CreatorId = photoEntity.UserId,
                IsOwner = photoEntity.UserId == currentUserId,
                IsInFavoriteList = currentUserId != null ? photoEntity.ToFavorites.Any(fp => fp.UserId == currentUserId) : false
            };

            return viewModel;
        }

        public async Task<UpdatePhotoInputModel?> GetEntityToUpdateByIdAsync(string id)
        {
            Photo? photoEntity = await this.GetPhotoEntityById(id);
            if (photoEntity == null)
            {
                return null;
            }

            UpdatePhotoInputModel inputModel = new UpdatePhotoInputModel()
            {
                Id = id,
                Title = photoEntity.Title,
                Description = photoEntity.Description,
                CategoryId = photoEntity.PhotoCategories.FirstOrDefault()!.CategoryId,
                ImageURL = photoEntity.PhotoUpload.ImageURL,
                UserId = photoEntity.UserId
            };

            return inputModel;
        }

        public async Task<bool> UpdatePhotoEntity(string photoId, UpdatePhotoInputModel inputModel)
        {
            Photo? photoEntity = await this.dbContext
                .Photos
                .FirstOrDefaultAsync(p => p.Id.ToString().ToLower() == photoId.ToLower());

            if (photoEntity == null)
                return false;

            photoEntity.Title = inputModel.Title;
            photoEntity.Description = inputModel.Description;
            photoEntity.LastModified = DateTime.UtcNow;

            this.dbContext.Photos.Update(photoEntity);
            await this.dbContext.SaveChangesAsync();
            return true;
        }


        public async Task<string?> GetPhotoOwnerByPhotoIdAsync(string id)
        {
            Photo? photoEntity = await this.dbContext.Photos
                .AsNoTracking()
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id.ToString().ToLower() == id.ToLower() && p.IsDeleted == false);

            return photoEntity?.UserId;
        }

        private async Task<Photo?> GetPhotoEntityById(string id)
        {
            Photo? photoEntity = await this.dbContext.Photos
                .AsNoTracking()
                .Include(p => p.PhotoUpload)
                .Include(p => p.User)
                .Include(p => p.ToFavorites)
                .Include(p => p.PhotoCategories)
                .ThenInclude(pc => pc.Category)
                .FirstOrDefaultAsync(p => p.Id.ToString().ToLower() == id.ToLower() && p.IsDeleted == false);

            return photoEntity;
        }
    }
}
