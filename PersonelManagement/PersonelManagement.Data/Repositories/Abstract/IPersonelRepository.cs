﻿using PersonelManagement.Core.Entities;
using PersonelManagement.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelManagement.DataAccess.Repositories.Abstract
{
    public interface IPersonelRepository : IRepository<Personel>
    {
        Task<IEnumerable<Personel>> GetAllWithDebitsAsync();
        Task<Personel> GetByIdWithDebitsAsync(int id);
    }

}
