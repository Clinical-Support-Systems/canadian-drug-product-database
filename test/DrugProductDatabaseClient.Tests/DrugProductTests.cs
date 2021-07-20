using DrugProductDatabase;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace DrugProductDatabaseClient.Tests
{
    public class DrugProductTests : TestBase
    {
        public DrugProductTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public async Task Can_Get_DrugProduct()
        {
            var result = await DrugProductRequest.GetDrugProduct(din: "02247087");

            Output.WriteLine(await GetJsonAsync(result));

            result.ShouldNotBeNull();
            result.drug_identification_number.ShouldBe("02247087");
            result.active_ingredients.Count.ShouldBe(result.number_of_ais.GetValueOrDefault(0));

            var result2 = await DrugProductRequest.GetDrugProduct(drugCode: result.drug_code);
            result2.ShouldNotBeNull();
            result2.drug_identification_number.ShouldBe("02247087");
            result2.active_ingredients.Count.ShouldBe(result.number_of_ais.GetValueOrDefault(0));
        }
    }
}
