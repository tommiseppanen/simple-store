using System.Collections.Generic;

namespace Assets.Plugins.SimpleStore
{
    public interface IStoreService
    {
        IEnumerable<IStoreItem> GenerateItems();
    }
}