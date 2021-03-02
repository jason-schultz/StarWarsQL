using System.Collections.Generic;
using StartWarsQL.DotNetCore.Entities;

namespace StartWarsQL.DotNetCore.Data.Interfaces
{
    public interface IStarWarsData
    {
        IEnumerable<StarWarsCharacter> GetHumans();
        
        IEnumerable<StarWarsCharacter> GetDroids();
        
        Human GetHumanById(string id); 
        
        Droid GetDroidById(string id);
        
        Human AddHuman(Human human);
    }
}