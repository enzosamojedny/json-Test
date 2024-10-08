﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Numerics;

namespace Client.Entities
{
    public class Person
    {
        public int ClientID { get; set; }
        public string Name { get; set; }
        public string DNI { get; set; }
        public BigInteger AccountNumber {  get; set; } // tipo CBU
        public decimal AccountBalance { get; set; } //balance
        public string Alias {  get; set; }

        private static string jsonFilepath = Environment.GetEnvironmentVariable("PERSON_PATH");

        //para agregar una nueva persona, creamos el objeto, lo agregamos a la lista, lo serializamos y despues queda hacer un WriteAllText, eso seria todo!

        public Person(int clientid, string name, BigInteger accountNumber, string dni, decimal accountBalance, string alias) // constructor should have the same name as the class
        {
            ClientID = clientid;
            Name = name;
            DNI = dni;
            AccountBalance = accountBalance;//balance
            AccountNumber = accountNumber; //like a cbu, so i transfer to an accountNumber instead of a clientID
            Alias = alias;
        }

        static string ReadDB(string jsonFilepath)
        {
            string jsonData = File.ReadAllText(jsonFilepath);
            return jsonData;
        }

        //metodos
        public static void CreatePerson(Person person)
        {
            HelperFns.Helper.WriteInDB(jsonFilepath, 1, person, null, null,null);
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
        public string GetPersonValues()
        {
            return $"ClientID: {ClientID}, Name: {Name}, DNI: {DNI}, AccountNumber: {AccountNumber}, AccountBalance: {AccountBalance}, Alias: {Alias}";
        }
    }
}
