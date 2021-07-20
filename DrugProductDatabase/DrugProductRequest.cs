using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DrugProductDatabase
{
    public static class DrugProductRequest
    {
        private const string baseUrl = "https://health-products.canada.ca";
        private const string productRequestDin = "api/drug/drugproduct?din=";
        private const string productRequestCode = "api/drug/drugproduct?id=";
        private const string ingredientRequest = "api/drug/activeingredient?id=";
        private const string companyRequest = "api/drug/company?id=";
        private const string formRequest = "api/drug/form?id=";
        private const string packageRequest = "api/drug/packaging?id=";
        private const string standardRequest = "api/drug/pharmaceuticalstd?id=";
        private const string routeRequest = "api/drug/route?id=";
        private const string scheduleRequest = "api/drug/schedule?id=";
        private const string statusRequest = "api/drug/status?id=";
        private const string classRequest = "api/drug/therapeuticclass?id=";

        #region Get Product

        public static async Task<DrugProduct> GetDrugProduct(string din, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            var requestString = $"{productRequestDin}{din}";
            var result = await RequestData<DrugProduct>(requestString, cancellationToken).ConfigureAwait(false);
            var product = result.FirstOrDefault();

            if (includeDetails && product != null)
            {
                await GetAdditionProductInfo(product).ConfigureAwait(false);
            }
            return product;
        }

        public static async Task<DrugProduct> GetDrugProduct(int drugCode, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            var requestString = $"{productRequestCode}{drugCode}";
            var result = await RequestData<DrugProduct>(requestString, cancellationToken).ConfigureAwait(false);
            var product = result.FirstOrDefault();

            if (includeDetails && product != null)
            {
                await GetAdditionProductInfo(product).ConfigureAwait(false);
            }
            return product;
        }

        private static async Task GetAdditionProductInfo(DrugProduct product, CancellationToken ct = default)
        {
            // get active ingredients
            product.active_ingredients = await GetActiveIngredientsAsync(product.drug_code, ct).ConfigureAwait(false);
            // get company
            //product.company = await GetCompanyAsync(product.drug_code, ct).ConfigureAwait(false);
            // get the dosage form
            product.dosage_forms = await GetDosageFormsAsync(product.drug_code, ct).ConfigureAwait(false);
            // get the packaging
            product.package_sizes = await GetPackagingAsync(product.drug_code, ct).ConfigureAwait(false);
            // get pharmaceutical standard
            product.pharmaceutical_standard = await GetPharmaceuticalStandardAsync(product.drug_code, ct).ConfigureAwait(false);
            // get route of administration
            product.routes_of_administration = await GetRoutesOfAdministrationAsync(product.drug_code, ct).ConfigureAwait(false);
            // get schedules
            product.schedules = await GetSchedulesAsync(product.drug_code, ct).ConfigureAwait(false);
            // get status
            product.product_status = await GetStatusAsync(product.drug_code, ct).ConfigureAwait(false);
            // get therapeutic classes
            product.therapeutic_classes = await GetTherapeuticClassesAsync(product.drug_code, ct).ConfigureAwait(false);
        }

        #endregion Get Product

        #region Other Requests

        public static async Task<List<ActiveIngredient>> GetActiveIngredientsAsync(int drugCode, CancellationToken cancellationToken = default)
        {
            var requestString = $"{ingredientRequest}{drugCode}";
            var result = await RequestData<ActiveIngredient>(requestString, cancellationToken).ConfigureAwait(false);
            return result;
        }

        public static async Task<Company> GetCompanyAsync(int companyCode, CancellationToken cancellationToken = default)
        {
            var requestString = $"{companyRequest}{companyCode}";
            var result = await RequestData<Company>(requestString, cancellationToken).ConfigureAwait(false);
            return result.FirstOrDefault();
        }

        public static async Task<List<DosageForm>> GetDosageFormsAsync(int drugCode, CancellationToken cancellationToken = default)
        {
            var requestString = $"{formRequest}{drugCode}";
            var result = await RequestData<DosageForm>(requestString, cancellationToken).ConfigureAwait(false);
            return result;
        }

        public static async Task<List<Packaging>> GetPackagingAsync(int drugCode, CancellationToken cancellationToken = default)
        {
            var requestString = $"{packageRequest}{drugCode}";
            var result = await RequestData<Packaging>(requestString, cancellationToken).ConfigureAwait(false);
            return result;
        }

        public static async Task<PharmaceuticalStandard> GetPharmaceuticalStandardAsync(int drugCode, CancellationToken cancellationToken = default)
        {
            var requestString = $"{standardRequest}{drugCode}";
            var result = await RequestData<PharmaceuticalStandard>(requestString, cancellationToken).ConfigureAwait(false);
            return result.FirstOrDefault(); ;
        }

        public static async Task<List<RouteOfAdministration>> GetRoutesOfAdministrationAsync(int drugCode, CancellationToken cancellationToken = default)
        {
            var requestString = $"{routeRequest}{drugCode}";
            var result = await RequestData<RouteOfAdministration>(requestString, cancellationToken).ConfigureAwait(false);
            return result;
        }

        public static async Task<List<Schedule>> GetSchedulesAsync(int drugCode, CancellationToken cancellationToken = default)
        {
            var requestString = $"{scheduleRequest}{drugCode}";
            var result = await RequestData<Schedule>(requestString, cancellationToken).ConfigureAwait(false);
            return result;
        }

        public static async Task<ProductStatus> GetStatusAsync(int drugCode, CancellationToken cancellationToken = default)
        {
            var requestString = $"{statusRequest}{drugCode}";
            var result = await RequestData<ProductStatus>(requestString, cancellationToken, false).ConfigureAwait(false);
            return result.FirstOrDefault();
        }

        public static async Task<List<TherapeuticClass>> GetTherapeuticClassesAsync(int drugCode, CancellationToken cancellationToken = default)
        {
            var requestString = $"{classRequest}{drugCode}";
            var result = await RequestData<TherapeuticClass>(requestString, cancellationToken).ConfigureAwait(false);
            return result;
        }

        #endregion Other Requests

        #region Generic JSON Request

        private static async Task<List<T>> RequestData<T>(string requestString, CancellationToken cancellationToken = default, bool isList = true)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(requestString);
            if (isList)
            {
                var result = await client.ExecuteGetAsync<List<T>>(request, cancellationToken).ConfigureAwait(false);
                return result.Data;
            }
            else
            {
                var result = await client.ExecuteGetAsync<T>(request, cancellationToken).ConfigureAwait(false);
                return new List<T>(new T[] { result.Data });
            }
        }

        #endregion Generic JSON Request
    }
}
