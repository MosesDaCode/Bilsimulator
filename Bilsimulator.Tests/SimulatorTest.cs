using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BilSimulator.Tests
{
    [TestClass]
    public class SimulatorTest
    {
        private CarActions _carActions;
        private DriverActions _driverActions;

        public SimulatorTest()
        {
            _carActions = new CarActions();
            _driverActions = new DriverActions();
        }


        [TestMethod]
        public void TestTurnLeft()
        {
            var car = new Car { Direction = "Norrut" };
            var driver = new Driver { Tiredness = 0 };

            CarActions.TurnLeft(car, driver);
            Assert.AreEqual("V�sterut", car.Direction);

            CarActions.TurnLeft(car, driver);
            Assert.AreEqual("S�derut", car.Direction);

            CarActions.TurnLeft(car, driver);
            Assert.AreEqual("�sterut", car.Direction);

            CarActions.TurnLeft(car, driver);
            Assert.AreEqual("Norrut", car.Direction);
        }

        [TestMethod]
        public void TestTurnRight()
        {
            var car = new Car { Direction = "Norrut" };
            var driver = new Driver { Tiredness = 0 };

            CarActions.TurnRight(car, driver);
            Assert.AreEqual("�sterut", car.Direction);

            CarActions.TurnRight(car, driver);
            Assert.AreEqual("S�derut", car.Direction);

            CarActions.TurnRight(car, driver);
            Assert.AreEqual("V�sterut", car.Direction);

            CarActions.TurnRight(car, driver);
            Assert.AreEqual("Norrut", car.Direction);
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
                Assert.IsTrue(result.Contains("F�raren b�rjar bli tr�tt och beh�ver ta en rast."));
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
                Assert.IsTrue(result.Contains("F�raren �r extremt tr�tt! Det �r mycket farligt att forts�tta k�ra."));
            }
        }

        [TestMethod]
        public void TestPrintStatus()
        {
            var car = new Car { Direction = "Norrut", Fuel = 50 };
            var driver = new Driver { Tiredness = 20 };

            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                Status.PrintStatus(car, driver);
                var output = sw.ToString();
                Assert.IsTrue(output.Contains("Bilens riktning: Norrut"));
                Assert.IsTrue(output.Contains("Bensin: 50%"));
                Assert.IsTrue(output.Contains("F�rarens tr�tthet: 20%"));
            }
        }
    }
}