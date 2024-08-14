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
using Financial.Entities;

namespace Reconciler.Entities
{
    public class ReconcileAccounts : Transfer
    {

        //cosas a hacer en Reconciler:
        //1- chequear saldo de clientes
        //2- chequear el tipo de divisa EUR USD (y ejecutar la conversion, podría ser)
        //3- ejecutar la transferencia
        //4- cobrar SIRCREB (because why not?)
        //5- descontar el saldo
        //6- aprobar la transferencia (solo si los datos coinciden)

        public bool IsApproved { get; set; }
        public bool AreFundsEnough { get; set; }
        public bool AccountStatus { get; set; } // active or inactive
        public bool IsSameCurrency { get; set; } // i can add a check if currency exists or not
        public decimal TransactionFee { get; set; }
        public DateTime TransactionTime { get; set; } = DateTime.Now; // timestamp

        private static string jsonFilepath = Environment.GetEnvironmentVariable("RECONCILER_PATH");

        // Constructor
        public ReconcileAccounts(bool isApproved, bool areFundsEnough, bool accountStatus, bool isSameCurrency, decimal transactionFee, int id, string name, string dni, decimal savingsAccount, string origin, string destination, decimal amount, int transferid, string accountNumber,string alias)
            : base(id, name, dni, savingsAccount, origin, destination, amount, transferid, accountNumber,alias)
        {
            IsApproved = isApproved;
            AreFundsEnough = areFundsEnough;
            AccountStatus = accountStatus;
            IsSameCurrency = isSameCurrency;
            TransactionFee = transactionFee; //harcodear el % de fees
        }
        //ReconcileFunds()
        // tiene que recibir un decimal amount, chequear accountStatus, areFundsEnough, origin (aca se descuenta) y se acredita en destination
        // (buscando el accountNumber o alias, puede venir por parametro tmb)
        // chequear que haya saldo (sumando fees), y descontar el saldo a uno y acreditarlo a otro
        public decimal ReconcileFunds(int financialEntityID, string financialEntityName, string transferOrigin, string transferDestination, decimal transferAmount, Guid transferAccountNumber, string alias, string transferDNI, int transferClientID) 
        {
            return 0;
        }

    }
}
