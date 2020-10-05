using ChanceNET;

namespace WeightTrackerApi.Tests.ApiTests.ValidatorTests
{
    public abstract class ValidatorTestsBase
    {
        protected readonly Chance _chance;

        public ValidatorTestsBase()
        {
            _chance = new Chance();

        }
    }
}
