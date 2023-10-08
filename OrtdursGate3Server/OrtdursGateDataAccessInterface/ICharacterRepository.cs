using OrtdursGateDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrtdursGateDataAccessInterface
{
    public interface ICharacterRepository
    {
        Character CreateCharacter(Character character);
        Character GetCharacter(string name);
        Character UpdateInventory(string characterName, IEnumerable<Item> items);
    }
}
