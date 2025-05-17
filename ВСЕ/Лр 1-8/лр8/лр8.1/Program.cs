using System;

interface Ix
{
    void IxF0(string str);
    void IxF1();
}

interface Iy
{
    void F0(string str);
    void F1();
}

interface Iz
{
    void F0(string str);
    void F1();
}

class TestClass : Ix, Iy, Iz
{
    private string w;

    public TestClass(string value)
    {
        w = value;
    }

    public void IxF0(string str)
    {
        w = str.Length > 2 ? str.Substring(0, str.Length - 2) : "";
        Console.WriteLine($"IxF0: {w}");
    }

    public void IxF1()
    {
        Console.WriteLine($"IxF1: {w}");
    }

    // Неявная реализация Iy (удаление двух первых символов)
    public void F0(string str)
    {
        w = str.Length > 2 ? str.Substring(2) : "";
        Console.WriteLine($"Iy.F0: {w}");
    }

    public void F1()
    {
        Console.WriteLine($"Iy.F1: {w}");
    }

    // Явная реализация Iz (замена первого символа на '-')
    void Iz.F0(string str)
    {
        w = str.Length > 0 ? "-" + str.Substring(1) : "-";
        Console.WriteLine($"Iz.F0: {w}");
    }

    void Iz.F1()
    {
        Console.WriteLine($"Iz.F1: {w}");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введите строку: ");
        string input = Console.ReadLine();

        TestClass obj = new TestClass(input);

        // Демонстрация вызова методов Ix
        Console.WriteLine("\nВызов методов Ix:");
        obj.IxF0(input);
        obj.IxF1();

        // Демонстрация вызова методов Iy (неявная реализация)
        Console.WriteLine("\nВызов методов Iy:");
        obj.F0(input);
        obj.F1();

        // Вызов методов Iz через явное приведение
        Console.WriteLine("\nВызов методов Iz (явное приведение):");
        Iz izRef = obj;
        izRef.F0(input);
        izRef.F1();

        // Вызов метода через интерфейсную ссылку
        Console.WriteLine("\nВызов метода через интерфейсную ссылку:");
        Iy iyRef = obj;
        iyRef.F0(input);
    }
}
