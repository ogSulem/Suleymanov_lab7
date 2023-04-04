using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suleymanov_lab7
{
    abstract class Holding : IComparable
    {
        public Person Owner { get; set; }
        public double Cost { get; set; }
        public int CompareTo(object obj)
        {
            Holding h = obj as Holding;
            if (h != null)
            {
                return this.Cost.CompareTo(h.Cost);
            }
            else
            {
                throw new ArgumentException("Object is not a Holding");
            }
        }
    }
    class Stead : Holding, INalog
    {
        public double Area { get; set; }
        private bool IsAgr { get; set; }
        public Stead()
        {
            Owner = new Person("Sayfeeva", "Karina", new DateTime(2005, 1, 25), 'F');
            Cost = 20000000;
            Area = 150;
            IsAgr = false;
        }

        public Stead(Person owner, double cost, double area, bool isagr)
        {
            Owner = owner;
            Cost = cost;
            Area = area;
            IsAgr = isagr;
        }

        public Stead(Stead other)
        {
            this.Owner = other.Owner;
            this.Cost = other.Cost;
            this.Area = other.Area;
            this.IsAgr = other.IsAgr;
        }
        public double Nalog()
        {
            if (IsAgr) return Cost * 0.003;
            return Cost * 0.015;
        }
    }
    class Building : Holding, INalog
    {
        public string Address { get; set; }
        public Building()
        {
            Owner = new Person("Sayfeeva", "Karina", new DateTime(2005, 1, 25), 'F');
            Cost = 20000000;
            Address = "Bari Galeeva 8";
        }

        public Building(Person owner, double cost, string address)
        {
            Owner = owner;
            Cost = cost;
            Address = address;
        }

        public Building(Building other)
        {
            this.Owner = other.Owner;
            this.Cost = other.Cost;
            this.Address = other.Address;
        }
        public double Nalog()
        {
            return Cost * 0.003;
        }
    }
    class Transport : Holding
    {
        public string Name { get; set; }
        public double Capacity { get; set; }
    }
    class SmallShip : Transport, INalog
    {
        public int Paddle { get; set; }
        public double Power { get; set; }
        public SmallShip()
        {
            Owner = new Person("Sayfeeva", "Karina", new DateTime(2005, 1, 25), 'F');
            Cost = 1000000;
            Name = "Freedom";
            Capacity = 6;
            Paddle = 4;
            Power = 200;
        }

        public SmallShip(Person owner, double cost, string name, double capacity, int paddle, double power)
        {
            Owner = owner;
            Cost = cost;
            Name = name;
            Capacity = capacity;
            Paddle = paddle;
            Power = power;
        }

        public SmallShip(SmallShip other)
        {
            this.Owner = other.Owner;
            this.Cost = other.Cost;
            this.Name = other.Name;
            this.Capacity = other.Capacity;
            this.Paddle = other.Paddle;
            this.Power = other.Power;
        }
        public double Nalog()
        {
            if (Power <= 100) return Cost * 0.1;
            else if (Power > 100 && Power <= 300) return Cost * 0.2;
            else return Cost * 2;
        }
    }
    class Horse : Transport
    {
        public int Age { get; set; }
        public double Weight { get; set; }

        public Horse()
        {
            Owner = new Person("Sayfeeva", "Karina", new DateTime(2005, 1, 25), 'F');
            Cost = 300000;
            Name = "Palin";
            Capacity = 2;
            Age = 10;
            Weight = 100;
        }

        public Horse(Person owner, double cost, string name, double capacity, int age, double weight)
        {
            Owner = owner;
            Cost = cost;
            Name = name;
            Capacity = capacity;
            Age = age;
            Weight = weight;
        }

        public Horse(Horse other)
        {
            this.Owner = other.Owner;
            this.Cost = other.Cost;
            this.Name = other.Name;
            this.Capacity = other.Capacity;
            this.Age = other.Age;
            this.Weight = other.Weight;
        }

    }
    class Car : Transport, INalog
    {
        public double Power { get; set; }
        public Car()
        {
            Owner = new Person("Sayfeeva", "Karina", new DateTime(2005, 1, 25), 'F');
            Cost = 20000000;
            Name = "Mersedes";
            Capacity = 7000000;
            Power = 450;
        }
        public Car(Person owner, double cost, string name, double capacity, double power)
        {
            Owner = owner;
            Cost = cost;
            Name = name;
            Capacity = capacity;
            Power = power;
        }

        public Car(Car other)
        {
            this.Owner = other.Owner;
            this.Cost = other.Cost;
            this.Name = other.Name;
            this.Capacity = other.Capacity;
            this.Power = other.Power;
        }
        public double Nalog()
        {
            if (Power <= 100) return Cost * 0.025;
            else if (Power > 100 && Power <= 150) return Cost * 0.035;
            else if (Power > 150 && Power <= 200) return Cost * 0.05;
            else if (Power > 200 && Power <= 250) return Cost * 0.075;
            else if (Power > 250 && Power <= 410) return Cost * 0.15;
            else return Cost * 3;
        }
    }
}
