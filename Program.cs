using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kurs_part1
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Vehicle
    {
        //количество топлива
        //число пассажиров
        //количество груза
        //название модели
        //вид перевозки (водн/воздуш/наземн)

        public void move(double distance)
        {

        }

    }

    public class Car:Vehicle
    {
        //вид перевозки = наземн
        //расположение руля
        //назначение (пасс/груз)


        public new void move(double distance)
        {
            throw new NotImplementedException();
        }
    }

    public class Ferry:Vehicle
    {
        //вид перевозки = водн
        public new void move(double distance)
        {
            throw new NotImplementedException();
        }
    }

    public class Plane:Vehicle
    {
        //вид перевозки = воздуш
        public new void move(double distance)
        {
            throw new NotImplementedException();
        }
    }

    public class Truck:Car
    {
        //назначение = груз
        //вместимость кузова
        public new void move(double distance)
        {
            throw new NotImplementedException();
        }
    }

}


/**
 class Vehicle
    class Car -> Truck
    class Ferry
    class Plane*/