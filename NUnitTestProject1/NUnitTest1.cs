using System;
using NUnit.Framework;
using kurs_part1;
using System.Reflection;

namespace NUnitTestProject1
{
    [TestFixture]
    public class NUnitTest1
    {
        public static Object GetClassField(Object obj, String FieldName)
        {
            var field = obj.GetType().GetField(FieldName, BindingFlags.NonPublic | BindingFlags.Instance);
            return field != null ? field.GetValue(obj) : null;
        }


        [TestCase("Audi;S8;300;2000;2;700;80000;4", "Audi", "S8", 300, 2000, 2, 700, 80000, 4)]
        public void TestConstructorCar(string input, string name, string model, double speed,
            double weight, int seat, double capacity, double price, int wheels)
        {
            Car C = new Car(input);
            Assert.AreEqual(name, C.Name, "Wrong name");
            Assert.AreEqual(model, C.Model, "Wrong model");
            Assert.AreEqual(speed, C.Speed, "Wrong speed");
            Assert.AreEqual(weight, C.Weight, "Wrong weight");
            Assert.AreEqual(seat, C.Seats, "Wrong seat");
            Assert.AreEqual(capacity, C.Capacity, "Wrong capacity");
            Assert.AreEqual(price, C.Price, "Wrong price");
            Assert.AreEqual(wheels, GetClassField(C, "Wheels"), "Wrong wheels");
        }

        [TestCase("Sapsan;Model1;400;40000;400;7000;100000;8", "Sapsan","Model1",400,40000,400,7000,100000,8)]
        public void TestConstructorTrain(string input, string name, string model, double speed,
           double weight, int seat, double capacity, double price, int wagons)
        {
            Train C = new Train(input);
            Assert.AreEqual(name, C.Name, "Wrong name");
            Assert.AreEqual(model, C.Model, "Wrong model");
            Assert.AreEqual(speed, C.Speed, "Wrong speed");
            Assert.AreEqual(weight, C.Weight, "Wrong weight");
            Assert.AreEqual(seat, C.Seats, "Wrong seat");
            Assert.AreEqual(capacity, C.Capacity, "Wrong capacity");
            Assert.AreEqual(price, C.Price, "Wrong price");
            Assert.AreEqual(wagons, GetClassField(C, "Wagons"), "Wrong wagons");
        }
    }
}