using System.Collections.Generic;

namespace Assets.Plugins.SimpleStore
{
    public interface IStoreService
    {
        IEnumerable<IStoreItem> GenerateItems();
        void Buy(IStoreItem item, ICollection<IStoreItem> storeItems, IPlayer player);
        void Sell(IStoreItem item, ICollection<IStoreItem> storeItems, IPlayer player);
    }
}