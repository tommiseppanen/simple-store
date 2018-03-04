using System.Collections.Generic;

namespace Assets.Plugins.SimpleStore
{
    public interface IStoreService
    {
        ICollection<IStoreItem> Items { get; }
        void SetItemPurchasePrices(IEnumerable<IStoreItem> items, decimal purchaseMargin);
        void GenerateItems(decimal salesMargin);
        void Buy(IStoreItem item, IPlayer player);
        void Sell(IStoreItem item, IPlayer player);
    }
}