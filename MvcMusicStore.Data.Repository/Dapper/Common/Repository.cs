using System.Configuration;
using System.Data;
using System.Data.SqlServerCe;

namespace MvcMusicStore.Data.Repository.Dapper.Common
{
    public class Repository
    {
        public IDbConnection MusicStoreConnection
        {
            get { return new SqlCeConnection(ConfigurationManager.ConnectionStrings["MusicStoreEntities"].ConnectionString); }
        }
    }
}
