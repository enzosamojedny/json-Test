using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Transference.Entities;
using System.Net;
using System.Xml.Linq;
using Client.Entities;

namespace Reconciler.Entities
{
    public class ReconcileAccounts : Transfer
    {
        public bool IsApproved { get; set; }
        public bool AreFundsEnough { get; set; }
        public bool AccountStatus { get; set; } // active or inactive
        public bool IsSameCurrency { get; set; } // i can add a check if currency exists or not
        public decimal TransactionFee { get; set; }
        public DateTime TransactionTime { get; set; } = DateTime.Now; // timestamp

        private static string jsonFilepath = Environment.GetEnvironmentVariable("RECONCILER_PATH");

        // Constructor
        public ReconcileAccounts( bool isApproved, bool areFundsEnough, bool accountStatus, bool isSameCurrency, decimal transactionFee, int id, string name, string dni, decimal savingsAccount, string origin, string destination, decimal amount,string transferid)
            : base(origin, destination, amount, transferid)
        {
            IsApproved = isApproved;
            AreFundsEnough = areFundsEnough;
            AccountStatus = accountStatus;
            IsSameCurrency = isSameCurrency;
            TransactionFee = transactionFee;
        }
    }
}
