using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите x: ");
        double x = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите y: ");
        double y = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите z: ");
        double z = Convert.ToDouble(Console.ReadLine());

        if (x * x + 1 == 0 || 2 * x * x * x + y == 0)
        {
            Console.WriteLine("Ошибка: деление на ноль недопустимо.");
            return;
        }

        double a = Math.Cos(x - Math.PI / 6) / (x * x + 1);
        double b = 1 + z / (2 * x * x * x + y);

        Console.WriteLine($"Результаты вычислений:");
        Console.WriteLine($"a = {a:F4}");
        Console.WriteLine($"b = {b:F4}");
    }
}
