using System.Collections.Generic;

namespace Assets.Plugins.SimpleStore
{
    public interface IItemGenerator  {
        IEnumerable<Item> Generate();
    }
}
