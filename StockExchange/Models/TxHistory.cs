using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockExchange.Models
{
    public class TxHistory
    {
        public string Id { get; set; }
        public int Amount  { get; set; }
        public double Price { get; set; }

    }
}