using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_info.logic
{
    class Name
    {
        public (string Name, string Surname) Parse(string fullName)
        {
            string[] parts = fullName
                .Trim()
                .Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 2)
                return (fullName.Trim(), "");

            int surnameStart = parts.Length - 1;

            while (surnameStart > 0 && IsAllUpper(parts[surnameStart - 1]))
            {
                surnameStart--;
            }

            string name = string.Join(" ", parts.Take(surnameStart));
            string surname = string.Join(" ", parts.Skip(surnameStart));

            return (name, surname);
        }

        private bool IsAllUpper(string word)
        {
            return word.Any(char.IsLetter) &&
                   word.Where(char.IsLetter).All(char.IsUpper);
        }
    }
}
