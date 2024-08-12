using PersonBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferBuilder
{
    public class Transfer : Person // hereda valores de Persona
    {
        public string Origin {  get; set; }
        public string Destination { get; set; }
        public decimal Amount { get; set; }
        public string TransferID { get; set; }// unused for now








        public Transfer(string name, string dni, decimal savingsAccount, string origin, string destination, decimal amount) : base(name,dni, savingsAccount) { // envio una persona por defecto, mas los datos de la transfer
            Origin = origin;
            Destination = destination;
            Amount = amount;
        }

        public string GetTransferData(Person person)
        {
            return $"Name: {Name}, DNI: {DNI}, Origin: {Origin}, Destination: {Destination}, Amount: {Amount}";
        }
        public string ConceilMoney(Person person)
        {
            return $"Initial money: {SavingsAccount} - Amount: {Amount} = {SavingsAccount - Amount} ";
        }
    }
}
