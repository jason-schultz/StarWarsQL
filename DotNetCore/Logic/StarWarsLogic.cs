using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StartWarsQL.DotNetCore.Data.Interfaces;
using StartWarsQL.DotNetCore.Entities;

namespace StartWarsQL.DotNetCore.Logic
{
    public class StarWarsLogic
    {
        private readonly IStarWarsData _data;

        public StarWarsLogic(IStarWarsData data)
        {
            _data = data;
        }

        public async Task<Human> AddHuman(Human human)
        {
            return await Task.FromResult(_data.AddHuman(human));
        }

        public async Task<IEnumerable<StarWarsCharacter>> GetFriends(StarWarsCharacter character)
        {
            if(character == null)
                return null;
            
            var friends = new List<StarWarsCharacter>();
            var lookup = character.Friends;
            if(lookup != null)
            {
                friends.AddRange(await Task.FromResult(_data.GetHumans().Where(h => lookup.Contains(h.Id))));
                friends.AddRange(await Task.FromResult(_data.GetDroids().Where(d => lookup.Contains(d.Id))));
            }

            return friends;
        }

        public async Task<Human> GetHumanByIdAsync(string id)
        {
            var human = await Task.FromResult(_data.GetHumanById(id));
            if(human == null)
                return null;

            return human;
        }

        public async Task<Droid> GetDroidByIdAsync(string id)
        {
            var droid = await Task.FromResult(_data.GetDroidById(id));
            if(droid == null)
                return null;

            return droid;
        }
    }
}