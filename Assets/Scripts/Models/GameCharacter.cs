﻿using System;
using System.Collections.Generic;
using Plugins.SimpleStore;
using UniRx;

namespace Models
{
    public class GameCharacter : IPlayer
    {
        public GameCharacter()
        {
            PlayerCoins = new ReactiveProperty<decimal>(5000);
            PlayerInventory = new ReactiveCollection<IStoreItem>();
            Armor = new ReactiveProperty<Armor>();
            Weapon = new ReactiveProperty<Weapon>();
        }

        public ReactiveProperty<Armor> Armor { get; set; }
        public ReactiveProperty<Weapon> Weapon { get; set; }
        public ReactiveCollection<IStoreItem> PlayerInventory { get; private set; }
        public ReactiveProperty<decimal> PlayerCoins { get; private set; }

        public decimal Coins
        {
            get { return PlayerCoins.Value; }
            set { PlayerCoins.Value = value; }
        }
        public ICollection<IStoreItem> Inventory => PlayerInventory;

        public void Wear(IStoreItem item)
        {
            if (item is Armor)
                Armor.Value = item as Armor;
            else if (item is Weapon)
                Weapon.Value = item as Weapon;
        }

        public void TakeOff(IStoreItem item)
        {
            if (Armor.Value == item)
                Armor.Value = null;
            else if (Weapon.Value == item)
                Weapon.Value = null;
        }

        public IObservable<IStoreItem> WearedItem => 
            Weapon.AsObservable<IStoreItem>().Merge(Armor.AsObservable());

        public bool IsWearing(IStoreItem item) => 
            Armor.Value == item || Weapon.Value == item;
    }
}
