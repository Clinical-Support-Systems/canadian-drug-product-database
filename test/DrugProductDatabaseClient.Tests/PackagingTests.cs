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
        public async Task Test1()
        {
            var drugProduct = await DrugProductRequest.GetDrugProduct(din: "02313782");
            drugProduct.ShouldNotBeNull();
        }
    }
}
