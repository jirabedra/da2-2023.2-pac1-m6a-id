using OrtdursGateDataAccess;
using OrtdursGateDomain;
using System.Runtime.CompilerServices;

namespace DataInitializer
{
    public class DataInitializer
    {

        private OrtdursContext ortdursContext;
        public DataInitializer(OrtdursContext ortdursContext)
        {
            this.ortdursContext = ortdursContext;
        }

        public void InitializeData()
        {

            Character character1 = new Character()
            {
                Name = "Santi",
                Level = 5
            };

            Character character2 = new Character()
            {
                Name = "Fran",
                Level = 1891
            };

            Character character3 = new Character()
            {
                Name = "Juan",
                Level = 3
            };

            Item item1 = new Item()
            {
                Name = "Sword",
                Type = OrtdursGateDomain.Type.Equipment
            };

            Item item2 = new Item()
            {
                Name = "Stronger sword than Santi's",
                Type = OrtdursGateDomain.Type.Consumable
            };

            character1.Inventory.Add(item1);
            character2.Inventory.Add(item2);

            ortdursContext.Characters.Add(character1);
            ortdursContext.Characters.Add(character2);
            ortdursContext.Characters.Add(character3);
            
            ortdursContext.Items.Add(item1);
            ortdursContext.Items.Add(item2);
            ortdursContext.SaveChanges();
        }
    }
}