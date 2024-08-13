using array_practice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferBuilder;
using System.IO;
using Newtonsoft.Json;
using PersonBuilder;
namespace AccountReconciler
{
    public class ReconcileAccounts : Transfer
    {
        public bool IsApproved { get; set; }
        public bool AreFundsEnough { get; set; }
        public bool AccountStatus { get; set; } // active or inactive
        public bool IsSameCurrency {  get; set; } // i can add a check if currency exists or not
        public decimal TransactionFee { get; set; }
        public DateTime TransactionTime { get; set; } = DateTime.Now; // timestamp

        private static string json = "PersonDB.json";
        private static string jsonData = System.IO.File.ReadAllText(json);
        List<Person> strings = JsonConvert.DeserializeObject<List<Person>>(jsonData);

        public ReconcileAccounts(bool isApproved, bool areFundsEnough, bool accountStatus, bool isSameCurrency, decimal transactionFee,int id, string name, string dni, decimal savingsAccount, string origin, string destination, decimal amount) : base(id, name,dni,savingsAccount,origin, destination, amount)
        {
            IsApproved = isApproved;
            AreFundsEnough = areFundsEnough;
            AccountStatus = accountStatus;
            IsSameCurrency = isSameCurrency;
            TransactionFee = transactionFee;

        }
    }
}
