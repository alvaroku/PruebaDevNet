using Business.DTOs;
using Entities;

namespace Business.Interfaces
{
    public interface IResourceService
    {
        Task<Resource> UploadFile(ResourceRequest request);

        Task<Stream> DownloadFile(string folderPath, string fileName, string extension);

        Task DeleteFile(string folderPath, string name, string extension);
    }
}
