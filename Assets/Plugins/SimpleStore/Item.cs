﻿namespace Assets.Plugins.SimpleStore
{
    public abstract class Item  {
        public abstract int Level { get; }
        public virtual string Name { get; private set; }
        public abstract string Description { get; }

        protected Item(string name)
        {
            Name = name;
        }
    }
}
