namespace Plugins.SimpleStore
{
    public interface IStoreItem  {
        int Level { get; }
        string Name { get; }
        string Description { get; }
        decimal Value { get; }
        string Image { get; }

        decimal NormalPrice { get; set; }
        decimal DiscountedPrice { get; set; }
    }
}
