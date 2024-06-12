using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.DriverService;
using System;

namespace BilSimulator.Tests
{
    [TestClass]
    public class SimulatorTest
    {

        private CarActions _carActions;
        private DriverActions _driverActions;
        private Status _status;
        private Mock<IDriver> _mockDriver;

        public SimulatorTest()
        {
            _mockDriver = new Mock<IDriver>();
            _carActions = new CarActions();
            _driverActions = new DriverActions();
            _status = new Status();
        }

        [TestInitialize]
        public void setup()
        {
            CarActions.IsTesting = true;
            DriverActions.IsTesting = true;
            Status.IsTesting = true;

        }

        [TestMethod]
        public void TestTurnLeft()
        {
            var car = new Car { Direction = "Norrut" };
            var driver = new Driver { Tiredness = 0 };

            CarActions.TurnLeft(car, driver);
            Assert.AreEqual("Västerut", car.Direction);

        }

        [TestMethod]
        public void TestTurnRight()
        {
            var car = new Car { Direction = "Norrut" };
            var driver = new Driver { Tiredness = 0 };

            CarActions.TurnRight(car, driver);
            Assert.AreEqual("Österut", car.Direction);
        }

        [TestMethod]
        public void TestDrive()
        {
            var car = new Car { Fuel = 100 };
            var driver = new Driver { Tiredness = 0 };

            CarActions.Drive(car, driver);

            Assert.AreEqual(90, car.Fuel);
            Assert.AreEqual(10, driver.Tiredness);
        }

        [TestMethod]
        public void TestReverse()
        {
            var car = new Car { Fuel = 100 };
            var driver = new Driver { Tiredness = 0 };

            CarActions.Reverse(car, driver);

            Assert.AreEqual(95, car.Fuel);
            Assert.AreEqual(5, driver.Tiredness);
        }

        [TestMethod]
        public void TestRefuel()
        {
            var car = new Car { Fuel = 50 };
            var driver = new Driver { Tiredness = 0 };

            _carActions.Refuel(car, driver);
            Assert.AreEqual(100, car.Fuel);
            Assert.AreEqual(5, driver.Tiredness);
        }

        [TestMethod]
        public void TestRest()
        {
            var driver = new Driver { Tiredness = 50 };
            DriverActions.Rest(driver);
            Assert.AreEqual(0, driver.Tiredness);
        }

        [TestMethod]
        public void TestCheckTiredness_Warning()
        {
            var driver = new Driver { Tiredness = 70 };
            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                DriverActions.CheckTiredness(driver);
                var result = sw.ToString().Trim();
                Assert.IsTrue(result.Contains("Föraren börjar bli trött och behöver ta en rast."));
            }
        }

        [TestMethod]
        public void TestCheckTiredness_Critical()
        {
            var driver = new Driver { Tiredness = 100 };
            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                DriverActions.CheckTiredness(driver);
                var result = sw.ToString().Trim();
                Assert.IsTrue(result.Contains("Föraren är extremt trött! Det är mycket farligt att fortsätta köra."));
            }
        }

        [TestMethod]
        public void IncreaseHunger_Should_Increase_Hunger_By_2()
        {
            // ARRANGE
            _mockDriver.SetupProperty(d => d.Hunger, 10);
            _mockDriver.Setup(d => d.IncreaseHunger()).Callback(() => _mockDriver.Object.Hunger += 2);

            // ACT
            _mockDriver.Object.IncreaseHunger();

            // ASSERT
            Assert.AreEqual(12, _mockDriver.Object.Hunger);
        }

        [TestMethod]
        public void Eat_Should_Reset_Hunger_To_Zero()
        {
            // ARRANGE
            _mockDriver.SetupProperty(d => d.Hunger, 10);
            _mockDriver.Setup(d => d.Eat()).Callback(() => _mockDriver.Object.Hunger = 0);

            // ACT
            _mockDriver.Object.Eat();

            // ASSERT
            Assert.AreEqual(0, _mockDriver.Object.Hunger);
        }

        [TestMethod]
        public void IncreaseHunger_Should_Throw_Exception_If_Hunger_Greater_Than_Or_Equal_To_16()
        {
            // ARRANGE
            _mockDriver.SetupProperty(d => d.Hunger, 14);
            _mockDriver.Setup(d => d.IncreaseHunger()).Callback(() =>
            {
                _mockDriver.Object.Hunger += 2;
                if (_mockDriver.Object.Hunger >= 16)
                {
                    throw new InvalidOperationException("Föraren är för hungrig! Spelet är över.");
                }
            });

            // ACT & ASSERT
            Assert.ThrowsException<InvalidOperationException>(() => _mockDriver.Object.IncreaseHunger());
        }
    }
}
