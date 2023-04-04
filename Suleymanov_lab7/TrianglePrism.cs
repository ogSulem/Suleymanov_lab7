using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Suleymanov_lab7
{
    internal class TrianglePrism : Cilindr, ICLlable
    {
        protected Point point2 { get; set; }

        public TrianglePrism(): base()
        { 
            point2 = new Point(0, 0);
        }

        public TrianglePrism(Point centr, Point point, double h, Point point2) : base(centr, point, h)
        {
            this.point2 = point2;
        }

        public TrianglePrism(TrianglePrism other): base(other)
        {
            this.point2 = other.point2;
        }

        public override void ReadFromConsole()
        {
            centr.ReadFromConsole();
            point.ReadFromConsole();
            point2.ReadFromConsole();
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
                $"Высота призмы: {h}\n" +
                $"Площадь основания: {Sosn()}\n" +
                $"Периметр основания: {P()}\n" +
                $"Объем призмы: {V()}\n" +
                $"Площадь боковой поверхности: {Sbok()}");
        }

        protected double triangleS(double a, double b, double c, double p)
        {
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        public override double P()
        {
            double a = Point.Distance(centr, point);
            double b = Point.Distance(point, point2);
            double c = Point.Distance(point2, centr);
            return a + b + c;
        }

        public override double Sosn()
        {
            return triangleS(Point.Distance(centr, point), Point.Distance(point, point2), Point.Distance(point2, centr), P());
        }
    }
}
