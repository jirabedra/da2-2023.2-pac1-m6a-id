using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrtdursGateDomain
{
    public class Character
    {
        public Guid CharacterId { get; set; } = new Guid();
        public string Name { get; set; }
        public int Level { get; set; }
        public virtual List<Item> Inventory { get; set; } = new List<Item>();
    }
}
