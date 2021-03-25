using MongoDB.Bson.Serialization.Attributes;

namespace StartWarsQL.DotNetCore.Entities
{

    public abstract class BaseEntity 
    {
        [BsonId]
        public string Id { get; set;}
    }
    public abstract class StarWarsCharacter : BaseEntity
    {
        public string Name { get; set; }
        public string[] Friends { get; set; }
        public int[] AppearsIn { get; set; }
    }
}