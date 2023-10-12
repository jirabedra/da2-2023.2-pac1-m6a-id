using DataInitializer;
using InventoryApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrtdursGateLogicInterface;

namespace InventoryApi.Controllers
{
    [Route("api/inventory")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private ICharacterLogic characterLogic;
        private DataInitializer.DataInitializer initializer;
        public InventoryController(ICharacterLogic characterLogic, DataInitializer.DataInitializer? dataInitializer)
        {
            if(dataInitializer is not null)
            {
                initializer = dataInitializer;
                initializer.InitializeData();
            }
            this.characterLogic = characterLogic;
        }

        [HttpGet("{characterName}")]
        public IActionResult GetCharacterInventory([FromRoute] string characterName)
        {
            return Ok(characterLogic.GetCharactersInventory(characterName));
        }

        [HttpPut("{characterName}")]
        public IActionResult UpdateInventory([FromRoute] string characterName, [FromBody] List<ItemModelIn> updatedInventory)
        {
            return Ok(characterLogic.UpdateInventory(characterName, updatedInventory.Select(i => i.ToEntity())));
        }

        [HttpPost]
        public IActionResult CreateCharacter([FromBody] CharacterModelIn character)
        {
            return Ok(characterLogic.CreateCharacter(character.ToEntity()));
        }

        public void InitializeData()
        {
            
        }
    }
}
