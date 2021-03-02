using GraphQL.Types;
using StartWarsQL.DotNetCore.Entities;
using StartWarsQL.DotNetCore.Logic;

namespace StarWarsGL.DotNetApi.Types
{
    public class DroidType : ObjectGraphType<Droid>
    {
        public DroidType(StarWarsLogic logic)
        {
            Name = "Droid";
            Description = "A mechanical creature in the Star Wars universe.";

            Field(d => d.Id).Description("The id of the droid.");
            Field(d => d.Name, nullable: true).Description("The name of the droid.");

            Field<ListGraphType<CharacterInterface>>(
                "friends",
                resolve: context => logic.GetFriends(context.Source)
            );
            Field<ListGraphType<EpisodeEnum>>("appearsIn", "Which movie they appear in.");
            Field(d => d.PrimaryFunction, nullable: true).Description("The primary function of the droid.");

            Interface<CharacterInterface>();
        }
    }
}