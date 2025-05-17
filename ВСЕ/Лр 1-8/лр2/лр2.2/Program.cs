using System;

class Program
{
    // Функция вычисляет sqrt(x^2 + 1)
    static double Function1(double x)
    {
        return Math.Sqrt(x * x + 1);
    }

    // Функция вычисляет sqrt(x^2 - 1), возвращает NaN, если подкоренное выражение отрицательное
    static double Function2(double x)
    {
        if (x * x - 1 < 0)
            return double.NaN; // Возвращаем NaN если корень отрицательный

        return Math.Sqrt(x * x - 1);
    }

    static void Main()
    {
        // Ввод начального значения x
        Console.Write("Введите начальное значение x: ");
        double xStart = Convert.ToDouble(Console.ReadLine());

        // Ввод конечного значения x
        Console.Write("Введите конечное значение x: ");
        double xEnd = Convert.ToDouble(Console.ReadLine());

        // Ввод шага h
        Console.Write("Введите шаг h: ");
        double h = Convert.ToDouble(Console.ReadLine());

        // Проверка на положительность шага
        if (h <= 0)
        {
            Console.WriteLine("Ошибка: шаг должен быть положительным числом.");
            return;
        }

        // Заголовок таблицы значений
        Console.WriteLine("\nТаблица значений:");
        Console.WriteLine("────────────────────────────────");
        Console.WriteLine("|   x   | f1(x) = sqrt(x^2+1) | f2(x) = sqrt(x^2-1) |");
        Console.WriteLine("────────────────────────────────");

        // Цикл вычисления значений и вывода таблицы
        for (double x = xStart; x <= xEnd; x += h)
        {
            double f1 = Function1(x); // Вычисляем f1(x)
            double f2 = Function2(x); // Вычисляем f2(x)

            // Печатаем строку таблицы
            Console.WriteLine($"| {x,5:F2} | {f1,12:F4}       | {f2,12:F4}       |");
        }

        // Конец таблицы
        Console.WriteLine("────────────────────────────────");
    }
}