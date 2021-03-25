using GraphQL.Types;
using StartWarsQL.DotNetCore.Entities;
using StartWarsQL.DotNetCore.Logic.Interfaces;

namespace StarWarsGL.DotNetApi.Types
{
    public class HumanType : ObjectGraphType<Human>
    {
        public HumanType(IStarWarsLogic logic)
        {
            Name = "Human";

            Field(h => h.Id).Description("The id of the human.");
            Field(h => h.Name, nullable: true).Description("The name of the human.");

            Field<ListGraphType<CharacterInterface>>(
                "friends",
                resolve: context => logic.GetFriends(context.Source)
            );
            Field<ListGraphType<EpisodeEnum>>("appearsIn", "Which movie they appear in.");

            Field(h => h.HomePlanet, nullable: true).Description("The home planet of the human.");

            Interface<CharacterInterface>();
        }
    }
}