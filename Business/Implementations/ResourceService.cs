using Business.DTOs;
using Business.Interfaces;
using Entities;
using Microsoft.AspNetCore.Hosting;

namespace Business.Implementations
{
    public class ResourceService : IResourceService
    {
        private readonly IWebHostEnvironment _env;

        public ResourceService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<Resource> UploadFile(ResourceRequest request)
        {
            string ad = _env.ContentRootPath;
            string a = Environment.CurrentDirectory;
            string wwwRootPath = a;//_env.WebRootPath;
            string fullPath = Path.Combine(wwwRootPath, request.FolderPath, $"{request.FileName}{request.Extension}");

            string directoryPath = Path.GetDirectoryName(fullPath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            using (var fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
            {
                await request.Stream.CopyToAsync(fileStream);
            }

            return new Resource
            {
                Name = request.FileName,
                Extension = request.Extension,
                Path = request.FolderPath,
                Size =  request.Stream.Length,
                ContentType = request.ContentType,
                Url = string.Empty,
            };
        }

        public async Task<Stream> DownloadFile(string folderPath, string fileName, string extension)
        {
            string fullPath = Path.Combine(folderPath, $"{fileName}{extension}");

            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException("El archivo no existe", fullPath);
            }

            MemoryStream memoryStream = new MemoryStream();
            using (FileStream fileStream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
            {
                await fileStream.CopyToAsync(memoryStream);
            }

            memoryStream.Position = 0;
            return memoryStream;
        }

        public Task DeleteFile(string folderPath, string name, string extension)
        {
            string fullPath = Path.Combine(_env.WebRootPath, folderPath, $"{name}{extension}");

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
            else
            {
                throw new FileNotFoundException("El archivo no existe", fullPath);
            }

            return Task.CompletedTask;
        }
    }
}
