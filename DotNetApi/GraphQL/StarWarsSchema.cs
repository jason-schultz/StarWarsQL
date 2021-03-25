using System;
using GraphQL.Types;
using GraphQL.Utilities;


namespace StarWarsQL.DotNetApi.GraphQL
{
    public class StarWarsSchema : Schema
    {
        public StarWarsSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<StarWarsQuery>();
            Mutation = provider.GetRequiredService<StarWarsMutation>();
        }
    }
}