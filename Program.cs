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

namespace array_practice
{
    //implementar un front para console, con menú navegable con arrows y algún que otro ASCII
    // implementar windows terminal en vez de la consola normal, cambiar la font a monospace y ajustar colores de la consola (si es posible)
    internal class Program
    {
        static void Main(string[] args) {

            //if (Environment.GetEnvironmentVariable("WT_SESSION") == null)
            //{
            //    Process.Start("wt.exe", $"-d . cmd /c \"{Process.GetCurrentProcess().MainModule.FileName}\"");
            //    Environment.Exit(0);
            //}

            ENV.EnviromentalVariables.DbAccess();

            string asciiArt = @" 
                 _________                            .__                     __________                __                        
                 \_   ___ \  ____   ____   __________ |  |   ____             \______   \_____    ____ |  | __                    
                 /    \     /  _ \ /    \ /  ___/  _ \|  | _/ __ \    ______   |    |  _/\__  \  /    \|  |/ /                    
                 \     \___(  (_) )   |  \\___ (  (_) )  |_\  ___/   /_____/   |    |   \ / __ \|   |  \    <                     
                  \________/\____/|___|__/______>____/|____/\_____>            |________/(______/___|__/__|__\";

            Console.WriteLine(asciiArt);
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

            var first = FinancialEntity.GetEntityByID(1);

            Console.WriteLine(first);
            Console.ReadKey();
            
            var test = Person.GetDataByID(1);
            
            Console.WriteLine(test);

            //var testing = new Person(11,"Carlos huevon","34234456",56432m);
            //Person.CreatePerson(testing);

            //Person person = new Person(inputNombre,inputDNI, decimalDeposit);
            //var result = person.GetPersonValues();
            //Console.WriteLine(result);

            //Transfer transfer = new Transfer(person.Name,person.DNI, person.SavingsAccount, inputDNI, inputDNIDestination, transferAmount);
            //string transferData = transfer.GetTransferData(person);
            //string conceilData = transfer.ConceilMoney(person);
            //Console.WriteLine(transferData);
            //Console.WriteLine(conceilData);
        }
    }
}
