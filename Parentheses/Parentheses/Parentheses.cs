using System;
using System.Collections.Generic;
using System.Text;

namespace Parentheses
{
    public class Parentheses
    {
        // Проверить сбалансированность скобочной структуры в произвольном выражении ((1+3)()(4+(3-5)))
        public static bool isBalanced(string s)
        {
            var brackets = "()[]{}";
            // стек открытых скобок
            var stack = new Stack<char>();


            foreach (var ch in s)
            {
                // ищем символ в скобках
                var i = brackets.IndexOf(ch);
                // если скобка найдена
                if (i >= 0)
                {
                    // проверяем, какая это скобка
                    if (i % 2 == 1)
                    {
                        // если закрывающая скобка, проверяем стек
                        // стек пуст - плохо
                        if (stack.Count == 0) 
                            return false;
                        // извлекаем последнюю открытую скобку из стека
                        var lastBracket = stack.Pop();
                        // если она не соответствует закрывающей скобке - тоже плохо
                        if (lastBracket != brackets[i - 1]) 
                            return false;
                    }
                    else
                    {
                        // открывающую скобку помещаем в стек
                        stack.Push(ch);
                    }
                }
            }
            return stack.Count == 0;
        }
    }
}
