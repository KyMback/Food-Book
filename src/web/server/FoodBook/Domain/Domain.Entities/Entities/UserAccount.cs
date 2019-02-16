namespace FoodBook.Domain.Entities.Entities
{
    public class UserAccount: BaseEntity
    {
        public string Email { get; set; }

        public string Login { get; set; }

        public string SecurityStamp { get; set; }
    }
}