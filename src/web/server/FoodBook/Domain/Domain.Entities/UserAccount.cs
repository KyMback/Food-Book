using System.ComponentModel.DataAnnotations;

namespace FoodBook.Domain.Entities
{
    public class UserAccount : BaseEntity
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string SecurityStamp { get; set; }
        
        [Required]
        public string Salt { get; set; }
    }
}