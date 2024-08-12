using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace PersonBuilder
{
    public class Person
    {
        public string Name { get; set; }
        public string DNI { get; set; }
        public decimal SavingsAccount { get; set; }

        private static string json = "PersonDB.json";

        private static string jsonData = System.IO.File.ReadAllText(json);

        //para agregar una nueva persona, creamos el objeto, lo agregamos a la lista, lo serializamos y despues queda hacer un WriteAllText, eso seria todo!
    public static string InitializeData()
    {
        List<Person> list = JsonConvert.DeserializeObject<List<Person>>(jsonData);
        
        string result = "";
        foreach (var person in list)
        {
            result += person.Name + "\n";
        }
        return result;
    }


        public Person(string name, string dni, decimal savingsAccount) // constructor should have the same name as the class
        {
            Name = name;
            DNI = dni;
            SavingsAccount = savingsAccount;
        }

        public void CreatePerson(Person person)
        {
            person.Name = Name;
            person.DNI = DNI;
            person.SavingsAccount = SavingsAccount;
        }

        public string GetPersonValues() // method should always have a return, unless it's -void-
        {
           return $"Name: {Name}, DNI: {DNI}, Money: {SavingsAccount}";
        }
    }
}
