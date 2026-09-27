using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_info.model
{
    public class Student : User
    {
        public int Class { get; private set; }
        public string Number { get; private set; }
        public DateTime Birthday { get; private set; }
        public City BirthCity { get; private set; }
        public District BirthDistrict { get; private set; }

        public Student(
            string id,
            string name,
            string surname,
            string phoneNumber,
            Gender gender,
            City city,
            District district,
            string addressOther,
            int studentClass,
            string number,
            DateTime birthday,
            City birthCity,
            District birthDistrict)
            : base(
                id,
                name,
                surname,
                phoneNumber,
                gender,
                city,
                district,
                addressOther)
        {
            Class = studentClass;
            Number = number;
            Birthday = birthday;
            BirthCity = birthCity;
            BirthDistrict = birthDistrict;
        }

        public void ChangeClass(int newClass)
        {
            Class = newClass;
            Modified();
        }

        public void ChangeNumber(string number)
        {
            Number = number;
            Modified();
        }
    }
}
