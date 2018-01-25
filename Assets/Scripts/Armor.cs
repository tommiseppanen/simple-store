using Assets.Plugins.SimpleStore;

namespace Assets.Scripts
{
    public class Armor : Item {
		public int ArmorClass { get; }
        public override int Level => ArmorClass / 100;
        public override string Description => $"Armor class: {ArmorClass}";

        public Armor(string name, int armorClass) : base(name)
        {
            ArmorClass = armorClass;
        }
    }
}
