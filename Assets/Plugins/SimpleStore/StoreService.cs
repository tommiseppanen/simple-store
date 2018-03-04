using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModestTree;
using UnityEngine.Networking.NetworkSystem;

namespace Assets.Plugins.SimpleStore
{
    public class StoreService : IStoreService
    {
        private readonly List<IStoreItemGenerator> _generators;

        public virtual ICollection<IStoreItem> Items { get; }

        public StoreService(List<IStoreItemGenerator> generators)
        {
            _generators = generators;
        }

        public void GenerateItems(decimal salesMargin)
        {
            var items = _generators.SelectMany(g => g.Generate()).ToList();
            items.ForEach(i => i.NormalPrice = i.Value * salesMargin);
            items.ForEach(i => Items.Add(i));
        }

        public void SetItemPurchasePrices(IEnumerable<IStoreItem> items, decimal purchaseMargin)
        {
            items.ForEach(i => i.NormalPrice = i.Value * purchaseMargin);
        }

        public void Buy(IStoreItem item, IPlayer player)
        {
            player.Coins -= item.Value;
            player.Inventory.Add(item);
            Items.Remove(item);
        }

        public void Sell(IStoreItem item, IPlayer player)
        {
            player.Coins += item.Value;
            player.Inventory.Remove(item);
            Items.Add(item);
        }
    }
}
