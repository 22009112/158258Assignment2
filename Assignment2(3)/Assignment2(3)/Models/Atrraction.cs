using System.ComponentModel.DataAnnotations;

namespace Assignment2_3_.Models
{
    public class Atrraction
    {
        
            [Key]
            public int ID { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string Address { get; set; }
            public int? CityID { get; set; }
            public virtual City City { get; set; }
        }
    
}