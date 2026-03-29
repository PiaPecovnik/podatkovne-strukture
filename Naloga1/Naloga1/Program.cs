namespace Naloga1;

public struct Student
{
    public string Ime;
    public string Priimek;
    public String IDUM;
};

public class Program
{
    public static void izpisi_seznam(LinkedList<Student> seznam)
    {
        foreach (Student st in seznam)
        {
            izpisi_studenta(st);
        }
    }

    public static void izpisi_studenta(Student st)
    {
        Console.WriteLine("Ime: " + st.Ime + "\nPriimek: " + st.Priimek + "\nIDUM: " + st.IDUM + "\n");
    }

    public static void vstavi(LinkedList<Student> seznam, int indeks, Student podatek)
    {
        if (indeks < 0) { return; }
        if (indeks >= seznam.Count) { return; }
        if (seznam.Count == 0) { return; }

        LinkedListNode<Student> newNode = new LinkedListNode<Student>(podatek);

        LinkedListNode<Student> current = seznam.First;
        for (int i = 0; i < indeks; i++)
        {
            current = current.Next;
        }

        seznam.AddBefore(current, newNode);
        seznam.Remove(current);
    }

    public static Student vrni(LinkedList<Student> seznam, int indeks)
    {
        if (indeks < 0) { return new Student(); }
        if (indeks >= seznam.Count) { return new Student(); }
        if (seznam.Count == 0) { return new Student(); }

        LinkedListNode<Student> current = seznam.First;
        for (int i = 0; i < indeks; i++)
        {
            current = current.Next;
        }

        return current.Value;
    }

    public static void vrini(LinkedList<Student> seznam, int indeks, Student podatek)
    {
        if (indeks < 0) { return; }

        LinkedListNode<Student> newNode = new LinkedListNode<Student>(podatek);
        if (indeks >= seznam.Count)
        {
            seznam.AddLast(newNode);
            return;
        }
        if (seznam.Count == 0)
        {
            seznam.AddFirst(newNode);
            return;
        }

        LinkedListNode<Student> current = seznam.First;
        for (int i = 0; i < indeks; i++)
        {
            current = current.Next;
        }
        seznam.AddBefore(current, newNode);
    }

    public static Student odstrani(LinkedList<Student> seznam, int indeks)
    {
        if (indeks < 0) { return new Student(); }
        if (indeks >= seznam.Count) { return new Student(); }
        if (seznam.Count == 0) { return new Student(); }

        LinkedListNode<Student> current = seznam.First;
        for (int i = 0; i < indeks; i++)
        {
            current = current.Next;
        }
        seznam.Remove(current);

        return current.Value;
    }

    public static void Main(string[] args)
    {
        Student student1 = new Student { Ime = "Pia", Priimek = "Pecovnik", IDUM = "1234567" };
        Student student2 = new Student { Ime = "Franci", Priimek = "Novak", IDUM = "765321" };
        Student student3 = new Student { Ime = "Anja", Priimek = "Ferin", IDUM = "246802" };

        Student[] studenti = { student1, student2 };
        LinkedList<Student> seznam = new LinkedList<Student>(studenti);

        LinkedList<Student> prazenSeznam = new LinkedList<Student>();


        // 1. Funkcija vstavi
        vstavi(seznam, 0, student3);  //neprazen seznam

        vstavi(prazenSeznam, 0, student3);  //v prazen seznam

        vstavi(seznam, -1, student3);  //indeks manjsi od 0

        vstavi(seznam, 6, student3);   //indeks >= velikosti seznama



        // 2. Funkcija vrni
        Student st0 = vrni(seznam, 0);   //neprazen seznam

        Student st1 = vrni(prazenSeznam, 0);   // v prazen seznam

        Student st2 = vrni(seznam, -3);  // indeks manjsi od 0

        Student st3 = vrni(seznam, 10);  //indeks >= velikosti seznama


        // 3. Funkcija vrini
        vrini(seznam, 1, student3);  //neprazen seznam

        vrini(prazenSeznam, 0, student3);  //v prazen seznam

        vrini(seznam, -1, student3);  //indeks manjsi od 0

        vrini(seznam, 7, student3);   //indeks >= velikosti seznama


        // 4. Funkcija odstrani
        Student st4 = odstrani(seznam, 0);   //neprazen seznam

        Student st5 = odstrani(prazenSeznam, 0);  // v prazen seznam

        Student st6 = odstrani(seznam, -4);  //indeks manjsi od 0

        Student st7 = odstrani(seznam, 11);   //indeks >= velikosti seznama
    }
}