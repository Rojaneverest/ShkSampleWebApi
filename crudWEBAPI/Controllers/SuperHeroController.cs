using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace crudWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<superHero> heros = new List<superHero>()
        {
            new superHero
            {
                Id = 1, Name = "Spiderman", firstName = "Peter", lastName = "parker", place = "Queens"
            },
            new superHero
            {
                Id = 2, Name = "IronMan", firstName = "Tony", lastName = "Stark", place = "New York"
            }
        };

        [HttpGet]
        public async Task<ActionResult<List<superHero>>> Get()
        {

            return Ok(heros);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<superHero>>> GetSingle(int id)
        {
            var hero = heros.Find(h => h.Id == id);
            if (hero == null)
            {
                return BadRequest("Hero not found");
            }
            return Ok(hero);
        }
        //[HttpPost]
        //public async Task<ActionResult<string>> Create([FromBody] string data)
        //{
        //    data = data + "changed data";
        //    return Ok(data);
        //}
        [HttpPost]
        public async Task<ActionResult<List<superHero>>> addHero(superHero hero)
        {
            heros.Add(hero);
            return Ok(heros);
        }

        [HttpPut]
        public async Task<ActionResult<List<superHero>>> changeHero(superHero req)
        {
            var hero = heros.Find(h => h.Id == req.Id);
            if (hero == null)
            {
                return BadRequest("Hero not found");
            }

            hero.Name = req.Name;
            hero.firstName = req.firstName;
            hero.lastName = req.lastName;
            hero.place = req.place;
            //heros.Add(req);
            return Ok(heros);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<superHero>>> deleteHero(int id)
        {
            var hero = heros.Find(h => h.Id == id);
            if (hero == null)
            {
                return BadRequest("Hero not found");
            }
            heros.Remove(hero);
            return Ok(heros);
        }
    }
}

