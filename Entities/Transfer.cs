using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Client.Entities;
using Financial.Entities;
using Reconciler.Entities;
namespace Transference.Entities
{
    public class Transfer
    {

        //Composition allows you to build complex objects from simpler ones. This is useful when your objects have a "has-a" relationship. In your app:

        //Transfer and Client: A Transfer might be composed of client-related data but isn't a client itself. You might use composition to include Client information in a Transfer.

        public Person Person { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public decimal Amount { get; set; }
        public Guid TransferID { get; set; }

        private static string jsonFilepath = Environment.GetEnvironmentVariable("TRANSFERENCE_PATH");

        public Transfer(string origin, string destination, decimal amount, int transferid, Person persondata)
        {
            Origin = origin;
            Destination = destination;
            Amount = amount;
            TransferID = Guid.NewGuid();
            Person = persondata; //person information is already included in transfer
        }
        //---> asi se crea una instancia de transfer asociado a una persona ( seria todo por cmd!
        //Person personData = new Person("John Doe", "12345678", 5000m);
        //Transfer transfer = new Transfer("OriginBank", "DestinationBank", 1000m, 12345, personData);


        public static void CreateTransfer(Transfer transfer)
        {
            HelperFns.Helper.WriteInDB(jsonFilepath,3,null,null, transfer,null);
        }


        public static void ReconcileTransaction(Transfer transfer, FinancialEntity financialEntity, ReconcileAccounts reconcileAccounts)
        {
            reconcileAccounts.ReconcileFunds(transfer,financialEntity);

        }

       public string GetTransferData(Person person) //el comprobante que retorna ReconcileFunds (se guarda en db)
        {
            return "";
        }
    }
}
