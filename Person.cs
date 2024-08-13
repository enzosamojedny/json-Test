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
        public int ID { get; set; }
        public string Name { get; set; }
        public string DNI { get; set; }
        public decimal SavingsAccount { get; set; }

        private static string jsonFilepath = Environment.GetEnvironmentVariable("PERSON_PATH");






        //para agregar una nueva persona, creamos el objeto, lo agregamos a la lista, lo serializamos y despues queda hacer un WriteAllText, eso seria todo!



        public Person(int id, string name, string dni, decimal savingsAccount) // constructor should have the same name as the class
        {
            ID = id;
            Name = name;
            DNI = dni;
            SavingsAccount = savingsAccount;
        }

        static string ReadDB(string jsonFilepath)
        {
            string jsonData = System.IO.File.ReadAllText(jsonFilepath);
            return jsonData;
        }

        //metodos
        public static void CreatePerson(Person person)
        {
            HelperFns.Helper.WriteInDB(jsonFilepath, 1, person, null, null);
        }

        public static string GetDataByID(int id)
        {
            var dataFromDB = ReadDB(jsonFilepath);
            List<Person> list = JsonConvert.DeserializeObject<List<Person>>(dataFromDB);
            string result = "";
            foreach (var person in list)
            {
                if(person.ID == id)
                {
                    result = person.Name;
                }
                //result += person.Name + "\n";
            }
            return result;
        }
        public string GetPersonValues() // method should always have a return, unless it's -void-
        {
           return $"Name: {Name}, DNI: {DNI}, Money: {SavingsAccount}";
        }
    }
}
