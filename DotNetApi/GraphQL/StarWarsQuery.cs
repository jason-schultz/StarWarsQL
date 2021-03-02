using System;
using GraphQL;
using GraphQL.Types;
using StartWarsQL.DotNetCore.Logic;
using StarWarsGL.DotNetApi.Types;

namespace StarWarsQL.DotNetApi.GraphQL
{
    public class StarWarsQuery : ObjectGraphType
    {
        public StarWarsQuery(StarWarsLogic logic)
        {
            Name = "Query";

            Field<CharacterInterface>("hero", resolve: context => logic.GetDroidByIdAsync("3"));
            Field<HumanType>("human", 
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of human" }),
                resolve: context => logic.GetHumanByIdAsync(context.GetArgument<string>("id"))
            );

            Func<IResolveFieldContext, string, object> func = (context, id) => logic.GetDroidByIdAsync(id);

            FieldDelegate<DroidType>(
                "droid",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the droid" }
                ),
                resolve: func
            );
        }
    }
}