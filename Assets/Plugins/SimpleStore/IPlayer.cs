﻿using System.Collections.Generic;

namespace Assets.Plugins.SimpleStore
{
    public interface IPlayer
    {
        decimal Coins { get; set; }
        ICollection<IStoreItem> Inventory { get; }
        void Wear(IStoreItem item);
        void TakeOff(IStoreItem item);
        bool IsWearing(IStoreItem item);
    }
}