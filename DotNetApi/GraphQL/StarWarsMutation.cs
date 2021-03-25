using GraphQL;
using GraphQL.Types;
using StartWarsQL.DotNetCore.Entities;
using StartWarsQL.DotNetCore.Logic.Interfaces;
using StarWarsGL.DotNetApi.Types;

namespace StarWarsQL.DotNetApi.GraphQL
{
    public class StarWarsMutation : ObjectGraphType 
    {
        private readonly IStarWarsLogic _logic;

        public StarWarsMutation(IStarWarsLogic logic)
        {

            _logic = logic;

            Name = "Mutation";

            Field<HumanType>(
                "createHuman",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<HumanInputType>> {Name = "human"}
                ),
                resolve: context =>
                {
                    var human = context.GetArgument<Human>("human");
                    return _logic.AddHuman(human);
                }
            );
        }
    }
}