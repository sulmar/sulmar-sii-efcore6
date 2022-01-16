using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversions.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public MembershipType MembershipType { get; set; }
        public Coordinate Location { get; set; }

        public Profile Profile { get; set; }

        public DateOnly DateOfBirth { get; set; }
        public TimeOnly WakeupHour { get; set; }

        public bool CanSend { get; set; }

        public override string ToString() => $"{FirstName} {LastName} {MembershipType} {Location} {Profile} {DateOfBirth} {WakeupHour}";

    }

    public class Profile
    {
        public string Theme { get; set; }
        public byte Volume { get; set; }

        public override string ToString() => $"[{Theme}, {Volume}]";
    }

    public class Coordinate
    {
        public Coordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public override string ToString() => $"({Latitude}, {Longitude})";
    }

    public enum MembershipType
    {
        Free,
        Premium
    }
}
