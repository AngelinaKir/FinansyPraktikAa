using System;

class Matrix
{
    private int[,] data; // Двумерный массив для хранения элементов матрицы

    // Свойство для получения количества строк
    public int Rows => data.GetLength(0);

    // Свойство для получения количества столбцов
    public int Columns => data.GetLength(1);

    // Конструктор по умолчанию (создаёт матрицу 3x3)
    public Matrix()
    {
        data = new int[3, 3];
    }

    // Конструктор с параметрами (создаёт матрицу указанного размера)
    public Matrix(int rows, int columns)
    {
        if (rows <= 0 || columns <= 0) // Проверяем корректность размеров
            throw new ArgumentException("Размеры матрицы должны быть положительными числами.");

        data = new int[rows, columns]; // Инициализация матрицы
    }

    // Индексатор для доступа к элементам матрицы
    public int this[int row, int col]
    {
        get
        {
            if (row < 0 || row >= Rows || col < 0 || col >= Columns) // Проверка индексов
                throw new IndexOutOfRangeException("Индексы выходят за пределы матрицы.");
            return data[row, col]; // Возвращаем элемент
        }
        set
        {
            if (row < 0 || row >= Rows || col < 0 || col >= Columns) // Проверка индексов
                throw new IndexOutOfRangeException("Индексы выходят за пределы матрицы.");
            data[row, col] = value; // Устанавливаем элемент
        }
    }

    // Метод для вывода всей матрицы на экран
    public void PrintMatrix()
    {
        Console.WriteLine("Матрица:");
        for (int i = 0; i < Rows; i++) // Проходим по строкам
        {
            for (int j = 0; j < Columns; j++) // Проходим по столбцам
            {
                Console.Write($"{data[i, j],4} "); // Вывод элемента с форматированием
            }
            Console.WriteLine(); // Переход на следующую строку
        }
    }

    // Метод для вывода одного элемента матрицы
    public void PrintElement(int row, int col)
    {
        try
        {
            Console.WriteLine($"Элемент ({row}, {col}): {this[row, col]}"); // Вывод указанного элемента
        }
        catch (IndexOutOfRangeException ex) // Обработка выхода за пределы
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    // Метод для подсчёта столбцов, начинающихся с отрицательного числа
    public int CountColumnsWithNegativeStart()
    {
        int count = 0; // Счётчик столбцов
        for (int j = 0; j < Columns; j++) // Проходим по всем столбцам
        {
            if (data[0, j] < 0) // Проверяем первый элемент столбца
                count++;
        }
        return count; // Возвращаем количество подходящих столбцов
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Ввод количества строк и столбцов с клавиатуры
            Console.Write("Введите количество строк: ");
            int rows = int.Parse(Console.ReadLine());

            Console.Write("Введите количество столбцов: ");
            int cols = int.Parse(Console.ReadLine());

            // Создаём матрицу с указанными размерами
            Matrix matrix = new Matrix(rows, cols);

            // Ввод элементов матрицы
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"Введите элемент ({i},{j}): ");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }

            // Вывод всей матрицы
            matrix.PrintMatrix();

            // Проверяем индексатор (получаем элемент)
            Console.Write("\nВведите индекс строки: ");
            int rowIndex = int.Parse(Console.ReadLine());

            Console.Write("Введите индекс столбца: ");
            int colIndex = int.Parse(Console.ReadLine());

            matrix.PrintElement(rowIndex, colIndex); // Вывод указанного элемента

            // Подсчёт столбцов, начинающихся с отрицательного числа
            Console.WriteLine($"Количество столбцов, начинающихся с отрицательного числа: {matrix.CountColumnsWithNegativeStart()}");
        }
        catch (FormatException) // Обработка ошибки ввода
        {
            Console.WriteLine("Ошибка: введено некорректное значение.");
        }
        catch (ArgumentException ex) // Обработка ошибки аргументов
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (Exception ex) // Обработка неизвестных ошибок
        {
            Console.WriteLine($"Неизвестная ошибка: {ex.Message}");
        }
    }
}