using System;
using System.Collections.Generic;
using System.Linq;

namespace C_Sharp
{
    class mathutils
    {
        public static int factorial(int x)
        {
            int r = 1;
            if (x != 0)
            {
                while (x > 0)
                {
                    r = r * x;
                    x--;
                }
            }
            return r;
        }

        public static double sphereVolume(double r)
        {
            double pi = 3.14159;
            double vol = ((4.0 / 3) * pi) * (r * r * r);
            return vol;

        }

        public static double circleArea(double r)
        {
            double pi = 3.14159;
            double A = pi * (r * r);
            return A;
        }

        public static int reverse(int x)
        {
            int rev = 0, rem;
            while (x != 0)
            {
                rem = x % 10;
                rev = rev * 10 + rem;
                x = x / 10;
            }
            return rev;
        }

        public static int nextPalindrome(int x)
        {
            x++;
            while (x != reverse(x))
            {
                x++;
            }
            return x;
        }

        public static int hexaToDecimal(string number)
        {
            int r = 0, aux = number.Length, aux2 = 0, aux3;
            char c;
            while (aux > 0)
            {
                c = number.ElementAtOrDefault(aux - 1);
                if (c == 'a') { aux3 = 10; }
                if (c == 'b') { aux3 = 11; }
                if (c == 'c') { aux3 = 12; }
                if (c == 'd') { aux3 = 13; }
                if (c == 'e') { aux3 = 14; }
                if (c == 'f') { aux3 = 15; }
                else { aux3 = (int)char.GetNumericValue(number.ElementAtOrDefault(aux - 1)); }
                r = (int)(r + (aux3 * (Math.Pow(16, aux2))));
                aux2++;
                aux--;
            }
            return r;
        }

        public static int binaryToDecimal(int x)
        {
            int counter = 0, aux = 0, sum = 0;
            string binary = x.ToString();
            int[] vector = new int[binary.Length];
            while (aux < binary.Length)
            {
                vector[aux] = (int)char.GetNumericValue(binary.ElementAtOrDefault(aux));
                aux++;
            }
            while (counter < vector.Length)
            {
                sum = (int)(sum + (vector[vector.Length - (counter + 1)] * Math.Pow(2, counter)));
                counter++;
            }
            return sum;
        }

        public static bool isPrime(int x)
        {
            int counter = 2;
            bool check = true;
            while (counter < x)
            {
                if (counter == x) { counter++; }
                else
                {
                    if ((x % counter) == 0)
                    {
                        check = false;
                    }
                    counter++;
                }
            }
            return check;
        }
         
        public static List<int> primeGenerator(int x, int y)
        {
            int z, w;
            List<int> primes = new List<int>();
            while (x <= y)
            {
                z = 2;
                while (z <= x)
                {
                    w = x % z;
                    if (z > Math.Sqrt(x))
                    {
                        primes.Add(x); ;
                        z = x + 1;
                    }
                    else if (w == 0) { z = x + 1; }
                    z++;
                }
                x++;
            }
            return primes;
        }

        public static List<int> divisors(int x)
        {
            int counter = 1;
            List<int> divisors = new List<int>();
            while (counter <= x)
            {
                if (x % counter == 0) { divisors.Add(counter); }
                counter++;
            }
            return divisors;
        }

        public static string opn(string equation)
        {
            int aux = 0;
            char token;
            string rpn = "";
            Stack<char> stack = new Stack<char>();
            while (aux < equation.Length)
            {
                token = equation[aux];
                if (token == '0' || token == '1' || token == '2' || token == '3' || token == '4' || token == '5' || token == '6' || token == '7' || token == '8' || token == '9')
                {
                    while (aux + 1 < equation.Length && (equation[aux + 1] == '0' || equation[aux + 1] == '1' || equation[aux + 1] == '2' || equation[aux + 1] == '3' || equation[aux + 1] == '4' || equation[aux + 1] == '5' || equation[aux + 1] == '6' || equation[aux + 1] == '7' || equation[aux + 1] == '8' || equation[aux + 1] == '9'))
                    {
                        rpn += token;
                        aux++;
                        token = equation[aux];
                    }
                    rpn += token;
                    rpn += ' ';
                }
                else if (token == '(')
                {
                    stack.Push(token);
                }
                else if (token == '+' || token == '-')
                {
                    while (stack.Count > 0 && (stack.Peek() == '*' || stack.Peek() == '/' || stack.Peek() == '^' || stack.Peek() == '+' || stack.Peek() == '-'))
                    {
                        rpn += stack.Pop();
                        rpn += ' ';
                    }
                    stack.Push(token);
                }
                else if (token == '*' || token == '/')
                {
                    while (stack.Count > 0 && (stack.Peek() == '*' || stack.Peek() == '/' || stack.Peek() == '^'))
                    {
                        rpn += stack.Pop();
                        rpn += ' ';
                    }
                    stack.Push(token);
                }
                else if (token == '^')
                {
                    while (stack.Count > 0 && stack.Peek() == '^')
                    {
                        rpn += stack.Pop();
                        rpn += ' ';
                    }
                    stack.Push(token);
                }
                else if (token == ')')
                {
                    while (stack.Count > 0 && stack.Peek() != '(')
                    {
                        rpn += stack.Pop();
                        rpn += ' ';
                    }
                    if (stack.Peek() == '(')
                    {
                        stack.Pop();
                    }
                }
                else if (token == '!')
                {
                    rpn += token;
                    rpn += ' ';

                }
                aux++;
            }
            while (stack.Count > 0)
            {
                rpn += stack.Pop();
                rpn += ' ';
            }

            return rpn.ToString();
        }

