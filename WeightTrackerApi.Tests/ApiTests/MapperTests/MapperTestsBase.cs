using ChanceNET;

namespace WeightTrackerApi.Tests.ApiTests.MapperTests
{
    public class MapperTestsBase
    {
        protected readonly Chance _chance;

        protected MapperTestsBase()
        {
            _chance = new Chance();
        }
    }
}
