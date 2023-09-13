import { ApolloServer } from '@apollo/server';
import { startStandaloneServer } from '@apollo/server/standalone';
// types.
// import { typeDefs } from './schema'
// import {db} from './_db'
// The data.
const books = [
    {
        title: 'The Awakening',
        author: 'Kate Chopin',
    },
    {
        title: 'City of Glass',
        author: 'Paul Auster',
    },
];
let games = [
    { id: '1', title: 'Zelda, Tears of the Kingdom', platforms: ['Switch'] },
    { id: '2', title: 'Final Fantasy 7 Remake', platforms: ['PS5', 'Xbox'] },
    { id: '3', title: 'Elden Ring', platforms: ['PS5', 'Xbox', 'PC'] },
    { id: '4', title: 'Mario Kart', platforms: ['Switch'] },
    { id: '5', title: 'Pokemon Scarlet', platforms: ['PS5', 'Xbox', 'PC'] },
];
let authors = [
    { id: '1', name: 'mario', verified: true },
    { id: '2', name: 'yoshi', verified: false },
    { id: '3', name: 'peach', verified: true },
];
let reviews = [
    { id: '1', rating: 9, content: 'lorem_ipsum', author_id: '1', game_id: '2' },
    { id: '2', rating: 10, content: 'lorem_ipsum', author_id: '2', game_id: '1' },
    { id: '3', rating: 7, content: 'lorem_ipsum', author_id: '3', game_id: '3' },
    { id: '4', rating: 5, content: 'lorem_ipsum', author_id: '2', game_id: '4' },
    { id: '5', rating: 8, content: 'lorem_ipsum', author_id: '1', game_id: '5' },
    { id: '6', rating: 7, content: 'lorem_ipsum', author_id: '3', game_id: '2' },
    { id: '7', rating: 10, content: 'lorem_ipsum', author_id: '3', game_id: '1' },
];
// A schema is a collection of type definitions (hence "typeDefs")
// that together define the "shape" of queries that are executed against
// your data.
const typeDefs = `#graphql
    # Comments in GraphQL strings (such as this one) start with the hash (#) symbol.

    # This "Book" type defines the queryable fields for every book in our data source.
    type Book {
        title: String
        author: String
    },
    type Game {
        id: ID!,
        title: String!,
        platforms: [String]!
        reviews: [Review!]
    }
    type Review {
        id: ID!
        rating: Int!
        content: String!
        game: Game!
        author: Author!
    }
    type Author {
        id: ID!
        name: String!
        verified: Boolean!
        reviews: [Review!]
    }
    # The "Query" type is special: it lists all of the available queries that
    # clients can execute, along with the return type for each. In this
    # case, the "books" query returns an array of zero or more Books (defined above).
    # type Query {
    #     books: [Book]
    # }
    type Query {
        books: [Book]
        reviews: [Review]
        review(id: ID!): Review
        games: [Game]
        game(id: ID!) : Game
        authors: [Author]
        author(id: ID!) : Author
    },
    type Mutation {
        deleteGame(id: ID!): [Game]
        addGame(game: AddGameInput!): Game
        updateGame(id: ID, edits: EditGameInput!): Game
    },
    input EditGameInput {
        title: String
        platforms: [String!]
    },
    input AddGameInput {
        title: String!
        platforms: [String!]!
    }
`;
// Resolvers define how to fetch the types defined in your schema.
// This resolver retrieves books from the "books" array above.
const resolvers = {
    // Query: {
    //     books: () => books,
    // },
    Query: {
        games() {
            return games;
        },
        reviews() {
            return reviews;
        },
        authors() {
            return authors;
        },
        review(_, args) {
            return reviews.find((review) => review.id === args.id);
        },
        game(_, args) {
            return games.find((game) => game.id === args.id);
        },
        author(_, args) {
            return authors.find((author) => author.id === args.id);
        }
    },
    Game: {
        reviews(parent) {
            return reviews.filter((r) => r.game_id === parent.id);
        }
    },
    Author: {
        reviews(parent) {
            return reviews.filter((r) => r.author_id === parent.id);
        }
    },
    Review: {
        author(parent) {
            return authors.find((a) => a.id === parent.author_id);
        },
        game(parent) {
            return games.find((g) => g.id === parent.game_id);
        },
    },
    Mutation: {
        deleteGame(_, args) {
            games = games.filter((game) => game.id !== args.id);
            return games;
        },
        addGame(_, args) {
            // const newGame = {
            //     id: String(games.length + 1),
            //     title: args.game.title,
            //     platforms: args.game.platforms,
            // }
            let game = {
                ...args.game,
                id: Math.floor(Math.random() * 10000).toString()
            };
            games.push(game);
            console.log("Added game ", game);
            return game;
        },
        updateGame(_, args) {
            games = games.map((g) => {
                if (g.id === args.id) {
                    return {
                        ...g,
                        ...args.edits
                    };
                }
                else {
                    return g;
                }
            });
            let game = games.find((game) => game.id === args.id);
            return game;
        }
    }
};
// The ApolloServer constructor requires two parameters: your schema
// definition and your set of resolvers.
const server = new ApolloServer({
    typeDefs,
    resolvers,
});
// Passing an ApolloServer instance to the `startStandaloneServer` function:
//  1. creates an Express app
//  2. installs your ApolloServer instance as middleware
//  3. prepares your app to handle incoming requests
const { url } = await startStandaloneServer(server, {
    listen: { port: 4000 },
});
console.log(`🚀  Server ready at: ${url}`);
