using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net6OnionArc.Application.Abstractions.Storage
{
    public interface IStorage
    {
        Task<List<(string filename, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files);

        Task DeleteAsync(string pathOrContainer, string fileName);

        List<string> GetFiles (string pathOrContainerName);

        bool HasFile(string pathOrContainerName, string fileName);
    }
}
