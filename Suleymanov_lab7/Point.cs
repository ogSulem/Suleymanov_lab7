using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Suleymanov_lab7
{
    internal class Point: ICLlable
    {
        protected internal double x { get; set; }
        protected internal double y { get; set; }

        public Point()
        {
            x = 3.0;
            y = 3.0;
        }

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Point(Point other)
        {
            this.x = other.x;
            this.y = other.y;
        } 
        public virtual void ReadFromConsole()
        {
            while (true) 
            {
                Console.Write("Введите x = ");
                string inpX = Console.ReadLine();
                if (Regex.IsMatch(inpX, @"^(\d+((\.|,)\d+)?)$"))
                {
                    inpX = Regex.Replace(inpX, ".", ",");
                    x = double.Parse(inpX);
                    break;
                }
            }
            while (true)
            {
                Console.Write("Введите y = ");
                string inpY = Console.ReadLine();
                if (Regex.IsMatch(inpY, @"^(\d+((\.|,)\d+)?)$"))
                {
                    inpY = Regex.Replace(inpY, ".", ",");
                    y = double.Parse(inpY);
                    break;
                }
            }
        }

        public virtual void WriteToConsole()
        {
            Console.WriteLine($"Точка ({x}, {y})");
        }

        public override string ToString()
        {
            return $"({x}, {y})";
        }

        public double DistanceTo(Point point)
        {
            double differX = Math.Abs(x - point.x);
            double differY = Math.Abs(y - point.y);
            return Math.Sqrt(differX * differX + differY * differY);
        } 
        public static double Distance(Point point1, Point point2)
        {
            double differX = Math.Abs(point1.x - point2.x);
            double differY = Math.Abs(point1.y - point2.y);
            return Math.Sqrt(differX * differX + differY * differY);
        }
    }
}
