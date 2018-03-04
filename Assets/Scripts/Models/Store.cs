using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Plugins.SimpleStore;
using UniRx;

namespace Assets.Scripts.Models
{
    public class Store : StoreService
    {
        public ReactiveCollection<IStoreItem> StoreItems { get; set; }

        public override ICollection<IStoreItem> Items => StoreItems;

        public Store(List<IStoreItemGenerator> generators) : base(generators)
        {
            StoreItems = new ReactiveCollection<IStoreItem>();
            GenerateItems(1.15m);
        }
    }
}
