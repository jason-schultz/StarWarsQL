using System.Collections.Generic;
using System.Threading.Tasks;
using StartWarsQL.DotNetCore.Entities;

namespace StartWarsQL.DotNetCore.Logic.Interfaces
{
    public interface IStarWarsLogic
    {
        Task<Human> AddHuman(Human human);

        Task<IEnumerable<StarWarsCharacter>> GetFriends(StarWarsCharacter character);

        Task<Human> GetHumanByIdAsync(string id);

        Task<Droid> GetDroidByIdAsync(string id);

        Task<IEnumerable<Human>> RetrieveAllHumans();
    }
}