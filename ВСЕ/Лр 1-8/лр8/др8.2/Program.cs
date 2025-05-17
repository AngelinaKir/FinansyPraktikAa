using System;
using System.Collections.Generic;

// Класс, представляющий вкладчика
class Depositor : IComparable<Depositor>
{
    private string fullName; // ФИО вкладчика
    private string accountNumber; // Номер счета
    private decimal depositAmount; // Сумма вклада
    private int openYear; // Год открытия счета

    // Конструктор для инициализации всех полей
    public Depositor(string fullName, string accountNumber, decimal depositAmount, int openYear)
    {
        this.fullName = fullName;
        this.accountNumber = accountNumber;
        this.depositAmount = depositAmount;
        this.openYear = openYear;
    }

    // Свойства для получения значений полей
    public string FullName => fullName;
    public string AccountNumber => accountNumber;
    public decimal DepositAmount => depositAmount;
    public int OpenYear => openYear;

    // Реализация интерфейса IComparable для сравнения по сумме вклада
    public int CompareTo(Depositor other)
    {
        return depositAmount.CompareTo(other.depositAmount);
    }

    // Переопределение метода ToString для удобного отображения информации о вкладчике
    public override string ToString()
    {
        return $"{fullName}, Счет: {accountNumber}, Вклад: {depositAmount} руб., Год открытия: {openYear}";
    }
}

// Основной класс программы
class Program
{
    static void Main()
    {
        List<Depositor> depositors = new List<Depositor>(); // Список для хранения вкладчиков

        Console.Write("Введите количество вкладчиков: ");
        int count;
        while (!int.TryParse(Console.ReadLine(), out count) || count <= 0) // Проверка ввода количества вкладчиков
        {
            Console.Write("Ошибка! Введите корректное количество вкладчиков: ");
        }

        for (int i = 0; i < count; i++) // Цикл для ввода данных о каждом вкладчике
        {
            Console.WriteLine($"\nВведите данные для вкладчика {i + 1}:");

            Console.Write("ФИО: ");
            string fullName = Console.ReadLine(); // Ввод ФИО вкладчика

            Console.Write("Номер счета: ");
            string accountNumber = Console.ReadLine(); // Ввод номера счета

            decimal depositAmount;
            Console.Write("Сумма вклада: ");
            while (!decimal.TryParse(Console.ReadLine(), out depositAmount) || depositAmount <= 0) // Проверка суммы вклада
            {
                Console.Write("Ошибка! Введите корректную сумму вклада: ");
            }

            int openYear;
            Console.Write("Год открытия счета: ");
            while (!int.TryParse(Console.ReadLine(), out openYear) || openYear < 1900 || openYear > DateTime.Now.Year) // Проверка года открытия
            {
                Console.Write("Ошибка! Введите корректный год открытия счета: ");
            }

            depositors.Add(new Depositor(fullName, accountNumber, depositAmount, openYear)); // Создание нового вкладчика и добавление в список
        }

        int currentYear = DateTime.Now.Year; // Текущий год
        // Список вкладчиков, открывших счет в текущем году
        List<Depositor> currentYearDepositors = depositors.FindAll(d => d.OpenYear == currentYear);
        currentYearDepositors.Sort(); // Сортировка списка по сумме вклада

        Console.WriteLine("\nВкладчики, открывшие вклад в текущем году (отсортированные по сумме вклада):");
        if (currentYearDepositors.Count == 0) // Проверка на отсутствие таких вкладчиков
        {
            Console.WriteLine("Нет вкладчиков, открывших вклад в текущем году.");
        }
        else
        {
            foreach (var depositor in currentYearDepositors) // Вывод информации о каждом вкладчике
            {
                Console.WriteLine(depositor);
            }
        }
    }
}