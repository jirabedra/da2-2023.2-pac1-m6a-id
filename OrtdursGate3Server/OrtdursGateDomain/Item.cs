using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrtdursGateDomain
{

    public enum Type
    {
        Consumable,
        Equipment,
        Misc
    }

    public class Item
    {
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; }
        public Type Type { get; set; } 
    }
}
