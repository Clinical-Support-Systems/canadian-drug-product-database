using DrugProductDatabase;
using System;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using Xunit.Abstractions;

namespace DrugProductDatabaseClient.Tests
{
    public class PackagingTests : TestBase
    {
        public PackagingTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public async Task Can_Get_Packaging()
        {
            var result = await DrugProductRequest.GetPackagingAsync(37475);

            Output.WriteLine(await GetJsonAsync(result));

            result.ShouldNotBeNull();
            result.ShouldHaveSingleItem();
            result[0].drug_code.ShouldBe(37475);
            result[0].upc.ShouldNotBeNullOrEmpty();
            result[0].package_size_unit.ShouldNotBeNullOrEmpty();
            result[0].package_type.ShouldNotBeNullOrEmpty();
            result[0].package_size.ShouldNotBeNullOrEmpty();
            result[0].product_information.ShouldBeEmpty();
        }
    }
}
