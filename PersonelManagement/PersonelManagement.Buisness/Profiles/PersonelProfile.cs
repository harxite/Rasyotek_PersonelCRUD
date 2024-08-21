using AutoMapper;
using PersonelManagement.Core.Entities;
using PersonelManagement.DTO.Debits;
using PersonelManagement.DTO.Personels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelManagement.Business.Profiles
{
    public class PersonelProfile : Profile
    {
        public PersonelProfile()
        {
            CreateMap<Personel, PersonelDTO>()
            .ForMember(dest => dest.Debits, opt => opt.MapFrom(src => src.Debits));

            CreateMap<PersonelCreateDTO, Personel>()
                .ForMember(dest => dest.Debits, opt => opt.MapFrom(src =>
                    src.Debits.Select(d => new Debit { Name = d.Name }).ToList()));

            CreateMap<PersonelUpdateDTO, Personel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Debits, opt => opt.Ignore()); 
        }
    }
}

