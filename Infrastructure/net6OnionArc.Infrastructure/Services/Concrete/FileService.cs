using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using net6OnionArc.Application.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net6OnionArc.Infrastructure.Services.Concrete
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<bool> CopyFile(string path, IFormFile file)
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

        public async Task<string> FileRenameAsync(string fileName)
        {
            return  "";
        }

        public async Task<List<(string filename, string path)>> UploadAsync(string path, IFormFileCollection files)
        {

            string uploadPath = Path.Combine(
               _webHostEnvironment.WebRootPath, path);

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            List<(string filename, string path)> datas = new List<(string filename, string path)>();
            List<bool> results = new List<bool>();
            foreach (IFormFile file in files)
            {
                string fileNewName = await FileRenameAsync(file.FileName);

                var fullPath = Path.Combine($"{uploadPath}\\{fileNewName}");

                bool result = await CopyFile(fullPath, file);

                datas.Add((fileNewName, $"{path}\\{fileNewName}"));
                results.Add(result);

            }

            if (results.TrueForAll(result => result.Equals(true)))
            {
                return datas;
            }

            //TODO: Hata alınan dosyalar ile ilgili hata yönetimi yapılacak

            return null;
        }
    }
}
