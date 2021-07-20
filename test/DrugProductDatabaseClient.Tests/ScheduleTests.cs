using DrugProductDatabase;
using System;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using Xunit.Abstractions;

namespace DrugProductDatabaseClient.Tests
{
    public class ScheduleTests : TestBase
    {
        public ScheduleTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public async Task Can_Get_Schedule()
        {
            var result = await DrugProductRequest.GetSchedulesAsync(3875);

            Output.WriteLine(await GetJsonAsync(result));

            result.ShouldNotBeNull();
            result.ShouldHaveSingleItem();
            result[0].drug_code.ShouldBe(3875);
            result[0].schedule_name.ShouldNotBeNullOrEmpty();
        }
    }
}
