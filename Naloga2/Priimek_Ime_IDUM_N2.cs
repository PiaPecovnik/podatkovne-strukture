using System;
using System.Collections.Generic;

namespace naloga2
{
    public class Program
    {
        public static bool jeOperand(char c)
        {
            if (c >= '0' && c <= '9')
                return true;

            return false;
        }

        public static bool jeOperator(char c)
        {
            if (c == '+' || c == '-' || c == '*' || c == '/' || c == '^' || c == '(' || c == ')')
                return true;

            return false;
        }

        public static int prioritetaOperatorja(char c)
        {
            switch (c)
            {
                case '(':
                    return 4;
                case ')':
                    return 4;
                case '^':
                    return 3;
                case '*':
                    return 2;
                case '/':
                    return 2;
                case '+':
                    return 1;
                case '-':
                    return 1;

                default:
                    return -1;
            }
        }

        public static Queue<char> pretvori_niz_v_vrsto(string izraz)
        {
            Queue<char> infiksni_izraz = new Queue<char>();

            for (int i = 0; i < izraz.Length; i++)
            {
                char znak = izraz[i];

                if (jeOperand(znak) || jeOperator(znak))    // NE moreš uporabljati: znak == jeOperand
                {
                    infiksni_izraz.Enqueue(znak);
                }
            }

            return infiksni_izraz;
        }

        public static bool imaSkladOperatorZVisjoPrioriteto(Stack<char> pomozni_sklad, char precitaniPodatek)
        {
            foreach (char znak in pomozni_sklad)
            {
                if (prioritetaOperatorja(znak) < prioritetaOperatorja(precitaniPodatek))
                {
                    return false;
                }
            }
            return true;
        }

        public static Queue<char> pretvorba_infiks_v_postfiks(Queue<char> infiksni_izraz)
        {
            Queue<char> postfiksni_izraz = new Queue<char>();
            Stack<char> pomozni_sklad = new Stack<char>();

            while (infiksni_izraz.Count > 0)
            {
                char precitaniPodatek = infiksni_izraz.Dequeue();

                if (precitaniPodatek != ')')
                {
                    if (jeOperand(precitaniPodatek))
                    {
                        postfiksni_izraz.Enqueue(precitaniPodatek);
                    }
                    else
                    {
                        if (precitaniPodatek == '(')
                        {
                            pomozni_sklad.Push(precitaniPodatek);
                        }
                        else
                        {
                            while (pomozni_sklad.Count != 0 && imaSkladOperatorZVisjoPrioriteto(pomozni_sklad, precitaniPodatek) && precitaniPodatek != '(')
                            {
                                char pom_operator = pomozni_sklad.Pop();
                                postfiksni_izraz.Enqueue(pom_operator);
                            }
                            pomozni_sklad.Push(precitaniPodatek);
                        }
                    }
                }
                else
                {
                    char pom_operator = pomozni_sklad.Pop();

                    while (pom_operator != '(')
                    {
                        postfiksni_izraz.Enqueue(pom_operator);
                        pom_operator = pomozni_sklad.Pop();
                    }
                }
            }

            while (pomozni_sklad.Count > 0)
            {
                char pom_operator = pomozni_sklad.Pop();
                postfiksni_izraz.Enqueue(pom_operator);
            }

            return postfiksni_izraz;
        }

        public static double izracunaj_skladovni_stroj(Queue<char> postfiksni_izraz)
        {
            Stack<double> skladovni_stroj = new Stack<double>();

            // TODO

            // na skladu mora ostat samo rezultat
            return (skladovni_stroj.Count != 0) ? skladovni_stroj.Pop() : Int32.MinValue;
        }

        public static double izracunaj_izraz(string izraz)
        {
            // podprogram pretvori_niz_v_vrsto()
            Queue<char> infiksni_izraz = pretvori_niz_v_vrsto(izraz);

            // podprogram pretvorba_infiks_v_postfiks()
            Queue<char> postfiksni_izraz = pretvorba_infiks_v_postfiks(infiksni_izraz);

            // podprogram izracunaj_skladovni_stroj()
            double rezultat = izracunaj_skladovni_stroj(postfiksni_izraz);

            return rezultat;
        }

        public static void Main(string[] args)
        {
            //pretvori niz v vrsto 
            /* string niz = "2 + 5";
             Queue<char> vrsta = pretvori_niz_v_vrsto(niz);
             string pretvorjeno = new string(vrsta.ToArray());
             Console.WriteLine(pretvorjeno);
             */

            //pretvori infiks v postfiks
            Queue<char> primer1 = new Queue<char>();
            foreach (char c in "4*5-8") primer1.Enqueue(c);

            Queue<char> test1 = pretvorba_infiks_v_postfiks(primer1);
            Console.WriteLine("Test 1:");
            Console.WriteLine("Expected: 45*8-");
            Console.WriteLine("Result:   " + new string(test1.ToArray()));
            Console.WriteLine();

            Queue<char> primer2 = new Queue<char>();
            foreach (char c in "8/4+2") primer2.Enqueue(c);

            Queue<char> test2 = pretvorba_infiks_v_postfiks(primer2);
            Console.WriteLine("Test 2:");
            Console.WriteLine("Expected: 84/2+");
            Console.WriteLine("Result:   " + new string(test2.ToArray()));
            Console.WriteLine();

            Queue<char> primer3 = new Queue<char>();
            foreach (char c in "4-2^3+2") primer3.Enqueue(c);

            Queue<char> test3 = pretvorba_infiks_v_postfiks(primer3);
            Console.WriteLine("Test 3:");
            Console.WriteLine("Expected:  423^-2+");
            Console.WriteLine("Result:   " + new string(test3.ToArray()));
            Console.WriteLine();

            Queue<char> primer4 = new Queue<char>();
            foreach (char c in "(3-2)*(2+1)") primer4.Enqueue(c);

            Queue<char> test4 = pretvorba_infiks_v_postfiks(primer4);
            Console.WriteLine("Test 4:");
            Console.WriteLine("Expected:  3 2-21+*");
            Console.WriteLine("Result:   " + new string(test4.ToArray()));
            Console.WriteLine();

            /*
            string[] izrazi = {
                "1+2+3",
                "2-2*2+2",
                "2*6/3-2+2"
            };

            double[] rezultati = {
                6.0,
                0.0,
                4.0
            };

            int N = izrazi.Length;

            for (int i = 0; i < N; i++)
            {
                double rezultat = izracunaj_izraz(izrazi[i]);
                if (rezultati[i] == rezultat)
                    Console.WriteLine("OK");
                else
                    Console.WriteLine("Napačen rezultat za izraz " + izrazi[i] + ": " + rezultat + " (pričakovan rezultat: " + rezultati[i] + ").");
            }
            */
        }
    }
}
