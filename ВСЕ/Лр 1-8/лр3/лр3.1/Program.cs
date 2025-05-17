using System;

class GeometricProgression
{
    private double firstTerm; // Первый член прогрессии
    private double ratio;     // Знаменатель прогрессии

    // Свойства для доступа к приватным полям
    public double FirstTerm
    {
        get { return firstTerm; }
        set { firstTerm = value; }
    }

    public double Ratio
    {
        get { return ratio; }
        set { ratio = value; }
    }

    // Конструктор по умолчанию (инициализация стандартных значений)
    public GeometricProgression()
    {
        firstTerm = 1; // Первый член по умолчанию
        ratio = 2;     // Знаменатель по умолчанию
    }

    // Конструктор с параметрами
    public GeometricProgression(double firstTerm, double ratio)
    {
        this.firstTerm = firstTerm; // Инициализация первого члена
        this.ratio = ratio;         // Инициализация знаменателя
    }

    // Метод вычисляет n-ый член прогрессии
    public double NextTerm(int n)
    {
        return firstTerm * Math.Pow(ratio, n); // Формула n-го члена
    }

    // Метод вычисления суммы следующих k членов прогрессии
    public double SumOfNextKTerms(int k)
    {
        if (ratio == 1) // Обработка случая, если знаменатель равен 1
            return firstTerm * k;

        // Формула суммы k членов геометрической прогрессии
        return firstTerm * (Math.Pow(ratio, k) - 1) / (ratio - 1);
    }

    // Метод для вывода текущих параметров прогрессии
    public void PrintState()
    {
        Console.WriteLine($"Геометрическая прогрессия: a₁ = {firstTerm}, q = {ratio}");
    }
}

class Program
{
    static void Main()
    {
        // Создаём объект класса с параметрами по умолчанию
        GeometricProgression gp1 = new GeometricProgression();
        gp1.PrintState(); // Выводим параметры прогрессии
        Console.WriteLine($"Следующий член (n=3): {gp1.NextTerm(3):F2}"); // n-ый член
        Console.WriteLine($"Сумма следующих 4 членов: {gp1.SumOfNextKTerms(4):F2}"); // Сумма членов

        Console.WriteLine("\n");

        // Запрашиваем у пользователя первый член и знаменатель
        Console.Write("Введите первый член прогрессии: ");
        double firstTerm = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите знаменатель прогрессии: ");
        double ratio = Convert.ToDouble(Console.ReadLine());

        // Создаём объект класса с пользовательскими значениями
        GeometricProgression gp2 = new GeometricProgression(firstTerm, ratio);
        gp2.PrintState(); // Выводим параметры прогрессии
        Console.WriteLine($"Следующий член (n=3): {gp2.NextTerm(3):F2}"); // n-ый член
        Console.WriteLine($"Сумма следующих 4 членов: {gp2.SumOfNextKTerms(4):F2}"); // Сумма членов
    }
}