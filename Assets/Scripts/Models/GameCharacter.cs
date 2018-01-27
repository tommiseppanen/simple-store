using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models
{
    class GameCharacter
    {
        public Armor Armor { get; set; }
        public Weapon Weapon { get; set; }
        public IEnumerable<GameItem> Inventory { get; set; }
    }
}
