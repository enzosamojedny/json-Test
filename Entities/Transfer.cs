using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Entities;
using Financial.Entities;

namespace Transference.Entities
{
    public class Transfer : Person
    {
         
        //cambiar tipos de datos, hacerlo más útil y seguro
        public string Origin { get; set; }
        public string Destination { get; set; }
        public decimal Amount { get; set; }
        public Guid TransferID { get; set; }

        private static string jsonFilepath = Environment.GetEnvironmentVariable("TRANSFERENCE_PATH");

        public Transfer(int clientid, string name, string dni, decimal savingsAccount, string origin, string destination, decimal amount, int transferid,string accountNumber, string alias) : base(clientid, name, dni, savingsAccount,accountNumber, alias)
        {
            Origin = origin;
            Destination = destination;
            Amount = amount;
            TransferID = Guid.NewGuid(); ;
        }
        public static void CreateTransfer(Transfer transfer)
        {
            HelperFns.Helper.WriteInDB(jsonFilepath,3,null,null, transfer);
        }

        public static void ReconcileTransaction(Transfer transfer, FinancialEntity financialEntity)
        {
            //directamente mando desde acá los datos necesarios del cliente, allá proceso todo y devuelvo lo necesario, con eso puedo imprimir un comprobante

            //var transferReconciled = Reconciler.Entities.ReconcileAccounts.ReconcileFunds(financialEntity.ID, financialEntity.Name, transfer.Origin, transfer.Destination, transfer.Amount, transfer.AccountNumber, transfer.Alias, transfer.DNI, transfer.ClientID, transfer.TransferID);

        }



       public string GetTransferData(Person person)
        {
            return $"Name: {Name}, DNI: {DNI}, Origin: {Origin}, Destination: {Destination}, Amount: {Amount}";
        }
    }
}
