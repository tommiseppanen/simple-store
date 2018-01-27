using System.Collections.Generic;

namespace Assets.Plugins.SimpleStore
{
    public interface IStoreItemGenerator  {
        IEnumerable<IStoreItem> Generate();
    }
}
