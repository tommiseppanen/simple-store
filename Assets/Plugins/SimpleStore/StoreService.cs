using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Networking.NetworkSystem;

namespace Assets.Plugins.SimpleStore
{
    public class StoreService : IStoreService
    {
        private readonly List<IStoreItemGenerator> _generators;

        public StoreService(List<IStoreItemGenerator> generators)
        {
            _generators = generators;
        }

        public IEnumerable<IStoreItem> GenerateItems()
        {
            return _generators.SelectMany(g => g.Generate()).ToList();
        }

        public void Buy(IStoreItem item, ICollection<IStoreItem> storeItems, IPlayer player)
        {
            player.Coins -= item.Price;
            player.Inventory.Add(item);
            storeItems.Remove(item);
        }

        public void Sell(IStoreItem item, ICollection<IStoreItem> storeItems, IPlayer player)
        {
            throw new NotImplementedException();
        }
    }
}
