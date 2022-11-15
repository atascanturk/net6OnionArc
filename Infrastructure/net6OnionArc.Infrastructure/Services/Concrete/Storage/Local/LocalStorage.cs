using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using net6OnionArc.Application.Abstractions.Storage.Local;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net6OnionArc.Infrastructure.Services.Concrete.Storage.Local
{
    public class LocalStorage : ILocalStorage
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LocalStorage(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task DeleteAsync(string path, string fileName)        
           => File.Delete($"{path}\\{fileName}");
        

        public List<string> GetFiles(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

           return directoryInfo.GetFiles().Select(f=>f.Name).ToList();
        }

        public bool HasFile(string path, string fileName)
        => File.Exists($"{path}\\{fileName}");

        public async Task<List<(string filename, string pathOrContainerName)>> UploadAsync(string path, IFormFileCollection files)
        {
            string uploadPath = Path.Combine(
              _webHostEnvironment.WebRootPath, path);

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            List<(string filename, string path)> datas = new List<(string filename, string path)>();
           
            foreach (IFormFile file in files)
            {
                //string fileNewName = await FileRenameAsync(file.FileName);

                var fullPath = Path.Combine($"{uploadPath}\\{file.Name}");

               await CopyFile(fullPath, file);

                datas.Add((file.Name, $"{path}\\{file.Name}"));               

            }            

            //TODO: Hata alınan dosyalar ile ilgili hata yönetimi yapılacak

            return datas;
        }

        private async Task<bool> CopyFile(string path, IFormFile file)
        {

            try
            {
                using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);

                await file.CopyToAsync(fileStream);

                await fileStream.FlushAsync();

                return true;

            }
            catch (Exception ex)
            {
                //TODO: Logging will be added.
                throw ex;
            }

        }
    }
}
