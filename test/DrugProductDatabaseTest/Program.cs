using DrugProductDatabase;
using System;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace DrugProductDatabaseConsoleApp
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

                async Task<string> GetJsonAsync(object obj, JsonSerializerOptions jsonSerializerOptions = null, CancellationToken ct = default)
                {
                    ct.ThrowIfCancellationRequested();
                    using var stream = new MemoryStream();
                    await JsonSerializer.SerializeAsync(stream, obj, obj.GetType(), jsonSerializerOptions ?? new JsonSerializerOptions() { WriteIndented = true }, ct).ConfigureAwait(false);
                    stream.Position = 0;
                    using var reader = new StreamReader(stream);
                    return await reader.ReadToEndAsync().ConfigureAwait(false);
                }

                var drugProduct = await DrugProductRequest.GetDrugProduct(din: "02313782", cancellationToken: cts.Token).ConfigureAwait(false);

                await Console.Out.WriteLineAsync(await GetJsonAsync(drugProduct, ct: cts.Token));

                var drugProduct2 = await DrugProductRequest.GetDrugProduct(drugCode: 11685, cancellationToken: cts.Token).ConfigureAwait(false);

                await Console.Out.WriteLineAsync(await GetJsonAsync(drugProduct2, ct: cts.Token));

                await Console.Out.WriteLineAsync("Done!");
            }
            catch (Exception ex)
            {
                await Console.Error.WriteLineAsync(ex.ToString());
            }
        }
    }
}
