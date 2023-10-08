using OrtdursGateDataAccessInterface;
using OrtdursGateDomain;
using OrtdursGateLogicInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrtdursGateLogic
{
    public class CharacterLogic : ICharacterLogic
    {
        ICharacterRepository _characterRepository;

        public CharacterLogic(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public Character CreateCharacter(Character character)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetCharactersInventory(string name)
        {
            throw new NotImplementedException();
        }

        public Character UpdateInventory(string characterName, IEnumerable<Item> enumerable)
        {
            throw new NotImplementedException();
        }
    }
}
