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
            // TODO	
        }

        public static void dobi_slovar_s_crko(SortedDictionary<char, SortedDictionary<int, Oseba>> slovar, char prva_crka, ref SortedDictionary<int, Oseba> slovar_oseb)
        {
            // TODO
        }

        public static void vstavi_osebo_v_slovar_oseb(ref SortedDictionary<int, Oseba> slovar_oseb, Oseba os)
        {
            // TODO
        }

        public static void posodobi_slovar_oseb_v_slovarju(ref SortedDictionary<char, SortedDictionary<int, Oseba>> slovar, char prva_crka, SortedDictionary<int, Oseba> slovar_oseb)
        {
            // TODO
        }

        public static void napolni_slovar(Oseba []seznam, int N, ref SortedDictionary<char, SortedDictionary<int, Oseba>> slovar)
        {
            for (int i = 0; i < N; i++)
            {
                // pridobimo prvo črko
                char prva_crka = new char();
                dobi_prvo_crko(seznam[i], ref prva_crka);	

                // pridobimo slovar oseb s prvo črko
                SortedDictionary<int, Oseba> slovar_oseb = new SortedDictionary<int, Oseba>();
                dobi_slovar_s_crko(slovar, prva_crka, ref slovar_oseb);

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
			
			SortedDictionary<char, SortedDictionary<int, Oseba>> slovar = new SortedDictionary<char, SortedDictionary<int, Oseba>>();
			
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
