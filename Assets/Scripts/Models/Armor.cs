using Assets.Plugins.SimpleStore;

namespace Assets.Scripts.Models
{
    public class Armor : GameItem, IStoreItem
    {
		public int ArmorClass { get; }
        public int Level => ArmorClass / 100;
        public decimal Price => ((Level * Level)/10)*10+199;
        public string Image => "armor";
        public string Description => $"Armor class: {ArmorClass}";

        public Armor(string name, int armorClass) : base(name)
        {
            ArmorClass = armorClass;
        }
    }
}
