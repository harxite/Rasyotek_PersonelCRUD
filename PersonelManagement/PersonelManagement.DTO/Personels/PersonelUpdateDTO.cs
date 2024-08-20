using PersonelManagement.DTO.Debits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelManagement.DTO.Personels
{
    public class PersonelUpdateDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public List<DebitDTO> Debits { get; set; }
        public string University { get; set; }
    }
}
