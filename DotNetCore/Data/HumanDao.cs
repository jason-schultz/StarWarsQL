using StartWarsQL.DotNetCore.Data.Base;
using StartWarsQL.DotNetCore.Data.Interfaces;
using StartWarsQL.DotNetCore.Entities;

namespace StartWarsQL.DotNetCore.Data
{
    public interface IHumanDao : IBaseDao<Human, string>
    {

    }

    public class HumanDao : BaseDao<Human>, IHumanDao
    {
        public HumanDao(IMongoDbSettings settings) : base(settings)
        {
            
        }
    }
}