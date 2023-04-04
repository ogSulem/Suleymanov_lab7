using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Suleymanov_lab7
{
    internal class Cilindr: ICLlable
    {
        protected Point centr { get; set; }
        protected Point point { get; set; }
        protected double h { get; set; }
        
        public Cilindr()
        {
            centr = new Point();
            point = new Point(6, 3);
            h = 5;
        }

        public Cilindr(Point centr, Point point, double h)
        {
            this.centr = centr;
            this.point = point;
            this.h = h;
        }

        public Cilindr(Cilindr other)
        {
            this.centr = other.centr;
            this.point = other.point;
            this.h = other.h;
        }

        public virtual void ReadFromConsole()
        {
            centr.ReadFromConsole();
            point.ReadFromConsole();
            while (true)
            {
                Console.Write("Введите высоту цилиндра = ");
                string inp = Console.ReadLine();
                if (Regex.IsMatch(inp, @"^(\d+((\.|,)\d+)?)$"))
                {
                    inp = Regex.Replace(inp, ".", ",");
                    double height = double.Parse(inp);
                    if (height > 0)
                    {
                        h = height;
                        break;
                    }
                }
            }   
        }

        public virtual void WriteToConsole()
        {
            Console.WriteLine($"Центр окружности: {centr.ToString()}\n" +
                $"Точка на окружности: {point.ToString()}\n" +
                $"Высота цилиндра: {h}\n" +
                $"Радиус основания: {R()}\n" +
                $"Площадь основания: {Sosn()}\n" +
                $"Длина окружности в основании: {P()}\n" +
                $"Объем цилиндра: {V()}\n" +
                $"Площадь боковой поверхности: {Sbok()}");
        }
        
        private double R()
        {
            return Point.Distance(centr, point);
        }
        public virtual double Sosn()
        {

            return Math.PI * (R() * R());
        }
        public virtual double P()
        {
            return 2 * Math.PI * R();
        }

        public double V()
        {
            return Sosn() * h;
        }
        
        public double Sbok()
        {
            return P() * h;
        }
    }
}
