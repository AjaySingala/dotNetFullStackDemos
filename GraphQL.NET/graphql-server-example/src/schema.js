export const typeDefs = `#graphql
    type Game {
        id: ID!,
        title: String!,
        platforms: [String]! 
    }
    type Review {
        id: ID!
        rating: Int!
        content: String!
    }
    type Author {
        id: ID!
        name: String!
        verfied: Boolean!
    }
    type Query {
        reviews: [Review]
        games: [Game]
        author: [Author]
    }
`

//module.exports = { typeDefs };
// export { typeDefs}