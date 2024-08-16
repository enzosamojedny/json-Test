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
using System.Numerics;
using Client.Entities;
namespace Reconciler.Entities
{

    
    //Aggregation is similar to composition, but the lifetime of the objects involved is more independent.
    //If a Reconciler object manages multiple Transfer objects but doesn’t own them exclusively, aggregation might be appropriate.

    //for example, aggregation would be something is a part of something else
    //objects can live without eachother but when they connect, they do have great semantic connection
    public class ReconcileAccounts
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
        public ReconcileAccounts(bool isApproved, bool areFundsEnough, bool accountStatus, bool isSameCurrency, decimal transactionFee)
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

        //este metodo SOLO CHECKEA QUE TODO ESTE CORRECTO y seria ideal que te de el transferID acá, no?
        public void ReconcileFunds(Transfer transfer, FinancialEntity financialEntity) 
        {
            Console.WriteLine(transfer);
        }
        //crear una db para comprobantes emitidos con todos los datos del objeto
    }
}
