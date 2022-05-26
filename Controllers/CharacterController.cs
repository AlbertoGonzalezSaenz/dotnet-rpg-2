using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg_2.Models;
using dotnet_rpg_2.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg_2.Controllers
{
    [ApiController] // Adds api specific features 
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        public ICharacterService _characterService { get; }

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
            
        }

        // GET

        [HttpGet("GetAll")] // combined http attribute and route attribute
        public async Task<ActionResult<List<Character>>> Get()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetSingle(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }

        //POST

        [HttpPost]
        public async Task<ActionResult<List<Character>>> AddCharacter(Character newCharacter)
        {
           return Ok(await _characterService.AddCharacter(newCharacter));
            
        }
    }
}