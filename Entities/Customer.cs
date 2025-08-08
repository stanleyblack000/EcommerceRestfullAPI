using System.ComponentModel.DataAnnotations;

namespace EcommerceWebAPI.Entities
{
    public class Customer
    {
       
            public int Id { get; set; }

            [Required]
            [StringLength(40)]
            public required string Name { get; set; }

            [Required]
            [StringLength(40)]
            public required string LastName { get; set; }

    }
}
