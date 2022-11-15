using Microsoft.AspNetCore.Http;
using net6OnionArc.Application.Abstractions.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net6OnionArc.Infrastructure.Services.Concrete.Storage
{
    public class StorageService : IStorageService
    {
        readonly IStorage _storage;

        public StorageService(IStorage storage)
        {
            _storage = storage;
        }

        public string StorageName { get => _storage.GetType().Name; }

        public Task DeleteAsync(string pathOrContainer, string fileName)
       =>_storage.DeleteAsync(pathOrContainer, fileName);

        public List<string> GetFiles(string pathOrContainerName)
        =>_storage.GetFiles(pathOrContainerName);

        public bool HasFile(string pathOrContainerName, string fileName)
        =>_storage.HasFile(pathOrContainerName, fileName);  

        public Task<List<(string filename, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files)
       => _storage.UploadAsync(pathOrContainerName, files);   
    }
}
