using OrtdursGateDomain;

namespace InventoryApi.Models
{
    public class CharacterModelIn
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public List<ItemModelIn> Inventory { get; set; }

        public Character ToEntity()
        {
            return new Character()
            {
                Name = Name,
                Level = Level,
                Inventory = Inventory.Select(x => x.ToEntity()).ToList()
            };
        }
    }
}
