using FluentValidation;
using PersonelManagement.DTO.Personels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelManagement.Business.FluentValidatiors.PersonelValidatiors
{
    public class PersonelCreateValidatior : AbstractValidator<PersonelCreateDTO>
    {
        public PersonelCreateValidatior()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("İsim boş bırakılamaz")
                  .MinimumLength(3).WithMessage("İsim en az 3 karakterden oluşmalıdır")
                  .MaximumLength(50).WithMessage("İsim en fazla 50 karakterden oluşmalıdır");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyisim boş bırakılamaz")
                  .MinimumLength(3).WithMessage("Soyisim en az 3 karakterden oluşmalıdır")
                   .MaximumLength(50).WithMessage("Soyisim en fazla 50 karakterden oluşmalıdır");
            RuleFor(x => x.Gender).NotEmpty().WithMessage("Cinsiyet boş bırakılamaz");
            RuleFor(x => x.University).NotEmpty().WithMessage("Universite boş bırakılamaz");
        }
    }
}
