using PersonelManagement.Core.Entities;
using PersonelManagement.Data.Context;
using PersonelManagement.DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelManagement.DataAccess.Repositories.Concrete
{
    public class PersonelRepository : Repository<Personel>, IPersonelRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonelRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Personel>> GetAllWithDebitsAsync()
        {
            return await _context.Personels
                                 .Include(p => p.Debits) 
                                 .ToListAsync();
        }

        public async Task<Personel> GetByIdWithDebitsAsync(int id)
        {
            return await _context.Personels
                                 .Include(p => p.Debits) 
                                 .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
