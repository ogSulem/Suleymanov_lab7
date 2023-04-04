using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Suleymanov_lab7
{
    internal class SquarePrism : TrianglePrism, ICLlable
    {
        protected Point point3 { get; set; }

        public SquarePrism() : base()
        {
            point3 = new Point(3, 0);
        }

        public SquarePrism(Point centr, Point point, double h, Point point2, Point point3) : base(centr, point, h, point2)
        {
            this.point3 = point3;
        }

        public SquarePrism(SquarePrism other) : base(other)
        {
            this.point3 = other.point3;
        }

        public override void ReadFromConsole()
        {
            centr.ReadFromConsole();
            point.ReadFromConsole();
            point2.ReadFromConsole();
            point3.ReadFromConsole();
            while (true)
            {
                Console.Write("Введите высоту призмы = ");
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

        public override void WriteToConsole()
        {
            Console.WriteLine($"Точка 1 основания: {centr.ToString()}\n" +
                $"Точка 2 основания: {point.ToString()}\n" +
                $"Точка 3 основания: {point2.ToString()}\n" +
                $"Точка 4 основания: {point3.ToString()}\n" +
                $"Высота призмы: {h}\n" +
                $"Площадь основания: {Sosn()}\n" +
                $"Периметр основания: {P()}\n" +
                $"Объем призмы: {V()}\n" +
                $"Площадь боковой поверхности: {Sbok()}");
        }

        public override double P()
        {
            double a = Point.Distance(centr, point);
            double b = Point.Distance(point, point2);
            return (a + b) * 2;
        }

        public override double Sosn()
        {
            double a = Point.Distance(centr, point);
            double b = Point.Distance(point, point2);
            return a * b;
        }

        public string IsParallelepiped()
        {
            string res = "Нет";
            if ((centr.y == point.y) && (point2.y == point3.y)) res = "Да";
            return res;
        }

        public string IsPrParal()
        {
            string res = "Нет";
            double a = Point.Distance(centr, point);
            double b = Point.Distance(point, point2);
            double d = Point.Distance(centr, point2);
            if ((IsParallelepiped() == "Да") && d == (Math.Sqrt(a * a + b * b))) res = "Да";
            return res;
        }

        public string IsCube()
        {
            string res = "Нет";
            double a = Point.Distance(centr, point);
            double b = Point.Distance(point, point2);
            if ((a * b == Sosn()) && h == a) res = "Да";
            return res;
        }
    }
}

