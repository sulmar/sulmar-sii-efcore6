namespace Inheritance.Models
{
    public abstract class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class FullTimeEmployee
    {
        public decimal Salary { get; set; }
    }

    public class Contractor : Employee
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public decimal RatePerHour { get; set; }
    }



}
