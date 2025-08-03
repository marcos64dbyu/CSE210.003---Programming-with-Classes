namespace Practica
{
    public class Admin : person
    {
        private string _function;
        private string _role;
        private string _access;

        public Admin()
        {
            _name = "Admin";
            _age = 30;
            _address = "123 Admin St.";
            _phoneNumber = "123-456-7890";
            _function = "System Administrator";
            _role = "Administrator";
            _access = "Full Access";
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Name: {_name}");
            Console.WriteLine($"Age: {_age}");
            Console.WriteLine($"Address: {_address}");
            Console.WriteLine($"Phone Number: {_phoneNumber}");
            Console.WriteLine($"Function: {_function}");
            Console.WriteLine($"Role: {_role}");
            Console.WriteLine($"Access Level: {_access}");
        }
    }
}
