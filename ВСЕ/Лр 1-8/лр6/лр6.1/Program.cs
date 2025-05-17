using System;

class Поле
{
    private string название;
    private double r; // вес посеянных семян на единицу площади

    // Конструктор с параметрами
    public Поле(string название, double r)
    {
        this.название = название;
        this.r = r;
    }

    public string ПолучитьНазвание() => название;
    public double ПолучитьВесСемян() => r;

    public void УстановитьВесСемян(double новоеR)
    {
        if (новоеR > 0)
            r = новоеR;
        else
            Console.WriteLine("Ошибка: Вес семян должен быть положительным!");
    }

    // Метод вычисления урожая с единицы площади
    public virtual double КоличествоУрожая(double k)
    {
        return k * r;
    }

    // Вывод информации о поле
    public virtual void ВывестиИнформацию()
    {
        Console.WriteLine($"Поле: {название}, Вес семян: {r}");
    }
}

// Производный класс "Картофельное"
class Картофельное : Поле
{
    private double S; 

    public Картофельное(string название, double r, double S) : base(название, r)
    {
        this.S = S;
    }

    // Метод для вычисления урожая со всего поля
    public override double КоличествоУрожая(double k)
    {
        return base.КоличествоУрожая(k) * S;
    }

    // Вывод информации о картофельном поле
    public override void ВывестиИнформацию()
    {
        base.ВывестиИнформацию();
        Console.WriteLine($"Площадь поля: {S}");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введите название поля: ");
        string название = Console.ReadLine();

        Console.Write("Введите вес семян на единицу площади: ");
        double r = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите коэффициент урожайности: ");
        double k = Convert.ToDouble(Console.ReadLine());

        // Создание объекта базового класса
        Поле обычноеПоле = new Поле(название, r);
        обычноеПоле.ВывестиИнформацию();
        Console.WriteLine($"Урожай с единицы площади: {обычноеПоле.КоличествоУрожая(k)}");

        Console.Write("\nВведите площадь картофельного поля: ");
        double S = Convert.ToDouble(Console.ReadLine());

        // Создание объекта производного класса
        Картофельное картофельноеПоле = new Картофельное(название, r, S);
        картофельноеПоле.ВывестиИнформацию();
        Console.WriteLine($"Урожай со всего картофельного поля: {картофельноеПоле.КоличествоУрожая(k)}");
    }
}
