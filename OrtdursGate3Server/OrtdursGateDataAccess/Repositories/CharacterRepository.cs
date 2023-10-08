using Microsoft.EntityFrameworkCore;
using OrtdursGateDataAccessInterface;
using OrtdursGateDomain;

namespace OrtdursGateDataAccess.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private OrtdursContext _context;

        public CharacterRepository(OrtdursContext ortdursContext)
        {
            _context = ortdursContext;
        }

        public Character CreateCharacter(Character character)
        {
            _context.Characters.Add(character);
            _context.SaveChanges();
            return character;
        }

        public Character GetCharacter(string name)
        {
            try
            {
                Character found = _context.Characters.Where(x => x.Name.ToLower().Equals(name.ToLower())).Include(c => c.Inventory).FirstOrDefault();
                if (found != null)
                {
                    return found;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentException($"Character {name} could not be retrieved.", ex);
            }
        }

        public Character UpdateInventory(string characterName, IEnumerable<Item> items)
        {
            try
            {
                var found = _context.Characters.Where(x => x.Name.ToLower().Equals(characterName.ToLower())).Include(c => c.Inventory).FirstOrDefault(); ;
                if (found != null)
                {
                    found.Inventory.AddRange(items.ToList());
                    _context.Characters.Entry(found).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                    return found;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentException($"Invalid {characterName}.", ex);
            }
        }
    }
}
