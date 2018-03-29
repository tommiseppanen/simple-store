using System.Collections.Generic;
using System.Linq;
using ModestTree;

namespace Plugins.SimpleStore
{
    public class StoreService : IStoreService
    {
        private readonly List<IStoreItemGenerator> _generators;
        private readonly IPriceRounder _rounder;

        public virtual ICollection<IStoreItem> Items { get; }

        private decimal _salesMargin;
        private decimal _purchaseMargin;

        public StoreService(List<IStoreItemGenerator> generators, IPriceRounder rounder)
        {
            _generators = generators;
            _rounder = rounder;
        }

        public void Initialize(decimal salesMargin, decimal purchaseMargin)
        {
            _salesMargin = salesMargin;
            _purchaseMargin = purchaseMargin;

            var items = _generators.SelectMany(g => g.Generate()).ToList();
            items.ForEach(i => i.NormalPrice = CalculatePrice(i.Value, salesMargin));
            items.ForEach(i => Items.Add(i));
        }

        public void SetItemPurchasePrices(IEnumerable<IStoreItem> items)
        {
            items.ForEach(i => i.NormalPrice = CalculatePrice(i.Value, _purchaseMargin));
        }

        public void Buy(IStoreItem item, IPlayer player)
        {
            player.Coins -= item.NormalPrice;
            item.NormalPrice = CalculatePrice(item.Value, _purchaseMargin);
            player.Inventory.Add(item);
            Items.Remove(item);
        }

        public void Sell(IStoreItem item, IPlayer player)
        {
            player.Coins += item.NormalPrice;
            player.TakeOff(item);
            player.Inventory.Remove(item);
            item.NormalPrice = CalculatePrice(item.Value, _salesMargin);
            Items.Add(item);
        }

        private decimal CalculatePrice(decimal itemValue, decimal margin)
        {
            return _rounder.RoundPrice(itemValue * margin);
        }
    }
}
