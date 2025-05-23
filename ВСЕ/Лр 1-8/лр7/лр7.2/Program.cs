﻿using System;
using System.Collections.Generic;

// Абстрактный класс, представляющий общий тип автомобиля
abstract class Автомобиль
{
    protected string название; // Поле для хранения названия автомобиля

    public Автомобиль(string название) // Конструктор, инициализирующий название автомобиля
    {
        this.название = название;
    }

    public abstract double РасходТоплива(); // Абстрактный метод для расчета расхода топлива (определяется в подклассах)

    public virtual void ВывестиИнформацию() // Виртуальный метод для вывода информации об автомобиле
    {
        Console.WriteLine($"Автомобиль: {название}");
    }
}

// Класс для грузовых автомобилей, наследующий абстрактный класс Автомобиль
class Грузовой : Автомобиль
{
    private double грузоподъемность; // Поле для хранения грузоподъемности грузового автомобиля

    public Грузовой(string название, double p) : base(название) // Конструктор с вызовом конструктора базового класса
    {
        грузоподъемность = p;
    }

    public override double РасходТоплива() // Реализация расчета расхода топлива для грузовых автомобилей
    {
        return Math.Sqrt(грузоподъемность) * 100;
    }

    public override void ВывестиИнформацию() // Переопределение метода для вывода информации о грузовых автомобилях
    {
        base.ВывестиИнформацию(); // Вызов метода базового класса
        Console.WriteLine($"Тип: Грузовой\nГрузоподъемность: {грузоподъемность} т");
        Console.WriteLine($"Расход топлива на 100 км: {РасходТоплива()} л\n");
    }
}

// Класс для легковых автомобилей, наследующий абстрактный класс Автомобиль
class Легковой : Автомобиль
{
    private double объемДвигателя; // Поле для хранения объема двигателя легкового автомобиля

    public Легковой(string название, double V) : base(название) // Конструктор с вызовом конструктора базового класса
    {
        объемДвигателя = V;
    }

    public override double РасходТоплива() // Реализация расчета расхода топлива для легковых автомобилей
    {
        return 2.5 * объемДвигателя;
    }

    public override void ВывестиИнформацию() // Переопределение метода для вывода информации о легковых автомобилях
    {
        base.ВывестиИнформацию(); // Вызов метода базового класса
        Console.WriteLine($"Тип: Легковой\nОбъем двигателя: {объемДвигателя} л");
        Console.WriteLine($"Расход топлива на 100 км: {РасходТоплива()} л\n");
    }
}

// Основной класс программы для управления вводом данных и отображением результатов
class Program
{
    static void Main()
    {
        List<Автомобиль> автомобили = new List<Автомобиль>(); // Список для хранения экземпляров автомобилей

        Console.Write("Введите количество автомобилей (>=5): ");
        int n;
        while (!int.TryParse(Console.ReadLine(), out n) || n < 5) // Ввод и проверка корректности количества автомобилей
        {
            Console.Write("Ошибка! Введите число >= 5: ");
        }

        for (int i = 0; i < n; i++) // Цикл для ввода данных о каждом автомобиле
        {
            Console.Write("\nВыберите тип автомобиля (1 - Грузовой, 2 - Легковой): ");
            int тип;
            while (!int.TryParse(Console.ReadLine(), out тип) || (тип != 1 && тип != 2)) // Ввод и проверка типа автомобиля
            {
                Console.Write("Ошибка! Введите 1 (Грузовой) или 2 (Легковой): ");
            }

            Console.Write("Введите название автомобиля: ");
            string название = Console.ReadLine(); // Ввод названия автомобиля

            if (тип == 1) // Если выбран грузовой автомобиль
            {
                Console.Write("Введите грузоподъемность (т): ");
                double p;
                while (!double.TryParse(Console.ReadLine(), out p) || p <= 0) // Ввод и проверка грузоподъемности
                {
                    Console.Write("Ошибка! Введите положительное число: ");
                }
                автомобили.Add(new Грузовой(название, p)); // Создание объекта грузового автомобиля и добавление в список
            }
            else // Если выбран легковой автомобиль
            {
                Console.Write("Введите объем двигателя (л): ");
                double v;
                while (!double.TryParse(Console.ReadLine(), out v) || v <= 0) // Ввод и проверка объема двигателя
                {
                    Console.Write("Ошибка! Введите положительное число: ");
                }
                автомобили.Add(new Легковой(название, v)); // Создание объекта легкового автомобиля и добавление в список
            }
        }

        double суммарныйРасход = 0; // Переменная для хранения суммарного расхода топлива
        Console.WriteLine("\n*** Информация обо всех автомобилях ***");
        foreach (var авто in автомобили) // Цикл для вывода информации о каждом автомобиле
        {
            авто.ВывестиИнформацию();
            суммарныйРасход += авто.РасходТоплива(); // Суммирование расхода топлива
        }

        Console.WriteLine($"Суммарный расход топлива на 100 км: {суммарныйРасход} л"); // Вывод суммарного расхода топлива
    }
}