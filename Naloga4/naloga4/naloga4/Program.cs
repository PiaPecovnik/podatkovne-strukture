using System;
using System.Collections.Generic;

namespace naloga4
{
    public struct Oseba
    {
        public string Ime;
        public string Priimek;
        public int IDUM;	// 9-mestna unikatna številka
    };

    public class Program
    {
        public static void dobi_prvo_crko(Oseba oseba, ref char prva_crka)
        {
            prva_crka = oseba.Priimek[0];
        }

        public static void dobi_slovar_s_crko(SortedDictionary<char, SortedDictionary<int, Oseba>> slovar, char prva_crka, ref SortedDictionary<int, Oseba> slovar_oseb)
        {
            if (slovar.ContainsKey(prva_crka))
            {
                slovar_oseb = slovar[prva_crka];
            }
            else
            {
                Console.WriteLine("NAPAKA! Vrednost ne obstaja.");
            }
        }

        public static void vstavi_osebo_v_slovar_oseb(ref SortedDictionary<int, Oseba> slovar_oseb, Oseba os)
        {
            slovar_oseb.Add(os.IDUM, os);
        }

        public static void posodobi_slovar_oseb_v_slovarju(ref SortedDictionary<char, SortedDictionary<int, Oseba>> slovar, char prva_crka, SortedDictionary<int, Oseba> slovar_oseb)
        {
            if (slovar.ContainsKey(prva_crka))
            {
                slovar[prva_crka] = slovar_oseb;
            }
        }

        public static void napolni_slovar(Oseba[] seznam, int N, ref SortedDictionary<char, SortedDictionary<int, Oseba>> slovar)
        {

            for (int i = 0; i < N; i++)
            {
                // pridobimo prvo črko
                char prva_crka = new char();
                dobi_prvo_crko(seznam[i], ref prva_crka);
                //Console.WriteLine("PRVA CRKA: " + prva_crka);

                // pridobimo slovar oseb s prvo črko
                SortedDictionary<int, Oseba> slovar_oseb = new SortedDictionary<int, Oseba>();
                dobi_slovar_s_crko(slovar, prva_crka, ref slovar_oseb);
                /* for (int j = 0; j < slovar_oseb.Count; j++)
                 {
                     Console.WriteLine("RESITEV: " + slovar_oseb[j].Ime);
                 }
                 */

                // vstavimo osebo v slovar
                vstavi_osebo_v_slovar_oseb(ref slovar_oseb, seznam[i]);

                // posodobi slovar
                posodobi_slovar_oseb_v_slovarju(ref slovar, prva_crka, slovar_oseb);
            }
        }

        public static bool test1()
        {
            // dodaj poljubno število oseb
            Oseba[] seznam = new Oseba[1];

            Oseba os1;
            os1.Ime = "Jani";
            os1.Priimek = "Dugonik";
            os1.IDUM = 123456789;

            seznam[0] = os1;

            int N = seznam.Length;
            SortedDictionary<int, Oseba> tempSlovar = new SortedDictionary<int, Oseba> { { 0, os1 } };

            SortedDictionary<char, SortedDictionary<int, Oseba>> slovar = new SortedDictionary<char, SortedDictionary<int, Oseba>> { { 'D', tempSlovar } };

            napolni_slovar(seznam, N, ref slovar);

            // dodaj poljubne teste
            if (slovar.Count != 1)
                return false;

            return true;
        }

        static void preveri(bool pogoj)
        {
            if (!pogoj)
                Console.WriteLine("Napaka!");
        }
        public static void Main(string[] args)
        {
            preveri(test1() == true);
        }

    }
}
