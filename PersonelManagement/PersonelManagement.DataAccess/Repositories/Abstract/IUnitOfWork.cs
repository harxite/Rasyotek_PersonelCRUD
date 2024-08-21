using PersonelManagement.Core.Entities;
using PersonelManagement.DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelManagement.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonelRepository PersonelRepository { get; }
        IDebitRepository DebitRepository { get; }
        Task SaveAsync();
    }
}
