using net6OnionArc.Application.Repositories;
using net6OnionArc.Domain.Entities;
using net6OnionArc.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net6OnionArc.Persistence.Repositories.Concrete
{
    public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(OnionArcDbContext context) : base(context)
        {
        }
    }
}
