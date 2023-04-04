using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suleymanov_lab7
{
    class Employee2 : Employee, ICLlable
    {
        protected int hours;
        public Employee2() : base()
        {
            hours = 168;
        }

        public Employee2(string l, string n, DateTime bh, char s, double pay, double prem, int h) : base(l, n, bh, s, pay, prem)
        {
            hours = h;
        }

        public Employee2(Employee2 other) : base(other)
        {
            hours = other.hours;
        }

        public override double PayDayClear()
        {
            return payment * hours + (payment * hours * (premProcent / 100.0));
        }

        public override void ReadFromConsole()
        {
            base.ReadFromConsole();
            Console.Write("Введите количество отработанных часов: ");
            hours = Convert.ToInt32(Console.ReadLine());
        }

        public override void WriteToConsole()
        {
            base.WriteToConsole();
            Console.WriteLine($"Количество отработанных часов: {hours}");
        }
    }
}
