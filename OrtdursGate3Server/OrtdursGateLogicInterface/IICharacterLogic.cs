using OrtdursGateDomain;

namespace OrtdursGateLogicInterface
{
    public interface ICharacterLogic
    {
        Character CreateCharacter(Character character);
        IEnumerable<Item> GetCharactersInventory(string name);
        Character UpdateInventory(string characterName, IEnumerable<Item> enumerable);
    }
}
