using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugProductDatabase
{
    public class ProductStatus
    {
        public int drug_code { get; set; }
        public string status { get; set; }
        public DateTime? history_date { get; set; }
        public DateTime? original_market_date { get; set; }
        public int? external_status_code { get; set; }
        public DateTime? expiration_date { get; set; }
        public int? lot_number { get; set; }
    }
}
