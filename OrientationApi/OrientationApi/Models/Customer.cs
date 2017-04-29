using System.ComponentModel.DataAnnotations;

namespace OrientationApi.Models
{
    public class Customer
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Key]
        public int CustomerId { get; set; }

    }
}