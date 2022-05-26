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
        public ActionResult<List<Character>> Get()
        {
            return Ok(_characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public ActionResult<Character> GetSingle(int id)
        {
            return Ok(_characterService.GetCharacterById(id));
        }

        //POST

        [HttpPost]
        public ActionResult<List<Character>> AddCharacter(Character newCharacter)
        {
           return _characterService.AddCharacter(newCharacter);
            
        }
    }
}