using System;
using GraphQL.Types;
using GraphQL.Utilities;

using StarWarsQL.DotNetApi.GraphQL;

namespace StartWarsQL.DotNetApi
{
    public class StarWarsSchema : Schema
    {
        public StarWarsSchema(IServiceProvider provider) : base(provider)
        {
            Query = (IObjectGraphType)provider.GetRequiredService<StarWarsQuery>();
            Mutation = (IObjectGraphType)provider.GetRequiredService<StarWarsMutation>();
        }
    }
}