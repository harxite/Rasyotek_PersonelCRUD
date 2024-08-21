using PersonelManagement.Core.Entities;
using PersonelManagement.Core.Interfaces;
using PersonelManagement.Data.Context;
using PersonelManagement.DataAccess.Repositories.Abstract;
using PersonelManagement.DataAccess.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelManagement.DataAccess.Repositories.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IPersonelRepository _personelRepository;
        private IDebitRepository _debitRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IPersonelRepository PersonelRepository
        {
            get { return _personelRepository ??= new PersonelRepository(_context); }
        }

        public IDebitRepository DebitRepository
        {
            get { return _debitRepository ??= new DebitRepository(_context); }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
