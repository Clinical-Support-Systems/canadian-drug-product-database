using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugProductDatabase
{
    public class Packaging
    {
        public int drug_code { get; set; }
        public string upc { get; set; }
        public string package_size_unit { get; set; }
        public string package_type { get; set; }
        public string package_size { get; set; }
        public string product_information { get; set; }
    }
}
