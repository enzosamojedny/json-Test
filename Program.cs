using Microsoft.VisualBasic;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;
using Newtonsoft.Json;
using ENV;
using Financial.Entities;
using Client.Entities;
using System.Diagnostics;
using System.Numerics;

// READ Composition/AggregatioN to simulate relationships between objects <----------------------------------
namespace array_practice
{
    //implementar un front para console, con menú navegable con arrows y algún que otro ASCII
    // implementar windows terminal en vez de la consola normal, cambiar la font a monospace y ajustar colores de la consola (si es posible)s

    // can I add a login maybe? it'd be great, so all transfers related to an account could be fetched
    internal class Program
    {
        static void Main(string[] args) {

            //if (Environment.GetEnvironmentVariable("WT_SESSION") == null)
            //{
                //Process.Start("wt.exe", $"-d . cmd /c \"{Process.GetCurrentProcess().MainModule.FileName}\"");
                //Environment.Exit(0);
            //}

            ENV.EnviromentalVariables.DbAccess();

            string asciiArt = @" 
                 _________                               .__                      __________                   __                        
                 \_   ____\   ___    ____    ______ ___  |  |    ____             \______   \ _____     ____  |  | __                    
                 /    \      / _ \  /----\  /  ___// _ \ |  |  _/ __ \    ______   |    |  _/ \__  \   /----\ |  |/ /                    
                 \     \___ / (_) \/   |  \ \___  / (_) \|  |__\  ___/   /_____/   |    |   \  / __ \ |   |  \|    /                     
                  \________\\_____/|___|__//______\_____/|____/ \_____\            |________/ (______\|___|__/|__|__\";

            Console.WriteLine(asciiArt);
            Console.ReadKey();
            Console.Clear();
            //Console.WriteLine("Write your full name");
            //string inputNombre = Console.ReadLine();
            //Console.ReadKey();

            //Console.WriteLine("Insert DNI");
            //string inputDNI = Console.ReadLine();
            //Console.ReadKey();


            //Console.WriteLine("Add initial deposit");
            //string inputDeposit = Console.ReadLine();
            //decimal decimalDeposit = decimal.Parse(inputDeposit);
            //Console.ReadKey();

            //Console.WriteLine("Insert Destination DNI");
            //string inputDNIDestination = Console.ReadLine();
            //Console.ReadKey();

            //Console.WriteLine("Insert amount to transfer");
            //string inputTransfer = Console.ReadLine();
            //decimal transferAmount = decimal.Parse(inputTransfer);
            //Console.ReadKey();

            //var first = FinancialEntity.GetEntityByID(1);

            //Console.WriteLine(first);
            //Console.ReadKey();

            //var test = Person.GetDataByID(1);

            //Console.WriteLine(test);
            var guid = Guid.NewGuid().ToString();
            BigInteger bigIntValue = BigInteger.Parse("12345678901234567890123456784567890");



            Person person = new Person(1, "Charles Donut", bigIntValue, guid, 56432m, "donuts4me");
            Person.CreatePerson(person);
            var result = person.GetPersonValues();
            Console.WriteLine(result);

            //Transfer transfer = new Transfer(person.Name,person.DNI, person.SavingsAccount, inputDNI, inputDNIDestination, transferAmount);
            //string transferData = transfer.GetTransferData(person);
            //string conceilData = transfer.ConceilMoney(person);
            //Console.WriteLine(transferData);
            //Console.WriteLine(conceilData);
        }
    }
}
