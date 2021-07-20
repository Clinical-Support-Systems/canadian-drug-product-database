using DrugProductDatabase;
using System;
using System.Threading.Tasks;
using Xunit;
using Shouldly;

namespace DrugProductDatabaseClient.Tests
{
    public class RouteOfAdministrationTests
    {
        [Fact]
        public async Task Test1()
        {
            var drugProduct = await DrugProductRequest.GetDrugProduct(din: "02313782");
            drugProduct.ShouldNotBeNull();
        }
    }
}
