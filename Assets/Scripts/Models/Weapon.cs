using System.Runtime.Serialization;
using Assets.Plugins.SimpleStore;

namespace Assets.Scripts.Models
{
    public class Weapon : GameItem, IStoreItem
    {
        public int Level => Damage / 10;
        public string Description => $"Damage: {Damage}\nAttack speed: {AttackSpeed}";
        public decimal Price => Level*Level+99;
        public int Damage { get; }
        public float AttackSpeed { get; }
        public Weapon(string name, int damage, float attackSpeed) : base(name)
        {
            Damage = damage;
            AttackSpeed = attackSpeed;
        }
    }
}
