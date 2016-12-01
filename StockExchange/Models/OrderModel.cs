using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockExchange.Models
{
    public class OrdersModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string IdStock { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public string Type { get; set; } //todo: enum?

        public List<TxHistory> TxHistory { get; set; }

        //Todo: utc?
        public DateTime TimeStamp { get; set; }

        public string IdBoerse { get; set; }

        public string Signature { get; set; }

        public string IdBank { get; set; }

        public string IdCustomer { get; set; }


        public OrdersModel(string idStock, int amount, int price, string type, string idCustomer)
        {
            IdStock = idStock;
            Amount = amount;
            Price = price;
            Type = type;
            IdCustomer = idCustomer;
            TxHistory = new List<Models.TxHistory>();
            TimeStamp = DateTime.UtcNow;
            IdBoerse = "Afganistan";
            IdBank = "bank.reimar";
            Signature = "";
        }

        public OrdersModel()
        {

        }
    }


}