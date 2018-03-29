using System.Collections.Generic;

namespace Plugins.SimpleStore
{
    public interface IStoreItemGenerator  {
        IEnumerable<IStoreItem> Generate();
    }
}
