using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public static class Logger
    {
        private static List<string> loginEvents = new List<string>();
        private static List<string> transactionEvents= new List<string>();

        public static void LoginHandler(object sender, LoginEventArgs args)
        {
            string logEntry = $"{args.PersonName} - Success:{args.Success}";
            loginEvents.Add(logEntry);
        }
        public static void TransactionHandler(object sender,DesignerTransactionCloseEventArgs args)
        {
            string logEntry = $"{args.PersonName} Amount:{args.Amount} Operation:{args.operation} Success:{args.Success}";
            transactionEvents.Add(logEntry);
        }
        public static void DisplayLoginEvents()
        {
            for(int i=0; 1<loginEvents.Count; i++)
            {
                Console.WriteLine($"Login Events:{i + 1}.{loginEvents[i]}");
            }
        }
        public static void DisplayTransactionEvents()
        {
            for(int i =0; 1<transactionEvents.Count; i++)
            {
                Console.WriteLine($"Transaction Events:{i + 1}.{transactionEvents[i]}");
            }
        }
    }
}
