using System.Runtime.Serialization;
using Assets.Plugins.SimpleStore;

namespace Assets.Scripts
{
    public class Weapon : Item
    {
        public override int Level => Damage / 10;
        public override string Description => $"Damage class: {Damage}\nAttack speed: {AttackSpeed}";
        public int Damage { get; }
        public float AttackSpeed { get; }
        public Weapon(string name, int damage, float attackSpeed) : base(name)
        {
            Damage = damage;
            AttackSpeed = attackSpeed;
        }
    }
}
