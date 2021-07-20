using DrugProductDatabase;
using System;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using Xunit.Abstractions;

namespace DrugProductDatabaseClient.Tests
{
    public class DosageFormTests : TestBase
    {
        public DosageFormTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public async Task Can_Get_DosageForm()
        {
            var result = await DrugProductRequest.GetDosageFormsAsync(4292);

            result.ShouldNotBeNull();
            result.ShouldHaveSingleItem();
            result[0].drug_code.ShouldBe(4292);
            result[0].pharmaceutical_form_code.ShouldBe(134);
            result[0].pharmaceutical_form_name.ShouldNotBeEmpty();

            Output.WriteLine(await GetJsonAsync(result));
        }
    }
}
