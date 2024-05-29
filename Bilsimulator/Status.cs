using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilSimulator
{
    public static class Status
    {
        public static void PrintStatus(Car car, Driver driver)
        {
            Console.WriteLine($"\nStatus:");
            Console.WriteLine($"Riktning: {car.Direction}");
            Console.WriteLine($"Bensin: {car.Fuel}%");
            Console.WriteLine($"Trötthet: {driver.Tiredness}%");
        }
    }
}
