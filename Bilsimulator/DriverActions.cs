using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilSimulator
{
    public class DriverActions
    {
        public static bool IsTesting = false;
        public static void Rest(Driver driver)
        {
            driver.Tiredness = 0;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Föraren har vilat och är nu pigg. Tryck på enter för att fortsätta");
            Console.ResetColor();
            if (!IsTesting) Console.ReadKey();
        }

        public static void CheckTiredness(Driver driver)
        {
            if (driver.Tiredness >= 100)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Föraren är extremt trött! Det är mycket farligt att fortsätta köra. VILA! Tryck på enter för att fortsätta");
                Console.ResetColor();
            }
            else if (driver.Tiredness >= 70)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Föraren börjar bli trött och behöver ta en rast. Tryck på enter för att fortsätta");
                Console.ResetColor();
            }
        }
    }
}
