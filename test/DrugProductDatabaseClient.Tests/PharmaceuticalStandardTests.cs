using DrugProductDatabase;
using System;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using Xunit.Abstractions;

namespace DrugProductDatabaseClient.Tests
{
    public class PharmaceuticalStandardTests : TestBase
    {
        public PharmaceuticalStandardTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public async Task Can_Get_PharmaceuticalStandard()
        {
            // https://health-products.canada.ca/api/drug/pharmaceuticalstd/?type=json&id=3446

            var result = await DrugProductRequest.GetPharmaceuticalStandardAsync(3446);

            Output.WriteLine(await GetJsonAsync(result));

            result.ShouldNotBeNull();
            result.drug_code.ShouldBe(3446);
            result.pharmaceutical_std.ShouldNotBeNullOrEmpty();
        }
    }
}
