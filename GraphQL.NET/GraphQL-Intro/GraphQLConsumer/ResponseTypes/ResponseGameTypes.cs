using GraphQLConsumer.Models;

namespace GraphQLConsumer.ResponseTypes
{
    public class ResponseGameCollectionType
    {
        public List<Game> Games { get; set; }
    }

    public class ResponseGameType
    {
        public Game Game { get; set; }
    }

    public class ResponseAddGameType
    {
        public Game AddGame { get; set; }
    }

    public class ResponseUpdateGameType
    {
        public Game UpdateGame { get; set; }
    }

    public class ResponseDeleteGameType
    {
        public List<Game> DeleteGame { get; set; }
    }
}
