using Moq;
using OrtdursGateDataAccessInterface;
using OrtdursGateDomain;
using OrtdursGateLogicInterface;

namespace OrtdursGateLogic.Tests
{
    [TestClass]
    public class CharacterLogicTests
    {
        [TestMethod]
        public void CreateCharacter_ValidCharacter()
        {
            var characterRepositoryMock = new Mock<ICharacterRepository>();
            var characterLogic = new CharacterLogic(characterRepositoryMock.Object);
            var validCharacter = new Character
            {
                CharacterId = Guid.NewGuid(),
                Name = "TestCharacter",
                Level = 10,
                Inventory = new List<Item>
                {
                    new Item { Id = Guid.NewGuid(), Name = "Sword", Type = OrtdursGateDomain.Type.Equipment },
                    new Item { Id = Guid.NewGuid(), Name = "Shield", Type = OrtdursGateDomain.Type.Equipment }
                }
            };

            characterRepositoryMock.Setup(repo => repo.CreateCharacter(validCharacter))
                .Returns(validCharacter);

            var createdCharacter = characterLogic.CreateCharacter(validCharacter);

            Assert.IsNotNull(createdCharacter);
            Assert.AreEqual(validCharacter.CharacterId, createdCharacter.CharacterId);
            Assert.AreEqual(validCharacter.Name, createdCharacter.Name);
            Assert.AreEqual(validCharacter.Level, createdCharacter.Level);
            Assert.AreEqual(validCharacter.Inventory.Count, createdCharacter.Inventory.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateCharacter_Invalid()
        {
            var characterRepositoryMock = new Mock<ICharacterRepository>();
            var characterLogic = new CharacterLogic(characterRepositoryMock.Object);
            var createdCharacter = characterLogic.CreateCharacter(null);
            Assert.IsNotNull(createdCharacter);
        }

        [TestMethod]
        public void GetAllCharacterInventory_Vaid()
        {
            var characterRepositoryMock = new Mock<ICharacterRepository>();
            var characterLogic = new CharacterLogic(characterRepositoryMock.Object);
            var characterName = "TestCharacter";
            var character = new Character
            {
                CharacterId = Guid.NewGuid(),
                Name = characterName,
                Level = 10,
                Inventory = new List<Item>
                {
                    new Item { Id = Guid.NewGuid(), Name = "Sword", Type = OrtdursGateDomain.Type.Equipment },
                    new Item { Id = Guid.NewGuid(), Name = "Sword", Type = OrtdursGateDomain.Type.Equipment },
                }
            };

            characterRepositoryMock.Setup(repo => repo.GetCharacter(characterName))
                .Returns(character);
            var inventory = characterLogic.GetCharactersInventory(characterName);
            Assert.IsNotNull(inventory);
            Assert.AreEqual(character.Inventory.Count, inventory.Count());
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetCharactersInventory_Invaid()
        {
            var characterRepositoryMock = new Mock<ICharacterRepository>();
            var characterLogic = new CharacterLogic(characterRepositoryMock.Object);

            var invalidCharacterName = "NonExistentCharacter";

            characterRepositoryMock.Setup(repo => repo.GetCharacter(invalidCharacterName))
                .Returns((Character)null);

            var inventory = characterLogic.GetCharactersInventory(invalidCharacterName);

        }

        [TestMethod]
        public void UpdateInventory_Valid()
        {
            var characterRepositoryMock = new Mock<ICharacterRepository>();
            var characterLogic = new CharacterLogic(characterRepositoryMock.Object);

            var characterName = "TestCharacter";
            var character = new Character
            {
                CharacterId = Guid.NewGuid(),
                Name = characterName,
                Level = 10,
                Inventory = new List<Item>
                {
                    new Item { Id = Guid.NewGuid(), Name = "Sword", Type = OrtdursGateDomain.Type.Equipment },
                    new Item { Id = Guid.NewGuid(), Name = "Shield", Type = OrtdursGateDomain.Type.Equipment }
                }
            };

            characterRepositoryMock.Setup(repo => repo.GetCharacter(characterName))
                .Returns(character);

            var updatedInventory = new List<Item>
            {
                new Item { Id = Guid.NewGuid(), Name = "Staff", Type = OrtdursGateDomain.Type.Equipment },
                new Item { Id = Guid.NewGuid(), Name = "Potion", Type = OrtdursGateDomain.Type.Consumable }
            };

            characterRepositoryMock.Setup(repo => repo.UpdateInventory(characterName, updatedInventory))
                .Returns(character);
            var updatedCharacter = characterLogic.UpdateInventory(characterName, updatedInventory);
            Assert.IsNotNull(updatedCharacter);
            Assert.AreEqual(character.Inventory.Count, updatedInventory.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateInventory_Invalid()
        {

            Assert.IsNotNull(null);
        }

    }
}