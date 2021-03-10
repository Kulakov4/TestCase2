using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanNumerals
{
    public enum RomanExCode { DigitIsRepeated, DigitIsInvalid, PreviousDigitIsNotPowerOf10, PreviousDigitIsInvalid, PreviousDigitIsRepeated };

    public class RomanException : Exception
    {
        public RomanExCode Code { get; private set; }
        public RomanException(RomanExCode code, string message)
            : base(message)
        {
            Code = code;
        }
    }

    public class Roman
    {
        static Dictionary<char, int> numerals = new Dictionary<char, int> { 
            { 'I', 1 }, 
            { 'V', 5 }, 
            { 'X', 10 }, 
            { 'L', 50 }, 
            { 'C', 100 }, 
            { 'D', 500 },
            { 'M', 1000 }
        };

        // Является ли чисо степенью 10
        static bool isPowerOf10(int n)
        {
            double logN = Math.Log10(n);
            return logN == Math.Floor(logN);
        }

        static void Check(string s)
        {
            // Цикл по всем элементам словаря с римскими цифрами
            foreach (var p in numerals)
            {
                // Если римская цифра это степень числа 10, то она не может повторяться более 3 раз подряд
                int k = isPowerOf10(p.Value) ? 3 : 1;

                var sub_str = new String(p.Key, k + 1);
                int i = s.IndexOf(sub_str);

                if (i >= 0)
                    throw new RomanException(RomanExCode.DigitIsRepeated, $"Неверная запись числа {s}: цифра {p.Key} повторяется более {k} раз подряд.");
            }

        }

        static public int RomanToInt(string s)
        {
            var stack = new Stack<int>();
            int digit, previous;

            Check(s);

            foreach (var ch in s)
            {
                try
                {
                    // Получаем текущую цифру римского числа
                    digit = numerals[ch];
                }
                catch
                {
                    throw new RomanException(RomanExCode.DigitIsInvalid, $"Цифра {ch} не является допустимой римской цифрой");
                }

                // Если текущая цифра больше предыдущей цифры
                if (stack.Count > 0 && digit > stack.Peek())
                {
                    previous = stack.Peek();

                    if (!isPowerOf10(previous))
                        throw new RomanException(RomanExCode.PreviousDigitIsNotPowerOf10, "Вычитаемая цифра должна быть степенью числа 10.");

                    if ((digit != previous * 5) && (digit != previous * 10))
                        throw new RomanException(RomanExCode.PreviousDigitIsInvalid, "В качестве уменьшаемого могут выступать только ближайшие в числовом ряду к вычитаемой две цифры.");

                    stack.Pop();
                    if ((stack.Count > 0) && (stack.Peek() == previous))
                        throw new RomanException(RomanExCode.PreviousDigitIsRepeated, "Повторение меньшей цифры не допускается.");

                    stack.Push(digit - previous);
                }
                else
                    stack.Push(digit);
            }
            
            return stack.Sum(x => x);
        }
    }
}
