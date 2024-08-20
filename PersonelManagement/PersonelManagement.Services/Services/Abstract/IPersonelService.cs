using PersonelManagement.Core.Entities;
using PersonelManagement.DTO.Personels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelManagement.Core.Interfaces
{
    public interface IPersonelService
    {
        Task<IEnumerable<PersonelDTO>> GetAllPersonelWithDebitsAsync();
        Task<PersonelDTO> GetPersonelByIdWithDebitsAsync(int id);
        Task<PersonelDTO> AddPersonelAsync(PersonelCreateDTO dto);
        Task UpdatePersonelAsync(PersonelUpdateDTO personel);
        Task DeletePersonelAsync(int id);
    }
}


