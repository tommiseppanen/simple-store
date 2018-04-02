using Plugins.SimpleStore;

namespace Models
{
    public class Weapon : GameItem
    {
        public int Damage { get; }
        public float AttackSpeed { get; }

        public override int Level => Damage / 10;
        public override string Description => $"Damage: {Damage}\nAttack speed: {AttackSpeed}";
        public override decimal Value => Level*Level/10*10+99;      
        public override string Image => "sword";
        
        public Weapon(string name, int damage, float attackSpeed, Rarity rarity) : base(name, rarity)
        {
            Damage = damage;
            AttackSpeed = attackSpeed;
        }
    }
}