        public static double calculate(string equation)
        {
            int aux = 0, i;
            double w, x, y, z = 0, pow = 0;
            char token;
            bool longnumber = false;
            string rpn = "";
            Stack<char> stack = new Stack<char>();
            Stack<double> operands = new Stack<double>();
            while (aux < equation.Length)
            {
                token = equation[aux];
                if (token == '0' || token == '1' || token == '2' || token == '3' || token == '4' || token == '5' || token == '6' || token == '7' || token == '8' || token == '9')
                {
                    while (aux + 1 < equation.Length && (equation[aux + 1] == '0' || equation[aux + 1] == '1' || equation[aux + 1] == '2' || equation[aux + 1] == '3' || equation[aux + 1] == '4' || equation[aux + 1] == '5' || equation[aux + 1] == '6' || equation[aux + 1] == '7' || equation[aux + 1] == '8' || equation[aux + 1] == '9'))
                    {
                        rpn += token;
                        aux++;
                        token = equation[aux];
                    }
                    rpn += token;
                    rpn += '.';
                }
                else if (token == '(')
                {
                    stack.Push(token);
                }
                else if (token == '+' || token == '-')
                {
                    while (stack.Count > 0 && (stack.Peek() == '*' || stack.Peek() == '/' || stack.Peek() == '^' || stack.Peek() == '+' || stack.Peek() == '-'))
                    {
                        rpn += stack.Pop();
                    }
                    stack.Push(token);
                }
                else if (token == '*' || token == '/')
                {
                    while (stack.Count > 0 && (stack.Peek() == '*' || stack.Peek() == '/' || stack.Peek() == '^'))
                    {
                        rpn += stack.Pop();
                    }
                    stack.Push(token);
                }
                else if (token == '^')
                {
                    while (stack.Count > 0 && stack.Peek() == '^')
                    {
                        rpn += stack.Pop();
                    }
                    stack.Push(token);
                }
                else if (token == ')')
                {
                    while (stack.Count > 0 && stack.Peek() != '(')
                    {
                        rpn += stack.Pop();
                    }
                    if (stack.Peek() == '(')
                    {
                        stack.Pop();
                    }
                }
                else if (token == '!')
                {
                    token = rpn[rpn.Length - 2];
                    i = (int)char.GetNumericValue(token);
                    rpn = rpn.Substring(0, rpn.Length - 2);
                    i = factorial(i);
                    rpn += i.ToString();
                    rpn += '.';

                }
                aux++;
            }
            while (stack.Count > 0)
            {
                rpn += stack.Pop();
            }
            aux = 0;
            while (aux < rpn.Length)
            {
                token = rpn[aux];
                if (token == '0' || token == '1' || token == '2' || token == '3' || token == '4' || token == '5' || token == '6' || token == '7' || token == '8' || token == '9')
                {
                    while (aux + 1 < rpn.Length && (rpn[aux + 1] == '0' || rpn[aux + 1] == '1' || rpn[aux + 1] == '2' || rpn[aux + 1] == '3' || rpn[aux + 1] == '4' || rpn[aux + 1] == '5' || rpn[aux + 1] == '6' || rpn[aux + 1] == '7' || rpn[aux + 1] == '8' || rpn[aux + 1] == '9'))
                    {
                        stack.Push(token);
                        aux++;
                        token = rpn[aux];
                        longnumber = true;
                    }
                    if (longnumber)
                    {
                        stack.Push(token);
                        while (stack.Count > 0)
                        {
                            w = (double)(stack.Pop() - '0');
                            z += w * Math.Pow(10, pow);
                            pow++;
                        }
                        operands.Push(z);
                        pow = 0;
                        z = 0;
                        longnumber = false;
                    }
                    else
                    {
                        w = (double)(token - '0');
                        operands.Push(w);
                    }
                }
                else if (token == '+' || token == '-' || token == '/' || token == '*' || token == '^')
                {
                    y = operands.Pop();
                    x = operands.Pop();
                    if (token == '+') { x = x + y; }
                    else if (token == '-') { x = x - y; }
                    else if (token == '/') { x = x / y; }
                    else if (token == '*') { x = x * y; }
                    else if (token == '^') { x = Math.Pow(x, y); }
                    operands.Push(x);
                }
                aux++;
            }
            return operands.Pop();
        }

        public static int daysPerLevel(int totalLevels, double velocity, double progressiveComplexity)
        {
            int hours = 0, aux = 1;
            double finishedLevels = 0;
            while (finishedLevels < totalLevels)
            {
                finishedLevels += velocity;
                hours++;
                if (finishedLevels >= aux)
                {
                    velocity /= 1 + progressiveComplexity;
                    aux++;
                }
            }
            return hours;
        }

        public static double wowExpPerLevel(int level, int targetLevel)
        {
            double exp = 0;
            while (level < targetLevel)
            {
                double diff;
                if (level <= 28) { diff = 0; }
                else if (level == 29) { diff = 1; }
                else if (level == 30) { diff = 3; }
                else if (level == 31) { diff = 6; }
                else
                {
                    if (level >= 59)
                    {
                        diff = 5 * (59 - 30);
                    }
                    else
                    {
                        diff = 5 * (level - 30);
                    }
                }
                double rf;
                if (level >= 11) { rf = (1 - (level - 10) / 100); }
                else if (level >= 28) { rf = 0.82; }
                else if (level >= 60) { rf = 1; }
                else { rf = 1; }


                exp += ((8 * level) + diff) * (45 + (5 * level)) * rf;

                level++;
            }
            return exp;
        }
    }

}
