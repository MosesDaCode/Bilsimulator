using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilSimulator
{
    public class ShowMenu
    {
        public static void PrintMenu()
        {
            Console.WriteLine("\nTillgängliga kommandon:");
            Console.WriteLine("1. Kör framåt");
            Console.WriteLine("2. Sväng vänster");
            Console.WriteLine("3. Sväng höger");
            Console.WriteLine("4. Backa");
            Console.WriteLine("5. Tanka");
            Console.WriteLine("6. Vila");
            Console.WriteLine("7. Avsluta");
            Console.Write("Välj ett kommando: ");
        }
    }
}
