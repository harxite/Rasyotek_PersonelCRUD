using PersonelManagement.Core.Entities;
using PersonelManagement.Data.Context;
using PersonelManagement.DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelManagement.DataAccess.Repositories.Concrete
{
    public class DebitRepository : Repository<Debit>, IDebitRepository
    {
        public DebitRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
