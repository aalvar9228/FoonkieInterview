namespace FoonkieInterview.Database.Entities
{
    public class UserEntity : EntityBase
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
    }
}
