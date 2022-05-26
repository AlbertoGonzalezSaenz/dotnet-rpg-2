using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg_2.Controllers
{
    [ApiController] // Adds api specific features 
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character { Id = 1, Name = "Sam"}
        };

        

        // GET

        [HttpGet("GetAll")] // combined http attribute and route attribute
        public ActionResult<List<Character>> Get()
        {
            return Ok(characters);
        }

        [HttpGet("{id}")]
        public ActionResult<Character> GetSingle(int id)
        {
            return Ok(characters.FirstOrDefault(c => c.Id == id));
        }

        //POST

        [HttpPost]
        public ActionResult<List<Character>> AddCharacter(Character newCharacter)
        {
            characters.Add(newCharacter);
            return Ok(characters);
        }
    }
}