using System;

class StringArray
{
    private string[] data; // Закрытый массив строк

    // Свойство для получения размера массива
    public int Length => data.Length;

    // Конструктор по умолчанию
    public StringArray(int size)
    {
        if (size <= 0)
            throw new ArgumentException("Размер массива должен быть положительным числом.");

        data = new string[size];
    }

    // Конструктор с передачей массива строк
    public StringArray(string[] values)
    {
        if (values == null || values.Length == 0)
            throw new ArgumentException("Массив не может быть пустым.");

        data = new string[values.Length];
        Array.Copy(values, data, values.Length);
    }

    // Индексатор для доступа к элементам массива
    public string this[int index]
    {
        get
        {
            if (index < 0 || index >= Length)
                throw new IndexOutOfRangeException("Индекс выходит за границы массива.");
            return data[index];
        }
        set
        {
            if (index < 0 || index >= Length)
                throw new IndexOutOfRangeException("Индекс выходит за границы массива.");
            data[index] = value;
        }
    }

    // Перегрузка оператора + для поэлементного соединения массивов
    public static StringArray operator +(StringArray arr1, StringArray arr2)
    {
        if (arr1.Length != arr2.Length)
            throw new InvalidOperationException("Массивы должны быть одной длины.");

        string[] result = new string[arr1.Length];
        for (int i = 0; i < arr1.Length; i++)
        {
            result[i] = arr1[i] + arr2[i]; // Поэлементное соединение
        }
        return new StringArray(result);
    }

    // Метод для заполнения массива пользователем
    public void FillFromUser()
    {
        Console.WriteLine($"Введите {Length} строк:");
        for (int i = 0; i < Length; i++)
        {
            Console.Write($"Элемент {i + 1}: ");
            data[i] = Console.ReadLine();
        }
    }

    // Метод для вывода массива
    public void Print()
    {
        Console.WriteLine("Содержимое массива:");
        foreach (string s in data)
        {
            Console.WriteLine(s);
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Ввод размеров массивов
            Console.Write("Введите размер массивов: ");
            int size = int.Parse(Console.ReadLine());

            // Создаем два массива с пользовательским вводом
            StringArray array1 = new StringArray(size);
            StringArray array2 = new StringArray(size);

            Console.WriteLine("\nЗаполнение первого массива:");
            array1.FillFromUser();

            Console.WriteLine("\nЗаполнение второго массива:");
            array2.FillFromUser();

            // Вывод введенных данных
            Console.WriteLine("\nПервый массив:");
            array1.Print();

            Console.WriteLine("\nВторой массив:");
            array2.Print();

            // Соединяем массивы
            StringArray resultArray = array1 + array2;

            Console.WriteLine("\nРезультат поэлементного соединения:");
            resultArray.Print();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
