using Plugins.SimpleStore;

namespace Models
{
    public class Armor : GameItem
    {
		public int ArmorClass { get; }
        public override int Level => ArmorClass / 100;
        public override decimal Value => ((Level * Level)/10)*10+199;
        public override string Image => "armor";
        public override string Description => $"Armor class: {ArmorClass}";

        public Armor(string name, int armorClass, Rarity rarity) : base(name, rarity)
        {
            ArmorClass = armorClass;
        }
    }
}
