using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите символ: ");
        char input = Console.ReadKey().KeyChar;
        Console.WriteLine(); 

        char result;

        if ((input >= 'A' && input <= 'Z') || (input >= 'a' && input <= 'z'))
        {
            // заменяем на строчную
            result = char.ToLower(input);
        }
        else
        {
            //не латинская буква заменяем на ?
            result = '?';
        }

        Console.WriteLine($"Результат: {result}");
    }
}
