using System;
using System.Collections.Generic;
using Plugins.SimpleStore;

namespace Models
{
    public class ArmorGenerator : IStoreItemGenerator
    {
        private readonly Random _random;
        public ArmorGenerator(Random random)
        {
            this._random = random;
        }
		public IEnumerable<IStoreItem> Generate()
		{
		    var armors = new List<Armor>
		    {
		        new Armor("Jacket", _random.Next(80,110), Rarity.Normal),
		        new Armor("Leather", _random.Next(400,600), Rarity.Normal),
                new Armor("Plate", _random.Next(800,900), Rarity.Rare)
            };
             
            return armors;
        }
    }
}
