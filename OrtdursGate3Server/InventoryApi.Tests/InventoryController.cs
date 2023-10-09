using InventoryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OrtdursGateDomain;
using OrtdursGateLogicInterface;
using Type = OrtdursGateDomain.Type;
namespace InventoryApi.Tests
{
    [TestClass]
    public class InventoryController
    {
        [TestMethod]
        public void TestGetCharacterInventory()
        {
            string characterName = "TestCharacter";
            List<Item> inventory = new List<Item>
            {
                new Item { Id = Guid.NewGuid(), Name = "Sword", Type = Type.Equipment },
                new Item { Id = Guid.NewGuid(), Name = "Shield", Type = Type.Equipment }
            };

            var characterLogicMock = new Mock<ICharacterLogic>();
            characterLogicMock.Setup(cl => cl.GetCharactersInventory(characterName)).Returns(inventory);
            var controller = new InventoryController(characterLogicMock.Object, null);
            var result = controller.GetCharacterInventory(characterName) as OkObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(inventory, result.Value);
        }

        [TestMethod]
        public void TestCreateCharacter()
        {
            var characterModelIn = new CharacterModelIn
            {
                Name = "TestCharacter",
                Level = 10,
                Inventory = new List<ItemModelIn>
                {
                    new ItemModelIn { Name = "Sword", Type = 1 },
                    new ItemModelIn { Name = "Shield", Type = 1 }
                }
            };

            var character = characterModelIn.ToEntity();

            var characterLogicMock = new Mock<ICharacterLogic>();
            characterLogicMock.Setup(cl => cl.CreateCharacter(character)).Returns(new Character());

            var controller = new InventoryController(characterLogicMock.Object, null);
            var result = controller.CreateCharacter(characterModelIn) as OkObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.IsInstanceOfType(result.Value, typeof(Character));
        }

        [TestMethod]
        public void TestUpdateInventory()
        {
            string characterName = "TestCharacter";
            var updatedInventory = new List<ItemModelIn>
            {
                new ItemModelIn { Name = "Staff", Type = 2 },
                new ItemModelIn { Name = "Potion", Type = 0 }
            };
            var characterLogicMock = new Mock<ICharacterLogic>();
            characterLogicMock.Setup(cl => cl.UpdateInventory(characterName, It.IsAny<IEnumerable<Item>>()))
                .Returns(new Character { Inventory = new List<Item>() });
            var controller = new InventoryController(characterLogicMock.Object, null);
            var result = controller.UpdateInventory(characterName, updatedInventory) as OkObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.IsInstanceOfType(result.Value, typeof(Character));
        }
    }
}
