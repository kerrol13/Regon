using Microsoft.AspNetCore.Http;
using Regon.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Regon.Infrastructure.Storage
{
    public class LocalFileService :ILocalFileService
    {
        public async Task<string> SaveFileAsync(IFormFile file)
        {
            var folder = Path.Combine("wwwroot", "uploads");

            Directory.CreateDirectory(folder);

            var fileName = $"{Guid.NewGuid()} - {file.FileName}";

            var path = Path.Combine(folder, fileName);

            using var stream = new FileStream(path, FileMode.Create);

            await file.CopyToAsync(stream);

            return $"/uploads/{fileName}";
        }
    }
}
