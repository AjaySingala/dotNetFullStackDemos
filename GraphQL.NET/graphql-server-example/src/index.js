"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var server_1 = require("@apollo/server");
var standalone_1 = require("@apollo/server/standalone");
// types.
// import { typeDefs } from './schema'
// import {db} from './_db'
// The data.
var books = [
    {
        title: 'The Awakening',
        author: 'Kate Chopin',
    },
    {
        title: 'City of Glass',
        author: 'Paul Auster',
    },
];
var games = [
    { id: '1', title: 'Zelda, Tears of the Kingdom', platform: ['Switch'] },
    { id: '2', title: 'Final Fantasy 7 Remake', platform: ['PS5', 'Xbox'] },
    { id: '3', title: 'Elden Ring', platform: ['PS5', 'Xbox', 'PC'] },
    { id: '4', title: 'Mario Kart', platform: ['Switch'] },
    { id: '5', title: 'Pokemon Scarlet', platform: ['PS5', 'Xbox', 'PC'] },
];
var authors = [
    { id: '1', name: 'mario', verified: true },
    { id: '2', name: 'yoshi', verified: false },
    { id: '3', name: 'peach', verified: true },
];
var reviews = [
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
var typeDefs = "#graphql\n    # Comments in GraphQL strings (such as this one) start with the hash (#) symbol.\n\n    # This \"Book\" type defines the queryable fields for every book in our data source.\n    type Book {\n        title: String\n        author: String\n    },\n    type Game {\n        id: ID!,\n        title: String!,\n        platform: [String]! \n    }\n    type Review {\n        id: ID!\n        rating: Int!\n        content: String!\n    }\n    type Author {\n        id: ID!\n        name: String!\n        verified: Boolean!\n    }\n    # The \"Query\" type is special: it lists all of the available queries that\n    # clients can execute, along with the return type for each. In this\n    # case, the \"books\" query returns an array of zero or more Books (defined above).\n    # type Query {\n    #     books: [Book]\n    # }\n    type Query {\n        books: [Book]\n        reviews: [Review]\n        games: [Game]\n        authors: [Author]\n    }\n";
// Resolvers define how to fetch the types defined in your schema.
// This resolver retrieves books from the "books" array above.
var resolvers = {
    // Query: {
    //     books: () => books,
    // },
    Query: {
        games: function () {
            return games;
        },
        reviews: function () {
            return reviews;
        },
        authors: function () {
            return authors;
        }
    },
};
// The ApolloServer constructor requires two parameters: your schema
// definition and your set of resolvers.
var server = new server_1.ApolloServer({
    typeDefs: typeDefs,
    resolvers: resolvers,
});
// Passing an ApolloServer instance to the `startStandaloneServer` function:
//  1. creates an Express app
//  2. installs your ApolloServer instance as middleware
//  3. prepares your app to handle incoming requests
var url = (await (0, standalone_1.startStandaloneServer)(server, {
    listen: { port: 4000 },
})).url;
console.log("\uD83D\uDE80  Server ready at: ".concat(url));
