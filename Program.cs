using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mlita_homework_2
{
    class Program
    {
        private static int position;

        private static string data;
        
        private static string ch;


        private static void Expression()
        {
            if (ch.Length > 2 && ch[position] == 'Т' && ch[position + 1] == 'а')
            {
                Read(2);
                Text();
            }
            else
                Error();
        }

        private static void Text()
        {
            if (ch[position] == '.')
                dotSymbol();
            else if (position + 1 >= ch.Length)
                Error();
            else
            {
                beginningSymbols();
                afterText();
            }
        }

        private static void beginningSymbols()
        {
            if ((ch[position] == 'т' || ch[position] == 'м') && ch[position + 1] == 'а')
                Read(2);
        }

        private static void afterText()
        {
            if (ch[position] == '.')
                dotSymbol();
            else if (position + 1 >= ch.Length)
                Error();
            else if ((ch[position] == 'т' || ch[position] == 'м') && ch[position + 1] == 'а')
                Text();
            else if (ch[position] == 'т' || ch[position] == 'м')
                endingSymbol();
            else if (ch[position] == ';')
                nextString();
            else
                Error();
        }

        private static void endingSymbol()
        {
            Read(1);
            Text();    
        }

        private static void nextString()
        {
            if (position + 1 >= ch.Length)
                Error();
            else if (ch[position + 1] == '|')
            {
                Read(2);
                Space();
            }
            else
                Error();
        }

        private static void Space()
        {
            if (position >= ch.Length)
                Error();
            else if (ch[position] == '_')
            {
                Read(1);
                afterSpace();
            }
            else
                Error();
        }
        
        private static void afterSpace()
        {
            if (position >= ch.Length)
                Error();
            else if (ch[position] == '_')
                Space();
            else if (position + 1 >= ch.Length)
                Error();
            else if(ch[position] == '-' && ch[position + 1] == ' ')
            {
                Read(2);
                Text();
            }
            else
                Error();
        }

        private static void dotSymbol()
        {
            Read(1);
            Console.WriteLine("Строка принадлежит грамматике данного языка");
        }

        private static void Error()
        {
            Console.WriteLine("Введенное выражение не соответствует грамматике языка");
        }
        
        //по идее эта функция должна записывать текущие символы в память, но в задании этого не требуется, поэтому она отвечает только за счетчик
        private static void Read(int number)
        {
            position += number;
        }
        
        private static void grammaticRules()
        {
            Console.WriteLine("Списки с тремя уровнями вложенности. Выполнил Плотников А.А. группа 6371 \n");
            Console.WriteLine("________________________________________________________________________");
            Console.WriteLine("Пример: (| -перевод строки, _ - пробел)");
            Console.WriteLine("Татам;|_ - там;|_- тама;|__- ма;|__- та;|_- тата;|__- тат;|__-мам.\n");
            Console.WriteLine("Правило ввода:");
            Console.WriteLine("<выражение> ::= 'Та'<текст>");
            Console.WriteLine("<текст> ::= <начальные символы><после текста>");
            Console.WriteLine("<начальные символы> ::= 'та' || 'ма'");
            Console.WriteLine("<после текста> ::= <текст> || <конечный сивол><точка с запятой, перевод строки> || <точка>");
            Console.WriteLine("<конечный символ> ::= 'т' || 'м' || lambda");
            Console.WriteLine("<точка с запятой, перевод строки> ::= ';|'<пробел>");
            Console.WriteLine("<пробел> ::= “_”<после пробела>");
            Console.WriteLine("<после пробела> ::= <пробел> || “- ”<текст>");
            Console.WriteLine("<точка> ::= “.”");
            Console.WriteLine("________________________________________________________________________\n");
        }

        static void Main(string[] args)
        {
            grammaticRules();
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

    }
}
