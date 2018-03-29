using System.Collections.Generic;

namespace Plugins.SimpleStore
{
    public interface IStoreService
    {
        ICollection<IStoreItem> Items { get; }
        void SetItemPurchasePrices(IEnumerable<IStoreItem> items);
        void Initialize(decimal salesMargin, decimal purchaseMargin);
        void Buy(IStoreItem item, IPlayer player);
        void Sell(IStoreItem item, IPlayer player);
    }
}