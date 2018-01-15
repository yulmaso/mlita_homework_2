using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mlita_homework_2
{
    class Program
    {
        private static int position;
        
        private static string ch;

        private static string letters = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

        private static void Expression()
        {
            Header();
            if (ch[position] == '_')
                Read();
            else
                Error();
            if (ch[position] == '-')
            {
                Read();
                Text();
                EndChecker();
            }
            else
                Error();
        }

        private static void Header()
        {
            UpperCase();
            Text();
            if (ch[position] == ':')
                Read();
            else
                Error();
            if (ch[position] == '|')
                Read();
            else
                Error();
        }

        private static void UpperCase()
        {
            if (letters.ToUpper().Contains(ch[position]))
                Read();
            else
                Error();
        }

        private static void Text()
        {
            if (letters.Contains(ch[position]))
            {
                Read();
                Text();
            }
        }

        private static void EndChecker()
        {
            if (ch[position] == ';')
            {
                Read();
                if (ch[position] == '|')
                    Read();
                else
                    Error();
                if (ch[position] == '_')
                    Read();
                else
                    Error();
                Layer_1();
            }
            else if (ch[position] == '.')
            {
                Read();
                Console.WriteLine("Строка принадлежит грамматике данного языка");
            }
            else
                Error();
        }

        private static void Layer_1()
        {
            if (ch[position] == '-')
            {
                Read();
                Text();
                EndChecker();
            }
            else if (ch[position] == '_')
            {
                Read();
                Layer_2();
            }
            else
                Error();
        }

        private static void Layer_2()
        {
            if (ch[position] == '-')
            {
                Read();
                Text();
                EndChecker();
            }
            else if (ch[position] == '_')
            {
                Read();
                Layer_3();
            }
            else
                Error();
        }

        private static void Layer_3()
        {
            if (ch[position] == '-')
            {
                Read();
                Text();
                EndChecker();
            }
            else
                Error();
        }

        private static void Error()
        {
            Console.WriteLine("Введенное выражение не соответствует грамматике языка");
            Console.WriteLine("Проверим ещё одну строку? Y/n");
            ch = Console.ReadLine();
            if (ch == "Y")
            {
                start();
            }
            else if (ch == "n")
            {
                Environment.Exit(0);
            }
            
        }
        
        //по идее эта функция должна записывать текущие символы в память, но в задании этого не требуется, поэтому она отвечает только за счетчик
        private static void Read()
        {
            position++;
        }
        
        private static void grammaticRules()
        {
            Console.WriteLine("Списки с тремя уровнями вложенности. Выполнил Плотников А.А. группа 6371 \n");
            Console.WriteLine("________________________________________________________________________");
            Console.WriteLine("Пример: (| -перевод строки, _ - пробел)");
            Console.WriteLine("Татам:|_ - там;|_- тама;|__- ма;|__- та;|_- тата;|__- тат;|__-мам.\n");
            Console.WriteLine("Грамматика языка:");
            Console.WriteLine("<выражение> ::= <заголовок> _- <текст><проверка на конец>");
            Console.WriteLine("<заголовок> ::= <большая буква><текст> :|");
            Console.WriteLine("<большая буква> ::= А|…|Я");
            Console.WriteLine("<текст> ::= <буква><текст> | Λ");
            Console.WriteLine("<буква> ::= а| …|я");
            Console.WriteLine("<проверка на конец> ::= ;|_ <уровень_1> | .");
            Console.WriteLine("<уровень_1> ::= - <текст><проверка на конец> | _ <уровень_2>");
            Console.WriteLine("<уровень_2> ::= - <текст><проверка на конец> | _<уровень_3>");
            Console.WriteLine("<уровень_3> ::= - <текст><проверка на конец>");
            Console.WriteLine("________________________________________________________________________\n");
        }

        static void start()
        {
            while (true)
            {
                Console.WriteLine("\nВведите выражение одной строкой:");
                ch = Console.ReadLine();

                position = 0;
                Expression();

                Console.WriteLine("Проверим ещё одну строку? Y/n");
                if ((ch = Console.ReadLine()) != "Y")
                    break;
            }
        
        }

        static void Main(string[] args)
        {
            grammaticRules();
            start();
        }
    }
}
