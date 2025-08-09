// Inheritance

namespace PracticeConcepts
{
    public abstract class Animal    // class base (capable of containing shared logic)
    {
        public string Nombre { get; set; }

        public  Animal(string nombre) => Nombre = nombre;

        // Virtual method to be overridden
        public virtual void HacerSonido() =>  Console.WriteLine($"The {Nombre} makes a sound.");

    }
}
