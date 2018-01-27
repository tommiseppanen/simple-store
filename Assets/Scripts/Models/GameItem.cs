using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models
{
    public class GameItem
    {
        public string Name { get;  set; }

        public GameItem(string name)
        {
            Name = name;
        }
    }
}
