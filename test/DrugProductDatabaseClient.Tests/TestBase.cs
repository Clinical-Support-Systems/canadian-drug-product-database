using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace DrugProductDatabaseClient.Tests
{
    public class TestBase
    {
        private readonly ITestOutputHelper _output;

        public TestBase(ITestOutputHelper output)
        {
            _output = output;
        }

        public ITestOutputHelper Output => _output;

        public async Task<string> GetJsonAsync(object obj, JsonSerializerOptions jsonSerializerOptions = null, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();
            using var stream = new MemoryStream();
            await JsonSerializer.SerializeAsync(stream, obj, obj.GetType(), jsonSerializerOptions ?? new JsonSerializerOptions() { WriteIndented = true }, ct).ConfigureAwait(false);
            stream.Position = 0;
            using var reader = new StreamReader(stream);
            return await reader.ReadToEndAsync().ConfigureAwait(false);
        }
    }
}
