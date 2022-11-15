using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net6OnionArc.Application.Abstractions.Storage
{
    public interface IStorageService : IStorage
    {
        public string StorageName { get; set; }
    }
}
