using Plugins.SimpleStore;

namespace Helpers
{
    public class PriceRounder : IPriceRounder
    {
        public decimal RoundPrice(decimal value)
        {
            return decimal.Truncate(value/10)*10+9;
        }
    }
}
