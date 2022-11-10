using net6OnionArc.Application.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net6OnionArc.Application.Repositories
{
    public interface IFileWriteRepository : IWriteRepository<net6OnionArc.Domain.Entities.File>
    {
    }
}
