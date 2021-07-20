using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugProductDatabase
{
    public class DosageForm
    {
        public int drug_code { get; set; }
        public int pharmaceutical_form_code { get; set; }
        public string pharmaceutical_form_name { get; set; }
    }
}
