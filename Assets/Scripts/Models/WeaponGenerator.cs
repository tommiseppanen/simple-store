using System;
using System.Collections.Generic;
using Assets.Plugins.SimpleStore;

namespace Assets.Scripts.Models
{
    public class WeaponGenerator : IItemGenerator
    {
        private readonly Random _random;
        public WeaponGenerator(Random random)
        {
            this._random = random;
        }
		public IEnumerable<Item> Generate()
		{
		    var armors = new List<Weapon>
		    {
		        new Weapon("Daggers", _random.Next(100,200), 0.3f),
		        new Weapon("Small sword", _random.Next(300,400), 0.5f),
                new Weapon("Sword", _random.Next(500,600), 0.6f)
            };
             
            return armors;
        }
    }
}
