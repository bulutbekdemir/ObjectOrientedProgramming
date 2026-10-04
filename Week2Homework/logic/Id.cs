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
            if (string.IsNullOrWhiteSpace(id))
                return false;

            if (id.Length != 11)
                return false;

            if (!id.All(char.IsDigit))
                return false;

            if (id[0] == '0')
                return false;

            return true;
        }

        /// <summary> 
        /// Validation code for Turkish ID
        /// AI generated 
        /// </summary>
        public bool IsItValid(string id)
        {
            if (!IsItId(id))
                return false;

            int[] d = StrToIntArr(id);

            int sumOdd =
                d[0] + d[2] + d[4] + d[6] + d[8];

            int sumEven =
                d[1] + d[3] + d[5] + d[7];

            int calculatedD10 =
                ((sumOdd * 7) - sumEven) % 10;

            if (calculatedD10 < 0)
                calculatedD10 += 10;

            int sumFirst10 = 0;

            for (int i = 0; i < 10; i++)
            {
                sumFirst10 += d[i];
            }

            int calculatedD11 =
                sumFirst10 % 10;

            return
                d[9] == calculatedD10 &&
                d[10] == calculatedD11;
        }

        private int[] StrToIntArr(string id)
        {
            return id.Select(c => c - '0').ToArray();
        }
    }
}
