using BilSimulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilSimulatorNUnit
{
    [TestFixture]
    public class SimulatorNUnitTests
    {
        [SetUp]
        public void setup()
        {
            CarActions.IsTesting = true;
            DriverActions.IsTesting = true;
            Status.IsTesting = true;
        }

        [TestCase(100, 90, 10)]
        [TestCase(50, 40, 10)]
        [TestCase(10, 0, 10)]
        public void TestDrive(int initialFuel, int expectedFuel, int expectedTiredness)
        {
            var car = new Car { Fuel = initialFuel, Direction = "Norrut" };
            var driver = new Driver { Tiredness = 0 };

            CarActions.Drive(car, driver);

            Assert.AreEqual(expectedFuel, car.Fuel);
            Assert.AreEqual(expectedTiredness, driver.Tiredness);
        }

        [TestCase("Norrut", "Västerut")]
        [TestCase("Västerut", "Söderut")]
        [TestCase("Söderut", "Österut")]
        public void TestTurnLeft(string initialDirection, string expectedDirection)
        {
            var car = new Car { Direction = initialDirection };
            var driver = new Driver();

            CarActions.TurnLeft(car, driver);

            Assert.AreEqual(expectedDirection, car.Direction);
        }

        [TestCase("Norrut", "Österut")]
        [TestCase("Österut", "Söderut")]
        [TestCase("Söderut", "Västerut")]
        public void TestTurnRight(string initialDirection, string expectedDirection)
        {
            var car = new Car { Direction = initialDirection };
            var driver = new Driver();

            CarActions.TurnRight(car, driver);

            Assert.AreEqual(expectedDirection, car.Direction);
        }

        
    }
}
