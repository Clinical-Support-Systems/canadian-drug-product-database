using DrugProductDatabase;
using System;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using Xunit.Abstractions;

namespace DrugProductDatabaseClient.Tests
{
    public class RouteOfAdministrationTests : TestBase
    {
        public RouteOfAdministrationTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public async Task Can_Get_RouteOfAdministration()
        {
            var result = await DrugProductRequest.GetRoutesOfAdministrationAsync(10);

            Output.WriteLine(await GetJsonAsync(result));

            result.ShouldNotBeNull();
            result.Count.ShouldBe(1);
            result[0].drug_code.ShouldBe(10);
            result[0].route_of_administration_code.ShouldBe(56);
            result[0].route_of_administration_name.ShouldNotBeNullOrEmpty();
        }
    }
}
