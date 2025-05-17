using System;

class GeometricProgression
{
    // Закрытые поля для хранения первого члена и знаменателя прогрессии
    private double firstTerm; // Первый член прогрессии
    private double ratio;     // Знаменатель прогрессии

    // Свойства для безопасного доступа и изменения полей
    public double FirstTerm
    {
        get { return firstTerm; } // Получение значения поля
        set { firstTerm = value; } // Установка значения поля
    }

    public double Ratio
    {
        get { return ratio; } // Получение значения знаменателя
        set
        {
            if (value == 0) // Проверка на недопустимое значение (равное 0)
                throw new ArgumentException("Знаменатель прогрессии не может быть равен 0.");
            ratio = value; // Установка значения знаменателя
        }
    }

    // Конструктор по умолчанию, задаёт стандартные значения
    public GeometricProgression()
    {
        firstTerm = 1; // Первый член прогрессии по умолчанию
        ratio = 2;     // Знаменатель прогрессии по умолчанию
    }

    // Конструктор с пользовательскими параметрами
    public GeometricProgression(double firstTerm, double ratio)
    {
        if (ratio == 0) // Проверка на недопустимое значение знаменателя
            throw new ArgumentException("Знаменатель прогрессии не может быть равен 0.");

        this.firstTerm = firstTerm; // Инициализация первого члена
        this.ratio = ratio;         // Инициализация знаменателя
    }

    // Метод вычисления следующего члена прогрессии
    public double NextTerm(int n)
    {
        if (n < 0) // Проверка на отрицательный номер члена
            throw new ArgumentException("Номер члена прогрессии должен быть неотрицательным.");

        return firstTerm * Math.Pow(ratio, n); // Формула n-го члена прогрессии
    }

    // Метод вычисления суммы следующих k членов прогрессии
    public double SumOfNextKTerms(int k)
    {
        if (k <= 0) // Проверка на недопустимое значение количества членов
            throw new ArgumentException("Количество членов суммы должно быть положительным.");

        if (ratio == 1) // Если знаменатель равен 1, сумма - это просто повторение первого члена
            return firstTerm * k;

        // Формула суммы геометрической прогрессии
        return firstTerm * (Math.Pow(ratio, k) - 1) / (ratio - 1);
    }

    // Метод вывода текущего состояния прогрессии
    public void PrintState()
    {
        Console.WriteLine($"Геометрическая прогрессия: a₁ = {firstTerm}, q = {ratio}");
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Создание объекта с параметрами по умолчанию
            GeometricProgression gp1 = new GeometricProgression();
            gp1.PrintState(); // Вывод текущего состояния прогрессии
            Console.WriteLine($"Следующий член (n=3): {gp1.NextTerm(3):F2}"); // Вычисление n-го члена
            Console.WriteLine($"Сумма следующих 4 членов: {gp1.SumOfNextKTerms(4):F2}"); // Вычисление суммы

            Console.WriteLine("\n");

            // Ввод данных от пользователя с обработкой ошибок
            Console.Write("Введите первый член прогрессии: ");
            double firstTerm = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите знаменатель прогрессии: ");
            double ratio = Convert.ToDouble(Console.ReadLine());

            // Создание объекта с пользовательскими параметрами
            GeometricProgression gp2 = new GeometricProgression(firstTerm, ratio);
            gp2.PrintState(); // Вывод состояния прогрессии

            Console.Write("Введите номер следующего члена прогрессии (n): ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Следующий член (n={n}): {gp2.NextTerm(n):F2}"); // Вычисление n-го члена

            Console.Write("Введите количество членов для суммирования (k): ");
            int k = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Сумма следующих {k} членов: {gp2.SumOfNextKTerms(k):F2}"); // Вычисление суммы
        }
        catch (FormatException) // Обработка ошибок ввода
        {
            Console.WriteLine("Ошибка: введено некорректное число.");
        }
        catch (ArgumentException ex) // Обработка ошибок аргументов
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (Exception ex) // Обработка неизвестных ошибок
        {
            Console.WriteLine($"Неизвестная ошибка: {ex.Message}");
        }
    }
}