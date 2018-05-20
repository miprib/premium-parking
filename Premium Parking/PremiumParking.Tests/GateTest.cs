using Microsoft.VisualStudio.TestTools.UnitTesting;
using PremiumParking.ParkingSystemBack;

namespace PremiumParking.Tests
{
    [TestClass]
    public class GateTest
    {
        [TestMethod]
        public void StateOnCreate_GateTest()
        {
            Console console = new Console();
            Assert.IsFalse(console.Gates[0].State);
        }

        [TestMethod]
        public void StateChange_GateTest()
        {
            Console console = new Console();
            console.Gates[0].Change();
            Assert.IsTrue(console.Gates[0].State);
        }

        [TestMethod]
        public void StateOpenVehicle_GateTest()
        {
            Console console = new Console();
            console.Gates[0].OpenVehicle("AAA");
            Assert.IsTrue(console.Gates[0].State);
        }

        [TestMethod]
        public void StateDrive_GateTest()
        {
            Console console = new Console();
            console.Gates[0].Drive();
            Assert.IsFalse(console.Gates[0].State);
        }

        [TestMethod]
        public void StateOpenVehicle_Drive_GateTest()
        {
            Console console = new Console();
            console.Gates[0].OpenVehicle("AAA");
            console.Gates[0].Drive();
            Assert.IsFalse(console.Gates[0].State);
        }
        [TestMethod]
        public void OpenGatesForOnCreate_GateTest()
        {
            Console console = new Console();
            Assert.IsTrue(console.Gates[0].OpenGatesFor == null);
        }

        [TestMethod]
        public void OpenGatesForOpenVehicle_GateTest()
        {
            Console console = new Console();
            console.Gates[0].OpenVehicle("AAA");
            Assert.IsTrue(console.Gates[0].OpenGatesFor == "AAA");
        }

        [TestMethod]
        public void OpenGatesForDrive_GateTest()
        {
            Console console = new Console();
            console.Gates[0].Drive();
            Assert.IsTrue(console.Gates[0].OpenGatesFor == null);
        }

        [TestMethod]
        public void OpenGatesForOnVehicle_Drive_GateTest()
        {
            Console console = new Console();
            console.Gates[0].OpenVehicle("AAA");
            console.Gates[0].Drive();
            Assert.IsTrue(console.Gates[0].OpenGatesFor == null);
        }
    }

    [TestClass]
    public class GateSensorTest
    {
        [TestMethod]
        public void StateOnCreate_GateSensorTest()
        {
            Console console = new Console();
            Assert.IsFalse(console.Gates[0].GatesSensor.State);
        }

        [TestMethod]
        public void StateDrive_GateSensorTest()
        {
            Console console = new Console();
            console.Gates[0].GatesSensor.Drive();
            Assert.IsFalse(console.Gates[0].GatesSensor.State);
        }

        [TestMethod]
        public void StateUnderGate_GateSensorTest()
        {
            Console console = new Console();
            console.Gates[0].GatesSensor.UnderGate();
            Assert.IsFalse(console.Gates[0].GatesSensor.State);
        }

        [TestMethod]
        public void StateNotDrive_GateSensorTest()
        {
            Console console = new Console();
            console.Gates[0].GatesSensor.NotDrive();
            Assert.IsFalse(console.Gates[0].GatesSensor.State);
        }

        [TestMethod]
        public void StateUnderGate_Drive_GateSensorTest()
        {
            Console console = new Console();
            console.Gates[0].GatesSensor.UnderGate();
            console.Gates[0].GatesSensor.Drive();
            Assert.IsFalse(console.Gates[0].GatesSensor.State);
        }

        [TestMethod]
        public void StateUnderGate_NotDrive_GateSensorTest()
        {
            Console console = new Console();
            console.Gates[0].GatesSensor.UnderGate();
            console.Gates[0].GatesSensor.NotDrive();
            Assert.IsFalse(console.Gates[0].GatesSensor.State);
        }
    }
}
