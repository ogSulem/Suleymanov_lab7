using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suleymanov_lab7
{
    class Employee : Person, ICLlable, INalog
    {
        protected double payment;
        protected double premProcent;
        public Employee() : base()
        {
            payment = 30000.0;
            premProcent = 20.4;
        }

        public Employee(string l, string n, DateTime bh, char s, double pay, double prem) : base(l, n, bh, s)
        {
            premProcent = prem;
            payment = pay;
        }

        public Employee(Employee other) : base(other)
        {
            premProcent = other.premProcent;
            payment = other.payment;
        }

        public override void ReadFromConsole()
        {
            base.ReadFromConsole();
            Console.Write("Введите зарплату в месяц/почасовую ставку: ");
            payment = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите процент премии: ");
            premProcent = Convert.ToDouble(Console.ReadLine());
        }

        public override void WriteToConsole()
        {
            base.WriteToConsole();
            Console.WriteLine($"Зарплата в месяц/почасовая ставка: {payment}" +
                $"\nПроцент премии: {premProcent}%" +
                $"\nВ итоге зарплата (с учетом налога):{PayDay()}");
        }

        public virtual double PayDayClear()
        {
            return payment + (payment * (premProcent / 100.0));
        }

        public double Nalog()
        {
            return PayDayClear() * (13.0 / 100);
        }
        public override double PayDay()
        {
            return PayDayClear() - Nalog();
        }
    }
}
