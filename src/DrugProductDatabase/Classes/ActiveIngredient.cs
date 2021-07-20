using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugProductDatabase
{
    public class ActiveIngredient
    {
        public string dosage_unit { get; set; }
        public string dosage_value { get; set; }
        public int drug_code { get; set; }
        public string ingredient_name { get; set; }
        public decimal? strength { get; set; }
        public string strength_unit { get; set; }
    }
}
