namespace StartWarsQL.DotNetApi.GraphQL
{
    public class StarWarsMutation : ObjectGraphType 
    {
        public StarWarsMutation(StarWarsData data)
        {
            Name = "Mutation";

            Field<HumanType>(
                "createHuman",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<HumanInputType>> {Name = "human"}
                ),
                resolve: context =>
                {
                    var human = context.GetArgument<Human>("human");
                    return data.AddHuman(human);
                }
            );
        }
    }
}