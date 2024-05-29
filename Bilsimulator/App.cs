using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Bilsimulator
{
    public class App
    {
        private readonly Car car;
        private readonly Driver driver;

        public App()
        {
            car = new Car();
            driver = new Driver();
        }

        public void Run()
        {
            while (true)
            {
                ShowMenu.PrintMenu();
                string command = Console.ReadLine().ToLower();

                switch (command)
                {
                    case "1":
                        CarActions.Drive(car, driver);
                        break;
                    case "2":
                        CarActions.TurnLeft(car, driver);
                        break;
                    case "3":
                        CarActions.TurnRight(car, driver);
                        break;
                    case "4":
                        CarActions.Reverse(car, driver);
                        break;
                    case "5":
                        CarActions.Refuel(car, driver);
                        break;
                    case "6":
                        DriverActions.Rest(driver);
                        break;
                    case "7":
                        Console.WriteLine("Programmet avslutas.");
                        return;
                    default:
                        Console.WriteLine("Ogiltigt kommando. Tryck på enter för att fortsätta");
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
                Status.PrintStatus(car, driver);

            }
        }
    }
}
