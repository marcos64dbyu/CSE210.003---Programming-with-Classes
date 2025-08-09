// Practice Concepts: Class and Object

namespace PracticeConcepts
{
    // 1. Class and Object
    public class Persona
    {
        // fields (data)
        public string _name;
        public int _age;

        // Constructor – it run when an object is created
        public Persona(string name, int age)
        {
            _name = name;
            _age = age;
        }

        // Method (behavior)
        public void greatings()
        {
            Console.WriteLine($"Hello, I'm {_name} and I'm {_age} old.");
        }
    }
}
