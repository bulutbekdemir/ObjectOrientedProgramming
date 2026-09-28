using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_info.model
{
    public enum Gender
    {
        Male,
        Woman,
        NonBinary
    }

    public class User : Record
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string PhoneNumber { get; private set; }
        public City City { get; private set; }
        public District District { get; private set; }
        public string AddressOther { get; private set; }

        public Gender Gender { get; private set; }

        public User(
            string id,
            string name,
            string surname,
            string phoneNumber,
            Gender gender,
            City city,
            District district,
            string addressOther)
        {
            Id = id;
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Gender = gender;
            City = city;
            District = district;
            AddressOther = addressOther;
        }

        public void ChangeName(string name, string surname)
        {
            Name = name;
            Surname = surname;

            Modified();
        }

        public void ChangeAddress(
            City city,
            District district,
            string addressOther)
        {
            City = city;
            District = district;
            AddressOther = addressOther;

            Modified();
        }
    }
}