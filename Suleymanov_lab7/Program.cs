using Suleymanov_lab7;
//one();
two();

static double sumPayments(Person[] arr)
{
    double sum = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        sum += arr[i].PayDay();
    }
    return sum;
}

static double sumNds(Person[] arr)
{
    double sum = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        sum += arr[i].Nalog();
    }
    return sum;
}

static Person bestEmployee(Person[] arr)
{
    Person bestEmploye = arr[0];
    for (int i = 0; i < arr.Length; i++)
    {
        bestEmploye = (arr[i].PayDay() > bestEmploye.PayDay() ) ? arr[i] : bestEmploye;
    }
    return bestEmploye;
}

void one()
{
    Employee emp1 = new Employee();
    Employee emp2 = new Employee("Suleymanov", "Timur", new DateTime(2004, 6, 30), 'М', 100000.0, 33.3);
    emp1.WriteToConsole();
    Console.WriteLine();
    emp2.WriteToConsole();
    Employee2 emp3 = new Employee2();
    emp3.ReadFromConsole();
    emp3.WriteToConsole();
    Person[] employees = new Person[4];
    for (int i = 0; i < employees.Length; i++)
    {
        employees[i] = (i < 2) ? new Employee() : new Employee2();
        employees[i].ReadFromConsole();
        Console.WriteLine();
    }
    Console.WriteLine($"Общая сумма начисленная работникам: {sumPayments(employees)}");
    Console.WriteLine($"Общая сумма уплаченных налогов: {sumNds(employees)}");
    Console.WriteLine("Работник с наибольшей зарплатой (с учетом налога): ");
    bestEmployee(employees).WriteToConsole();
}

void two()
{
    Employee Ivan = new Employee("Kukin", "Ivan", new DateTime(1950, 4, 1), 'M', 30000, 25);
    Employee Ludmila = new Employee("Kukina", "Ludmila", new DateTime(1965, 5, 1), 'F', 35000, 0);
    Building House = new Building(Ivan, 3000000, "Zayceva, 79");
    Stead stead = new Stead(Ludmila, 500000, 600, false);
    Stead sad = new Stead(Ivan, 300000, 1000, true);
    Horse horse = new Horse(Ivan, 20000, "Ромашка", 2, 7, 250);
    Car car = new Car(Ivan, 10000, "ЗАЗ-965", 5, 27);
    SmallShip ship = new SmallShip(Ivan, 25000, "ship", 4, 2, 15);
    Holding[] holdings = new Holding[] { House, stead, sad, horse, car, ship };
    double totalCost = 0;
    foreach (Holding item in holdings) totalCost += item.Cost;
    double totalNalog = 0;
    INalog[] nalogs = new INalog[] { Ivan, Ludmila, House, stead, sad, car, ship };
    foreach (INalog item in nalogs) totalNalog += item.Nalog();
    Console.WriteLine($"Стоимость всего имуещства семьи = {totalCost}");
    Console.WriteLine($"Сумма налогов семьи: {totalNalog}");
    Console.Write($"До сортировки: ");
    foreach (Holding item in holdings) Console.Write($"{item.Cost} ");
    Array.Sort(holdings);
    Console.Write($"\nПосле сортировки: ");
    foreach (Holding item in holdings) Console.Write($"{item.Cost} ");
}

