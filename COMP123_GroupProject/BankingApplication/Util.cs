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

        private static DayTime currentTime = new DayTime(1_154_005); // represents 2025-03-22 10:15

        public static DayTime Now
        {
            get
            {
                currentTime += random.Next(100); // increment by 0 to 99 minutes
                return currentTime;
            }
        }
    }
}
