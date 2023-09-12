using GraphQL_GamesReviewsAuthors.GraphQL.Inputs;
using GraphQL_GamesReviewsAuthors.Models;

namespace GraphQL_GamesReviewsAuthors.Repositories
{
    public class GameRepository : IGameRepository
    {
        private static List<Game> _games = new List<Game>
        {
            new Game
            {
                Id = "1",
                Title = "The Legend of Zelda: Breath of the Wild",
                Platforms = new List<string> { "Nintendo Switch", "Wii U" },
            },
            new Game
            {
                Id = "2",
                Title = "Super Mario Odyssey",
                Platforms = new List<string> { "Nintendo Switch", "XBox" },
            },
            new Game
            {
                Id = "3",
                Title = "The Witcher 3: Wild Hunt",
                Platforms = new List<string> { "XBox", "PS5" },
            },
            new Game
            {
                Id = "4",
                Title = "Final Fantasy 7",
                Platforms = new List<string> { "XBox", "PS5" },
            },
            new Game
            {
                Id = "5",
                Title = "Pokemon Scarlet",
                Platforms = new List<string> { "XBox", "PS5", "Nintendo Switch" },
            }
        };

        public async Task<Game> AddGame(AddGameInput input)
        {
            var rnd = new Random();
            var id = rnd.Next(1000, 9999).ToString();
            var game = new Game
            {
                Id = id,
                Title = input.Title,
                Platforms = input.Platforms
            };
            _games.Add(game);

            return game;
        }

        public async Task<List<Game>> DeleteGame(string id)
        {
            _games.RemoveAll(g => g.Id == id);
            return await Task.FromResult(_games);
        }

        public async Task<Game> GetGame(string id)
        {
            return await Task.FromResult(_games.FirstOrDefault(g => g.Id == id));
        }

        public async Task<List<Game>> GetGames()
        {
            return await Task.FromResult(_games);
        }

        public async Task<Game> UpdateGame(string id, EditGameInput input)
        {
            Game game = new Game();
            foreach(var gm in _games)
            {
                if(gm.Id == id)
                {
                    gm.Title = input.Title ?? gm.Title;
                    gm.Platforms = input.Platforms ?? gm.Platforms;
                    game = gm;
                    break;
                }
            }
            return await Task.FromResult(game);
        }


    }
}
