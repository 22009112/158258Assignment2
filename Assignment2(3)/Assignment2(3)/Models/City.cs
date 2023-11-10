using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment2_3_.Models
{
    public class City
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Atrraction> Atrractions { get; set; }
    }
}