using System.Collections.Generic;
using Plugins.SimpleStore;
using UniRx;

namespace Models
{
    public class Store : StoreService
    {
        public ReactiveCollection<IStoreItem> StoreItems { get; set; }

        public override ICollection<IStoreItem> Items => StoreItems;

        public Store(List<IStoreItemGenerator> generators, IPriceRounder rounder) : base(generators, rounder)
        {
            StoreItems = new ReactiveCollection<IStoreItem>();
            Initialize(1.15m, 0.8m);
        }
    }
}
