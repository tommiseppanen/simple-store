using System;

namespace Assets.Plugins.SimpleStore
{
    public interface IStoreItem  {
        int Level { get; }
        string Name { get; }
        string Description { get; }
        decimal Price { get; }
        string Image { get; }
    }
}
