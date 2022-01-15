namespace Migrations.Models
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Pesel { get; set; }

        public decimal Salary { get; set; }

        // public ApplicationUser Owner { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
