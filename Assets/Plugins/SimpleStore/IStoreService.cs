using System.Collections.Generic;

namespace Assets.Plugins.SimpleStore
{
    public interface IStoreService
    {
        void SetItemPurchasePrices(IEnumerable<IStoreItem> items, decimal purchaseMargin);
        IEnumerable<IStoreItem> GenerateItems(decimal salesMargin);
        void Buy(IStoreItem item, ICollection<IStoreItem> storeItems, IPlayer player);
        void Sell(IStoreItem item, ICollection<IStoreItem> storeItems, IPlayer player);
    }
}