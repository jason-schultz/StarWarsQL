using StartWarsQL.DotNetCore.Data.Base;
using StartWarsQL.DotNetCore.Data.Interfaces;
using StartWarsQL.DotNetCore.Entities;

namespace StartWarsQL.DotNetCore.Data
{
    public interface IDroidDao : IBaseDao<Droid, string>
    {

    }

    public class DroidDao : BaseDao<Droid>, IDroidDao
    {
        public DroidDao(IMongoDbSettings settings) : base(settings) {}
    }
}