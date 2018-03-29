using Plugins.SimpleStore;

namespace Models
{
    public abstract class GameItem : IStoreItem
    {
        public string Name { get; set; }
        public decimal NormalPrice { get; set; }
        public decimal DiscountedPrice { get; set; }

        public virtual int Level { get; }
        public virtual string Description { get; }
        public virtual decimal Value { get; }
        public virtual string Image { get; }


        public GameItem(string name)
        {
            Name = name;
        }
    }
}
