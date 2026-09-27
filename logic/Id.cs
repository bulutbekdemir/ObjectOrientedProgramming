using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_info.logic
{
    class Id
    {
        public bool IsItId(string id)
        {
            bool err = true;

            if (string.IsNullOrEmpty(id) || id.Length != 11)
                err = false;


            if (!id.All(char.IsDigit))
                err = false;


            if (id[0] == '0')
                err = false;

            return err;
        }

        /// <summary> 
        /// Validation code for Turkish ID
        /// AI generated 
        /// </summary>
        public bool IsItValid(string id)
        {
            int[] d = StrToIntArr(id);
             
            // Calculate 10th digit
            int sumOdd = d[0] + d[2] + d[4] + d[6] + d[8];   // 1st, 3rd, 5th, 7th, 9th digits
            int sumEven = d[1] + d[3] + d[5] + d[7];         // 2nd, 4th, 6th, 8th digits
            int calculatedD10 = ((sumOdd * 7) - sumEven) % 10;

            // Handle potential negative modulus results in C#
            if (calculatedD10 < 0) calculatedD10 += 10;

            // Calculate 11th digit
            int sumFirst10 = 0;
            for (int i = 0; i < 10; i++)
            {
                sumFirst10 += d[i];
            }
            int calculatedD11 = sumFirst10 % 10;

            // Validate both digits match the input
            return d[9] == calculatedD10 && d[10] == calculatedD11;
        }

        private int[] StrToIntArr(string id)
        {
            return id.Select(c => c - '0').ToArray();
        }
    }
}
