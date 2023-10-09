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

    }
}