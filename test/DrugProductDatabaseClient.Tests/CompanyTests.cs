using DrugProductDatabase;
using System;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using Xunit.Abstractions;

namespace DrugProductDatabaseClient.Tests
{
    public class CompanyTests : TestBase
    {
        public CompanyTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public async Task Can_Get_Company()
        {
            var result = await DrugProductRequest.GetCompanyAsync(12902);

            result.ShouldNotBeNull();
            result.company_name.ShouldBe("BAYER HEALTHCARE LLC");
            result.company_type.ShouldBe("DIN OWNER");
            result.country_name.ShouldBe("United States");
            result.post_office_box.ShouldBeEmpty();
            result.postal_code.ShouldNotBeEmpty();
            result.province_name.ShouldNotBeEmpty();
            result.street_name.ShouldNotBeEmpty();
            result.city_name.ShouldNotBeEmpty();
            result.suite_number.ShouldBeEmpty();
            result.company_code.ShouldBe(12902);

            Output.WriteLine(await GetJsonAsync(result));
        }
    }
}
