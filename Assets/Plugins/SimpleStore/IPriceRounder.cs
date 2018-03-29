namespace Plugins.SimpleStore
{
    public interface IPriceRounder
    {
        decimal RoundPrice(decimal value);
    }
}