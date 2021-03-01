namespace StartWarsQL.DotNetApi
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