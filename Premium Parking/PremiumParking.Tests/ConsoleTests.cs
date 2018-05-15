﻿using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PremiumParking.ParkingSystemBack;

namespace PremiumParking.Tests
{
    [TestClass]
    public class ConsoleTests
    {
        [TestMethod]
        public void MakeCamerasTest()
        {
            List<Gate> gates = new List<Gate>()
            {
                new Gate(5)
            };
            Console console = new Console();
            List<Camera> cameras = console.MakeCameras(gates);
            Camera camera = new Camera(console, 5);
            Assert.IsTrue(cameras.Contains(camera));
        }

        [TestMethod]
        public void CheckIfNotParkedTest()
        {
            Console console = new Console();
            console.CarIn("AAAA", 444);
            Vehicle vehicle = new Vehicle("AAAA", false);
            Assert.IsTrue(console.CheckIfNotParked(vehicle));
        }

        [TestMethod]
        public void CheckBoxInParkingLotTest()
        {
            Console console = new Console();
            console.CarIn("AAAA", 444);
            Assert.IsTrue(console.CheckBoxInParkingLot("AAAA"));
        }

        [TestMethod]
        public void ParkedTest()
        {
            Console console = new Console();
            Assert.IsNull(console.Parked("AAAA"));
        }

        [TestMethod]
        public void GetVehicleListTest()
        {
            Console console = new Console();
            console.CarIn("AAAA", 444);
            Assert.IsTrue(console.GetVehicleList().Contains(new Vehicle("AAAA", false)));
        }
    }
}
