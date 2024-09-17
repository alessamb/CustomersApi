using System.ComponentModel.DataAnnotations;

namespace CustomersApi.Dtos
{
    public class CreateCustomerDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Address { get; set; }
       // [RegularExpression("^[a-zA-Z0-9]^")]
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}
