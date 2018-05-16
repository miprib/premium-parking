using Microsoft.VisualStudio.TestTools.UnitTesting;
using PremiumParking.ParkingSystemBack;

namespace PremiumParking.Tests
{
    [TestClass]
    public class ParkingLotTest
    {
        [TestMethod]
        public void GetTotalCountTest()
        {
            ParkingLot parkingLot = ParkingLot.CreateInstace(5, 1, 1, 1, new Console());
            Assert.AreEqual(parkingLot.GetTotalCount(), 5);
        }

        [TestMethod]
        public void IsFreeTest()
        {
            ParkingLot parkingLot = ParkingLot.CreateInstace(5, 1, 1, 1, new Console());
            Assert.IsTrue(parkingLot.IsFree());
        }
    }

    [TestClass]
    public class ParkingSensorTest
    {
        [TestMethod]
        public void CheckIfGoodTest()
        {
            ParkingSensor parkingSensor = new ParkingSensor(ParkingLot.CreateInstace(1, 0, 0, 0, new Console()).ParkingSpaces[0]);
            Assert.IsInstanceOfType(parkingSensor.CheckIfGood(),typeof(bool));
        }
    }
}
