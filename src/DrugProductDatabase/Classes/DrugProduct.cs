using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugProductDatabase
{
    public class DrugProduct
    {
        public int drug_code { get; set; }
        public string class_name { get; set; }
        public string drug_identification_number { get; set; }
        public string brand_name { get; set; }
        public string descriptor { get; set; }
        public int? number_of_ais { get; set; }
        public string ai_group_no { get; set; }
        public string company_name { get; set; }
        public DateTime? last_update_date { get; set; }

        public PharmaceuticalStandard pharmaceutical_standard { get; set; }
        public ProductStatus product_status { get; set; }

        public List<ActiveIngredient> active_ingredients { get; set; }
        public List<DosageForm> dosage_forms { get; set; }
        public List<Packaging> package_sizes { get; set; }
        public List<RouteOfAdministration> routes_of_administration { get; set; }
        public List<Schedule> schedules { get; set; }
        public List<TherapeuticClass> therapeutic_classes { get; set; }
    }
}
