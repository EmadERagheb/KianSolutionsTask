namespace Domain.Models
{
    public class Employee:BaseDomainModel
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string UserName { get; set; }

        public bool Active { get; set; }

    }
}
