using Microsoft.AspNetCore.Http;
using static StockMePhotos.GCommon.ValidationMessages.Image;

namespace StockMePhotos.GCommon
{
    public static class ImageChecker
    {
        private static readonly string[] allowedExtensions =
        {
            ".png", ".jpg", ".jpeg", ".webp", ".gif", ".avif"
        };
        private static int allowedSizeMB = 10;
        private static int allowedMaxSize = allowedSizeMB * 1024 * 1024;

        public static bool IsValidImage(IFormFile? image, out string? error)
        {
            error = null;

            if (image == null || image.Length == 0)
            {
                error = ImageRequired;
                return false;
                // return true;
            }

            if (image.Length > allowedMaxSize)
            {
                error = string.Format(ImageSizeExceeded, allowedSizeMB);
                return false;
            }

            string ext = Path.GetExtension(image!.FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(ext))
            {
                error = string.Format(ImageAllowedExtensions, string.Join(", ", allowedExtensions));
                return false;
            }

            try
            {
                using var stream = image.OpenReadStream();
                if (!IsImageSignatureValid(stream))
                {
                    error = InvalidImage;
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                error = ImageUnreadble;
                return false;
            }

            return true;
        }

        private static bool IsImageSignatureValid(Stream stream)
        {
            Span<byte> header = stackalloc byte[12];
            int bytesRead = stream.Read(header);
            stream.Position = 0;

            if (bytesRead < 12)
                return false;

            // JPEG
            if (header[0] == 0xFF && header[1] == 0xD8) return true;

            /*
            // PNG
            if (header[0] == 0x89 && header[1] == 0x50 && header[2] == 0x4E) return true;

            // GIF
            if (header[0] == 0x47 && header[1] == 0x49 && header[2] == 0x46) return true;

            // WEBP
            if (header[0] == 0x52 && header[1] == 0x49 && header[2] == 0x46 && header[8] == 0x57)
                return true;
            */

            // PNG
            if (header[0] == 0x89 && header[1] == 'P' &&
                header[2] == 'N' && header[3] == 'G')
                return true;

            // GIF
            if (header[0] == 'G' && header[1] == 'I' &&
                header[2] == 'F')
                return true;

            // WEBP
            if (header[0] == 'R' && header[1] == 'I' &&
                header[2] == 'F' && header[3] == 'F' &&
                header[8] == 'W' && header[9] == 'E' &&
                header[10] == 'B' && header[11] == 'P')
                return true;

            // AVIF
            if (header[4] == 'f' && header[5] == 't' &&
                header[6] == 'y' && header[7] == 'p' &&
                header[8] == 'a' && header[9] == 'v' &&
                header[10] == 'i' &&
                (header[11] == 'f' || header[11] == 's'))
            {
                return true;
            }

            return false;
        }
    }
}
