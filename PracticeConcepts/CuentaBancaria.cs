// Practice Concepts: Encapsulation
// Pricipal property: hiden state and controlled access
// How implement: private fields, public properties with logic, methods for state modification

namespace PracticeConcepts
{
    public class CuentaBancaria
    {
        // Private fields
        private decimal _saldo;

        // Public property with control access (only read access)
        public decimal Saldo => _saldo;

        // Method that modifies the internal state, with business logic
        public void Depositar(decimal cantidad)
        {
            if (cantidad <= 0) throw new ArgumentException("Invalid quantify");
            _saldo += cantidad;
        }

        public void Retirar(decimal cantidad)
        {
            if (cantidad <= 0) throw new ArgumentException("Invalid quantify");
            if (cantidad > _saldo) throw new InvalidOperationException("Insufficient funds");
            _saldo -= cantidad;
        }

    }
}
