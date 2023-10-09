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
            if (character == null)
            {
                throw new ArgumentException("Character invalid");
            }
            return _characterRepository.CreateCharacter(character);
            
        }

        public IEnumerable<Item> GetCharactersInventory(string name)
        {
            Character character = _characterRepository.GetCharacter(name);

            if (character != null)
            {
                return character.Inventory;
            }
            else
            {
                throw new InvalidOperationException($"Character with name '{name}' not found.");
            }
        }

        public Character UpdateInventory(string characterName, IEnumerable<Item> enumerable)
        {
            Character character = _characterRepository.GetCharacter(characterName);
            if (character != null)
            {
                return _characterRepository.UpdateInventory(characterName, enumerable);
            }
            else
            {
                throw new ArgumentException($"Character with name '{characterName}' not found.");
            }
        }
    }
}
