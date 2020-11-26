using System;
using System.Drawing;
using System.Windows.Forms;

namespace Gadget
{
    class Vehicle
    {
        public int WheelCount = 4;
        public virtual string GetInfo()
        {
            return ("Количество колес: " + WheelCount); 
        }
        public virtual Image GetImage()
        {
            return Properties.Resources.mountain;
        }
        public static Random rnd = new Random();
    }
    public enum Bicycle
    {
        mountain, urban, childlike
    }
    class Bike : Vehicle
    {
        public string name = "Велосипед";
        public Bicycle type = Bicycle.mountain;
        public int WheelRadius = 15;
        public override string GetInfo()
        {
            var str = name;
            str += "\n"+base.GetInfo();
            switch (type)
            {
                case Bicycle.mountain:
                    str += "\nТип: Горый";
                    break;
                case Bicycle.urban:
                    str += "\nТип: Городской";
                    break;
                case Bicycle.childlike:
                    str += "\nТип: Детский";
                    break;
            }
            str += "\nРадиус колес: " + WheelRadius;
            return str;
        }
        public override Image GetImage()
        {
            switch (type)
            {
                case Bicycle.mountain:
                    return Properties.Resources.mountain as Bitmap;
                case Bicycle.urban:
                    return Properties.Resources.urban as Bitmap;
                default:
                    return Properties.Resources.childlike as Bitmap;
            }
        }
        public static Bike Generate()
        {
            return new Bike
            {
                WheelCount = rnd.Next(3, 6),
                type = (Bicycle)rnd.Next(3),
                WheelRadius = rnd.Next(10, 20)
            };
        }
    }
    public enum CarType
    {
        Bus, Truck, Suv,Car
    }
    class Car : Vehicle
    {
        public string name = "Автомобиль";
        public CarType type = CarType.Car;
        public int engineVolume = 10;
        public int doorCount = 5;
        public override string GetInfo()
        {
            var str = name;
            str += "\n" + base.GetInfo();
            switch (type)
            {
                case CarType.Bus:
                    str += "\nТип: Автобус";
                    break;
                case CarType.Truck:
                    str += "\nТип: Грузовик";
                    break;
                case CarType.Suv:
                    str += "\nТип: Внедорожник";
                    break;
                case CarType.Car:
                    str += "\nТип: Легковая";
                    break;
            }
            str += "\nКоличество дверей: " + doorCount;
            str += "\nМощность двигателя: " + engineVolume;
            return str;
        }
        public override Image GetImage()
        {
            switch (type)
            {
                case CarType.Bus:
                    return Properties.Resources.Bus as Bitmap;
                case CarType.Truck:
                    return Properties.Resources.Truck as Bitmap;
                case CarType.Suv:
                    return Properties.Resources.Suv as Bitmap;
                default:
                    return Properties.Resources.Car as Bitmap;
            }
        }
        public static Car Generate()
        {
            return new Car
            {
                WheelCount = 4 + rnd.Next() % 6,
                type = (CarType)rnd.Next(4),
                engineVolume = rnd.Next(10, 200),
                doorCount = rnd.Next(3, 6)
            };
        }
    }
    enum EngineType
    {
        piston, turboprop, reactive
    }
    class Jet : Vehicle
    {
        public string name = "Самолет";
        public EngineType type = EngineType.piston;
        public int maxWight = 10;
        public override string GetInfo()
        {
            var str = name;
            str += "\n" + base.GetInfo();
            switch (type)
            {
                case EngineType.piston:
                    str += "\nТип двигателя: Поршневой";
                    break;
                case EngineType.turboprop:
                    str += "\nТип двигателя: Турбовинтовой";
                    break;
                case EngineType.reactive:
                    str += "\nТип двигателя: Реактивный";
                    break;
            }
            str += "\nКоличество дверей: " + maxWight;
            return str;
        }
        public override Image GetImage()
        {
            switch (type)
            {
                case EngineType.piston:
                    return Properties.Resources.piston as Bitmap;
                case EngineType.turboprop:
                    return Properties.Resources.turboprop as Bitmap;
                default:
                    return Properties.Resources.reactive as Bitmap;
            }
        }
        public static Jet Generate()
        {
            return new Jet
            {
                WheelCount = rnd.Next(3, 6),
                type = (EngineType)rnd.Next(3),
                maxWight = rnd.Next(8000, 15000)
            };
        }
    }
}