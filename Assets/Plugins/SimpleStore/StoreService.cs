using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
