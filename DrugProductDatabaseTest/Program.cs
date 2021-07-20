using DrugProductDatabase;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DrugProductDatabaseTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // try getting a drug product
            await theCode().ConfigureAwait(false);
        }


        public static async Task theCode(CancellationToken ct = default)
        {
            var drugProduct = await DrugProductRequest.GetDrugProduct(din: "02313782", cancellationToken: ct).ConfigureAwait(false);

            var drugProduct2 = await DrugProductRequest.GetDrugProduct(drugCode: 11685, cancellationToken: ct).ConfigureAwait(false);

            var x = 0;
        }
    }
}
