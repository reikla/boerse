using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockExchange.Models
{
    public class StockModels
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }

        public string IdBoerse { get; set; }

    }
}