using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication
{
    static class Util
    {
        private static Random random = new Random();

        private static DateTime currentTime = new DateTime();

        public static int GenerateRandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }
    }
}
