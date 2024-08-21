using AutoMapper;
using PersonelManagement.Core.Entities;
using PersonelManagement.Core.Interfaces;
using PersonelManagement.DTO.Personels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelManagement.Business.Services.Concrete
{
    public class PersonelService : IPersonelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonelService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonelDTO>> GetAllPersonelWithDebitsAsync()
        {
            var personelList = await _unitOfWork.PersonelRepository.GetAllWithDebitsAsync();
            return personelList.Select(personel => _mapper.Map<PersonelDTO>(personel));
        }

        public async Task<PersonelDTO> GetPersonelByIdWithDebitsAsync(int id)
        {
            var personel = await _unitOfWork.PersonelRepository.GetByIdWithDebitsAsync(id);
            return _mapper.Map<PersonelDTO>(personel);
        }

        public async Task<PersonelDTO> AddPersonelAsync(PersonelCreateDTO dto)
        {
            var personel = _mapper.Map<Personel>(dto);

            await _unitOfWork.PersonelRepository.AddAsync(personel);
            await _unitOfWork.SaveAsync();

            var createdPersonel = await _unitOfWork.PersonelRepository.GetByIdAsync(personel.Id);
            var createdPersonelDto = _mapper.Map<PersonelDTO>(createdPersonel);

            return createdPersonelDto;
        }


        public async Task UpdatePersonelAsync(PersonelUpdateDTO dto)
        {
            var existingPersonel = await _unitOfWork.PersonelRepository.GetByIdWithDebitsAsync(dto.Id);
            if (existingPersonel != null)
            {
                existingPersonel.Debits.Clear();

                _mapper.Map(dto, existingPersonel);

                if (dto.Debits != null)
                {
                    foreach (var debitDto in dto.Debits)
                    {
                        var debit = new Debit { Name = debitDto.Name };
                        existingPersonel.Debits.Add(debit);
                    }
                }

                await _unitOfWork.PersonelRepository.UpdateAsync(existingPersonel);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task DeletePersonelAsync(int id)
        {
            await _unitOfWork.PersonelRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }
    }
}
