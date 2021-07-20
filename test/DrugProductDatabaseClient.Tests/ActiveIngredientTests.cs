using DrugProductDatabase;
using System;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using Xunit.Abstractions;

namespace DrugProductDatabaseClient.Tests
{
    public class ActiveIngredientTests : TestBase
    {
        public ActiveIngredientTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public async Task Can_Get_ActiveIngredients()
        {
            var results = await DrugProductRequest.GetActiveIngredientsAsync(50446);

            Output.WriteLine(await GetJsonAsync(results));

            results.ShouldNotBeNull();
            results.Count.ShouldBe(2);
        }
    }
}
