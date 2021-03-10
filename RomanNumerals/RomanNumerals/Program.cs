using System;

namespace RomanNumerals
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.Write("Введите число римскими цифрами: ");
                    var s = Console.ReadLine();
                    Console.WriteLine($"{s} = {Roman.RomanToInt(s)}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
