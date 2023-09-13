using GraphQLConsumer.Inputs;
using GraphQLConsumer.Models;
using GraphQLConsumer.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLConsumer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly GameConsumer _consumer;
        public GamesController(GameConsumer consumer)
        {
            _consumer = consumer;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var games = await _consumer.GetAllGames();
            return Ok(games);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            var game = await _consumer.GetGame(id);
            return Ok(game);
        }

        [HttpPost]
        public async Task<Game> Create([FromBody] GameInput gameToCreate)
        {
            var game = await _consumer.CreateGame(gameToCreate);
            return game;
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<Game> Update(string id, [FromBody] GameInput gameToUpdate)
        {
            var game = await _consumer.UpdateGame(id, gameToUpdate);
            return game;
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<List<Game>> Delete(string id)
        {
            var games = await _consumer.DeleteGame(id);
            return games;
        }
    }
}
