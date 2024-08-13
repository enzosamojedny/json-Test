using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Client.Entities
{
    public class Person
    {
        public int ClientID { get; set; }
        public string Name { get; set; }
        public string DNI { get; set; }

        public string AccountNumber {  get; set; } //UUID maybe
        public decimal SavingsAccount { get; set; }

        private static string jsonFilepath = Environment.GetEnvironmentVariable("PERSON_PATH");

        //para agregar una nueva persona, creamos el objeto, lo agregamos a la lista, lo serializamos y despues queda hacer un WriteAllText, eso seria todo!

        public Person(int clientid, string name, string dni, decimal savingsAccount, int accountNumber) // constructor should have the same name as the class
        {
            ClientID = clientid;
            Name = name;
            DNI = dni;
            SavingsAccount = savingsAccount;//balance
            AccountNumber = accountNumber; //like a cbu, so i transfer to an accountNumber instead of a clientID
        }

        static string ReadDB(string jsonFilepath)
        {
            string jsonData = File.ReadAllText(jsonFilepath);
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
                if (person.ClientID == id)
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
