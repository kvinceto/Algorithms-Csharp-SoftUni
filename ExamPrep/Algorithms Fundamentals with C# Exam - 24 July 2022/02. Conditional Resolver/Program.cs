using System;
using System.Linq;

namespace _02._Conditional_Resolver
{
    public class Program
    {
        static void Main(string[] args)
        {
            var expression = Console.ReadLine()
                .Split()
                .Select(x => x[0])
                .ToArray();

            Console.WriteLine(ParseExpression(expression, 0));
        }

        private static int ParseExpression(char[] expression, int index)
        {
            if (char.IsDigit(expression[index]))
            {
                return expression[index] - '0';
            }

            if (expression[index] == 't')
            {
                return ParseExpression(expression, index + 2);
            }

            var foundConditions = 0;
            for (int i = index + 2; i < expression.Length; i++)
            {
                var currSymbol = expression[i];
                if (currSymbol == '?')
                {
                    foundConditions += 1;
                }
                else if (currSymbol == ':')
                {
                    foundConditions -= 1;
                    if (foundConditions < 0)
                    {
                        return ParseExpression(expression, i + 1);
                    }
                }
            }

            throw new InvalidOperationException();
        }
    }
}
