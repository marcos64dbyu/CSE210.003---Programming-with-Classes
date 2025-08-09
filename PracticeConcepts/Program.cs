using PracticeConcepts;

class Progam
{
    static void Main(string[] args)
    {
        // 1. Class and Object
        Console.WriteLine("----------1. Class and Object:------------");
        Persona persona1 = new Persona("John", 30);
        persona1.greatings();



        // 2. Encapsulation
        Console.WriteLine("----------2. Encapsulation:------------");
        CuentaBancaria cuenta = new CuentaBancaria();
        cuenta.Depositar(1000);
        Console.WriteLine($"Current balance : {cuenta.Saldo}");
        cuenta.Retirar(200);
        Console.WriteLine($"Current balance after the withdrawal.: {cuenta.Saldo}");




        // 3. Inheritance
        Console.WriteLine("----------3. Inheritance:------------");
        Animal perro = new Perro("Rex");
        perro.HacerSonido(); // Output: The Rex barks.

        Animal gato = new Gato("Mia");
        gato.HacerSonido(); // Output: The Mia meows.




        // 4. Polymorphism
        // Polymorphism allows methods to be used in different ways depending on the object type
        Console.WriteLine("----------4. Polymorphism:------------");
        // We can use the same method name HacerSonido() for different animal types
        // 1. way: using the base class reference
        Console.WriteLine("----------4.1. Polymorphism with base class reference:------------");
        //
        List<Animal> animales = new List<Animal> { perro, gato };
        foreach (var animal in animales)
        {
            animal.HacerSonido(); // Output: The Rex barks. and The Mia meows.
        }

        // 2. way: using derived class references
        Console.WriteLine("----------4.2. Polymorphism with derived class reference:------------");
        var lists = new List<Animal>
        {
            new Perro("Rocky"),
            new Gato("Luna")
        };
        ReproducuirSonido(lists); // Output: The Rocky barks. and The Luna meows.

    }


    // Inheritance - Obtained by creating a base class and derived
    public class Perro : Animal
    {
        public Perro(string nombre) : base(nombre) { }

        // Override the virtual method with specific behavior
        public override void HacerSonido() => Console.WriteLine($"The {Nombre} barks.");
    }

    public class Gato : Animal
    {
        public Gato(string nombre) : base(nombre) { }
        // Override the virtual method with specific behavior
        public override void HacerSonido() => Console.WriteLine($"The {Nombre} meows.");
    }




    // Polymorphism - allows methods to be used in different ways depending on the object type
    public static void ReproducuirSonido(IEnumerable <Animal> animales)
    {
        foreach (var a in animales)
        {
            a.HacerSonido(); // Calls the overridden method based on the actual object type
        }
    }


}
