using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using StockMePhotos.GCommon;

namespace StockMePhotos.Services.Common
{
    public class CloudinaryService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(IOptions<CloudinarySettings> config)
        {
            Account acc = new Account(
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
            );
            _cloudinary = new Cloudinary(acc);
        }

        public async Task<string> UploadImageAsync(IFormFile image)
        {
            if (image == null || image.Length == 0)
                throw new Exception("No file selected");

            if (!image.ContentType.StartsWith("image/"))
                throw new Exception("Only image files are allowed");

            await using Stream stream = image.OpenReadStream();

            ImageUploadParams uploadParams = new ImageUploadParams
            {
                File = new FileDescription(image.FileName + $"_{Guid.NewGuid().ToString()}", stream),
                Folder = "stockmephotos"
            };

            ImageUploadResult result = await _cloudinary.UploadAsync(uploadParams);
            return result.SecureUrl.ToString();
        }
    }
}
