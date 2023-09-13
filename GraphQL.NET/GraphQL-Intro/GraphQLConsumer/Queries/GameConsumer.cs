using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQLConsumer.Inputs;
using GraphQLConsumer.Models;
using GraphQLConsumer.ResponseTypes;

namespace GraphQLConsumer.Queries
{
    public class GameConsumer
    {
        private readonly IGraphQLClient _client;
        public GameConsumer(IGraphQLClient client)
        {
            _client = client;
        }

        #region Queries

        public async Task<List<Game>> GetAllGames()
        {
            var query = new GraphQLRequest
            {
                Query = @"
                    query {
                        games {
                            id
                            title
                            platforms
                        }
                    }
                "
            };

            var response = await _client.SendQueryAsync<ResponseGameCollectionType>(query);
            return response.Data.Games;
        }

        public async Task<object> GetGame(string id)
        {
            var query = new GraphQLRequest
            {
                Query = @"
                    query gameQuery($id: ID!){
                        game(id: $id) {
                            id
                            title
                            platforms
                        }
                    }
                ",
                Variables = new { id = id }
            };

            var response = await _client.SendQueryAsync<ResponseGameType>(query);
            return response.Data.Game;
        }

        #endregion

        #region Mutations

        public async Task<Game> CreateGame(GameInput gameToCreate)
        {
            var query = new GraphQLRequest
            {
                Query = @"
                mutation($game: AddGameInput!){
                  addGame(game: $game){
                    id,
                    title,
                    platforms
                  }
                }",
                Variables = new { game = gameToCreate }
            };
            var response = await _client.SendMutationAsync<ResponseUpdateGameType>(query);
            return response.Data.UpdateGame;
        }

        public async Task<Game> UpdateGame(string id, GameInput gameToUpdate)
        {
            var query = new GraphQLRequest
            {
                Query = @"
                mutation($id: ID, $edits: EditGameInput!){
                  updateGame(id: $id, edits: $edits){
                    id,
                    title,
                    platforms
                  }
                }",
                Variables = new { id = id, edits = gameToUpdate }
            };

            var response = await _client.SendMutationAsync<ResponseUpdateGameType>(query);
            return response.Data.UpdateGame;
        }

        public async Task<List<Game>> DeleteGame(string id)
        {
            var query = new GraphQLRequest
            {
                Query = @"
                mutation($id: ID!){
                  deleteGame(id: $id){
                    id,
                    title,
                    platforms
                  }
                }",
                Variables = new { id = id }
            };

            var response = await _client.SendMutationAsync<ResponseDeleteGameType>(query);
            return response.Data.DeleteGame;
        }

        #endregion
    }
}
