using AutoMapper;
using PersonelManagement.Core.Entities;
using PersonelManagement.DTO.Debits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelManagement.Business.Profiles
{
    public class DebitProfile : Profile
    {
        public DebitProfile() {

            CreateMap<Debit, DebitDTO>();

            CreateMap<DebitDTO, Debit>()
              .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
