using BilSimulator;
using Moq;
using Services.DriverService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BilSimulatorNUnit
{
    [TestFixture]
    public class SimulatorNUnitTests
    {
        private Mock<IDriver> _mockDriver;

        [SetUp]
        public void setup()
        {
            CarActions.IsTesting = true;
            DriverActions.IsTesting = true;
            Status.IsTesting = true;
            _mockDriver = new Mock<IDriver>();
            
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

        [TestCase(0, HungerLevel.Full)]
        [TestCase(3, HungerLevel.Full)]
        [TestCase(5, HungerLevel.Full)]
        [TestCase(6, HungerLevel.Hungry)]
        [TestCase(8, HungerLevel.Hungry)]
        [TestCase(10, HungerLevel.Hungry)]
        [TestCase(11, HungerLevel.Starving)]
        [TestCase(15, HungerLevel.Starving)]
        public void GetHungerLevel_Should_Return_Correct_HungerLevel(int hungerValue, HungerLevel expectedLevel)
        {
            // ARRANGE
            _mockDriver.SetupProperty(d => d.Hunger, hungerValue);
            _mockDriver.Setup(d => d.GetHungerLevel()).Returns(() =>
            {
                if (_mockDriver.Object.Hunger <= 5)
                {
                    return HungerLevel.Full;
                }
                else if (_mockDriver.Object.Hunger <= 10)
                {
                    return HungerLevel.Hungry;
                }
                else
                {
                    return HungerLevel.Starving;
                }
            });

            // ACT
            var actualLevel = _mockDriver.Object.GetHungerLevel();

            // ASSERT
            Assert.AreEqual(expectedLevel, actualLevel);
        }
    }

}
