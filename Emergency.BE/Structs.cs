using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency.BE
{
    public struct Address
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string NumOfHome { get; set; }
        public Address(string City, string Street, string NumOfHome)
        {
            this.City = string.Copy(City);
            this.Street = string.Copy(Street);
            this.NumOfHome = string.Copy(NumOfHome);
        }
        public Address(Address address)
        {
            this.City = string.Copy(address.City);
            this.Street = string.Copy(address.Street);
            this.NumOfHome = string.Copy(address.NumOfHome);
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", City, Street, NumOfHome);
        }
        public override bool Equals(object obj)
        {
            Address a = (Address)obj;
            return (City.Equals(a.City))&&(Street.Equals(a.Street))&&(NumOfHome.Equals(a.NumOfHome));
        }
    }
    public struct Coordinates
    {

        public Coordinates(double lat, double Long) : this()
        {
            this.Latitude = lat;
            this.Longitude = Long;
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
