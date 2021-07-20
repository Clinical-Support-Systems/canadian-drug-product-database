using DrugProductDatabase;
using System;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using Xunit.Abstractions;

namespace DrugProductDatabaseClient.Tests
{
    public class ProductStatusTests : TestBase
    {
        public ProductStatusTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public async Task Can_Get_ProductStatus()
        {
            // https://health-products.canada.ca/api/drug/status/?lang=en&type=json&id=11743

            var result = await DrugProductRequest.GetStatusAsync(11743);

            Output.WriteLine(await GetJsonAsync(result));

            result.ShouldNotBeNull();
            result.drug_code.ShouldBe(11743);
            result.status.ShouldNotBeNullOrEmpty();
            result.history_date.ShouldNotBeNull();
            result.history_date.ShouldBe(new DateTime(2019, 1, 28));
        }
    }
}
