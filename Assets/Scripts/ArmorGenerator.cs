using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Plugins.SimpleStore;

namespace Assets.Scripts
{
    public class ArmorGenerator : IItemGenerator
    {
        private readonly Random _random;
        public ArmorGenerator(Random random)
        {
            this._random = random;
        }
		public Item Generate(int level)
		{
		    var armors = new List<Armor>
		    {
		        new Armor("Jacket", _random.Next(80,110)),
		        new Armor("Leather", _random.Next(400,600)),
                new Armor("Plate", _random.Next(800,900))
            };
             

            return armors.First();


        }
    }
}
