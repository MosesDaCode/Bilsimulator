using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilSimulator
{
    public class CarActions
    {
        public static void Drive(Car car, Driver driver)
        {
            if (car.Fuel <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Bensinen är slut! Du måste tanka. Tryck på enter för att fortsätta");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            
            car.Fuel -= 10;
            driver.Tiredness += 10;

            Console.WriteLine($"Bilen kör framåt och är nu riktad {car.Direction}. Tryck på enter för att fortsätta");
            DriverActions.CheckTiredness(driver);
            Console.ReadKey();
        }

        public static void TurnLeft(Car car, Driver driver)
        {
            if (car.Fuel <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Bensinen är slut! Du måste tanka. Tryck på enter för att fortsätta");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            car.Direction = car.Direction switch
            {
                "Norrut" => "Västerut",
                "Västerut" => "Söderut",
                "Söderut" => "Österut",
                "Österut" => "Norrut",
                _ => car.Direction
            };
            car.Fuel -= 5;
            driver.Tiredness += 5;
            Console.WriteLine($"Bilen svänger vänster och är nu riktad {car.Direction}. Tryck på enter för att fortsätta");
            DriverActions.CheckTiredness(driver);
            Console.ReadKey();

        }

        public static void TurnRight(Car car, Driver driver)
        {
            if (car.Fuel <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Bensinen är slut! Du måste tanka. Tryck på enter för att fortsätta");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }
            car.Direction = car.Direction switch
            {
                "Norrut" => "Österut",
                "Österut" => "Söderut",
                "Söderut" => "Västerut",
                "Västerut" => "Norrut",
                _ => car.Direction
            };
            car.Fuel -= 5;
            driver.Tiredness += 5;
            Console.WriteLine($"Bilen svänger höger och är nu riktad {car.Direction}. Tryck på enter för att fortsätta");
            DriverActions.CheckTiredness(driver);
            Console.ReadKey();
        }

        public static void Reverse(Car car, Driver driver)
        {
            if (car.Fuel <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Bensinen är slut! Du måste tanka. Tryck på enter för att fortsätta");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            car.Fuel -= 5;
            driver.Tiredness += 5;

            Console.WriteLine($"Bilen backar och är nu riktad {car.Direction}. Tryck på enter för att fortsätta");
            DriverActions.CheckTiredness(driver);
            Console.ReadKey();

        }

        public void Refuel(Car car, Driver driver)
        {
            car.Fuel = 100;
            driver.Tiredness += 5;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Bilen är nu fulltankad. Tryck på enter för att fortsätta");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
