using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StartWarsQL.DotNetCore.Data;
using StartWarsQL.DotNetCore.Data.Interfaces;
using StartWarsQL.DotNetCore.Entities;
using StartWarsQL.DotNetCore.Logic.Interfaces;

namespace StartWarsQL.DotNetCore.Logic
{
    public class StarWarsLogic : IStarWarsLogic
    {
        //private readonly IStarWarsData _data;
        private readonly IHumanDao _humanDao;
        private readonly IDroidDao _droidDao;

        public StarWarsLogic(/*IStarWarsData data,*/ IHumanDao humandDao, IDroidDao droidDao)
        {
            //_data = data;
            _humanDao = humandDao;
            _droidDao = droidDao;
        }

        public async Task<Human> AddHuman(Human human)
        {
            return await Task.FromResult(_humanDao.Insert(human));
            //return await Task.FromResult(_data.AddHuman(human));
        }

        public async Task<IEnumerable<Human>> RetrieveAllHumans()
        {
            var humans = await _humanDao.RetrieveAllAsync();

            return humans;
        }

        public async Task<IEnumerable<StarWarsCharacter>> GetFriends(StarWarsCharacter character)
        {
            if(character == null)
                return null;
            
            var friends = new List<StarWarsCharacter>();
            var lookup = character.Friends;
            if(lookup != null)
            {
                friends.AddRange(await Task.FromResult(_humanDao.RetrieveAll().Where(h => lookup.Contains(h.Id))));
                friends.AddRange(await Task.FromResult(_droidDao.RetrieveAll().Where(d => lookup.Contains(d.Id))));
                // friends.AddRange(await Task.FromResult(_humanDao.RetrieveAll().Where(h => lookup.Contains(h.Id))));
                // friends.AddRange(await Task.FromResult(_droidDao.RetrieveAll().Where(d => lookup.Contains(d.Id))));
            }

            return friends;
        }

        public async Task<Human> GetHumanByIdAsync(string id)
        {
            var human = await _humanDao.RetrieveByIdAsync(id);
            if(human == null)
                return null;

            return human;
        }

        public async Task<Droid> GetDroidByIdAsync(string id)
        {
            //var droid = await Task.FromResult(_droidDao.RetrieveById(id));
            var droid = await _droidDao.RetrieveByIdAsync(id);
            if(droid == null)
                return null;

            return droid;
        }
    }
}