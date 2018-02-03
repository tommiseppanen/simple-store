﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Plugins.SimpleStore;
using UniRx;

namespace Assets.Scripts.Models
{


    public class Test
    {
        //decimal Coins { get; set; }
        //private ICollection<IStoreItem> Inventory { get; set; }
        public decimal Coins { get; set; }

        public virtual ICollection<IStoreItem> Inventory { get; }
    }

    public class GameCharacter : IPlayer
    {
        public GameCharacter()
        {
            PlayerCoins = new ReactiveProperty<decimal>(0);
            PlayerInventory = new ReactiveCollection<IStoreItem>();
        }

        public Armor Armor { get; set; }
        public Weapon Weapon { get; set; }
        public ReactiveCollection<IStoreItem> PlayerInventory { get; private set; }
        public ReactiveProperty<decimal> PlayerCoins { get; private set; }

        public decimal Coins
        {
            get { return PlayerCoins.Value; }
            set { PlayerCoins.Value = value; }
        }
        public ICollection<IStoreItem> Inventory => PlayerInventory;
    }
}
