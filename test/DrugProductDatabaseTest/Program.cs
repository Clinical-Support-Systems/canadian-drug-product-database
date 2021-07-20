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
            try
            {
                // Add this to your C# console app's Main method to give yourself
                // a CancellationToken that is canceled when the user hits Ctrl+C.
                var cts = new CancellationTokenSource();
                Console.CancelKeyPress += (s, e) =>
                {
                    Console.WriteLine("Canceling...");
                    cts.Cancel();
                    e.Cancel = true;
                };

                var drugProduct = await DrugProductRequest.GetDrugProduct(din: "02313782", cancellationToken: cts.Token).ConfigureAwait(false);

                var drugProduct2 = await DrugProductRequest.GetDrugProduct(drugCode: 11685, cancellationToken: cts.Token).ConfigureAwait(false);

                await Console.Out.WriteLineAsync("Done!");
            }
            catch (Exception ex)
            {
                await Console.Error.WriteLineAsync(ex.ToString());
            }
        }
    }
}
