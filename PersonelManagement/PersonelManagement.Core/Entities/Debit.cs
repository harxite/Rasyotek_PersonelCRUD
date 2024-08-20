using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PersonelManagement.Core.Entities
{
    public class Debit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PersonelId { get; set; } 

        [JsonIgnore]
        public Personel Personel { get; set; } 
    }
}
