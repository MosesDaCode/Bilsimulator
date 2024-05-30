using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BilSimulator
{
    public class App
    {
        private readonly Car _car;
        private readonly Driver _driver;
        private readonly CarActions _carActions;
        private readonly Status _status;

        public App()
        {
            _car = new Car();
            _driver = new Driver();
            _carActions = new CarActions();
            _status = new Status();
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
                        CarActions.Drive(_car, _driver);
                        break;
                    case "2":
                        CarActions.TurnLeft(_car, _driver);
                        break;
                    case "3":
                        CarActions.TurnRight(_car, _driver);
                        break;
                    case "4":
                        CarActions.Reverse(_car, _driver);
                        break;
                    case "5":
                        _carActions.Refuel(_car, _driver);
                        break;
                    case "6":
                        DriverActions.Rest(_driver);
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
                _status.PrintStatus(_car, _driver);

            }
        }
    }
}
