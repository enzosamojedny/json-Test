using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Entities;

namespace Transference.Entities
{
    public class Transfer : Person
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public decimal Amount { get; set; }
        public int TransferID { get; set; } //like an UUID

        private static string jsonFilepath = Environment.GetEnvironmentVariable("TRANSFERENCE_PATH");
        public Transfer(int clientid, string name, string dni, decimal savingsAccount, string origin, string destination, decimal amount, int transferid,string accountNumber) : base(clientid, name, dni, savingsAccount,accountNumber)
        {
            Origin = origin;
            Destination = destination;
            Amount = amount;
            TransferID = transferid;
        }
        public static void CreateTransfer(Transfer transfer)
        {
            HelperFns.Helper.WriteInDB(jsonFilepath,3,null,null, transfer);
        }

        public string GetTransferData(Person person)
        {
            return $"Name: {Name}, DNI: {DNI}, Origin: {Origin}, Destination: {Destination}, Amount: {Amount}";
        }

        //this method calls Reconciler.cs, and it checks for inconsistencies
        public string ReconcileMoney(Person person)
        {
            return $"Initial money: {SavingsAccount} - Amount: {Amount} = {SavingsAccount - Amount} ";
        }
    }
}
