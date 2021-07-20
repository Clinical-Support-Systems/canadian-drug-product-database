using DrugProductDatabase;
using System;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using Xunit.Abstractions;

namespace DrugProductDatabaseClient.Tests
{
    public class TheraputicClassTests : TestBase
    {
        public TheraputicClassTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public async Task Can_Get_TherapeuticClasses()
        {
            var result = await DrugProductRequest.GetTherapeuticClassesAsync(7397);

            Output.WriteLine(await GetJsonAsync(result));

            result.ShouldNotBeNull();
            result.ShouldHaveSingleItem();
            result[0].drug_code.ShouldBe(7397);
            result[0].tc_atc_number.ShouldNotBeNullOrEmpty();
            result[0].tc_atc.ShouldNotBeNullOrEmpty();
            result[0].tc_ahfs_number.ShouldNotBeNullOrEmpty();
            result[0].tc_ahfs.ShouldNotBeNullOrEmpty();
        }
    }
}
