using MongoDB.Bson.Serialization.Attributes;

namespace StartWarsQL.DotNetCore.Entities
{
    public abstract class StarWarsCharacter
    {

        
        [BsonId]
        public string Id { get; set;}
        public string Name { get; set; }
        public string[] Friends { get; set; }
        public int[] AppearsIn { get; set; }
    }
}