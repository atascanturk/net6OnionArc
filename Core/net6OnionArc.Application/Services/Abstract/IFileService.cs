﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net6OnionArc.Application.Services.Abstract
{
    public interface IFileService
    {
       Task<List<(string filename, string path)>> UploadAsync(string path, IFormFileCollection files);

       Task<string> FileRenameAsync( string fileName);
       Task<bool> CopyFile(string path, IFormFile file);
    }
}
