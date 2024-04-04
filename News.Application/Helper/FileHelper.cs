using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace News.Application.Helper
{
    public static class FileHelper
    {
        public static async Task<FileResponse> ToUploadAsync(this IFormFile file, string folder, string? name = "")
        {
            var ext = Path.GetExtension(file.FileName);

            if (string.IsNullOrEmpty(name))
            {
                name = Guid.NewGuid().ToString();
            }
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","images", folder);

            if (!File.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","images", folder, $"{name}");
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return FileResponse.Success($"/files/images/{folder}/{name}");
        }
    }

    public class FileResponse
    {
        public bool IsSuccessed { get; set; }

        public string Url { get; set; }

        public string Error { get; set; }

        public static FileResponse Fail() => new FileResponse() { IsSuccessed = false, Url = string.Empty, Error = string.Empty };

        public static FileResponse NotAllowFileType() => new FileResponse { IsSuccessed = false, Url = string.Empty, Error = "Định dạng file không hợp lệ." };

        public static FileResponse Success(string url) => new FileResponse { IsSuccessed = true, Url = url, Error = string.Empty };
    }
}
