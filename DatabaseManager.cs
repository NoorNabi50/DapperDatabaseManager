using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DappperDatabaseManager
{
    public class DatabaseManager : IDatabaseManager
    {
        private IDbConnection? DbConnection;
        public async Task<dynamic> ExecuteAsync<dynamic>(string StoredProcedureName, object @params, SqlConnection connection)
        {
            DbConnection = connection;
            return (dynamic)await DbConnection.QueryAsync<dynamic>(StoredProcedureName,@params, commandType: CommandType.StoredProcedure);

        }
     
        public async Task<IEnumerable<T>> GetAllAsync<T>(string StoredProcedureName, object @params, SqlConnection connection)
        {
            DbConnection = connection;
            return await DbConnection.QueryAsync<T>(StoredProcedureName, @params, commandType: CommandType.StoredProcedure);
        }
        public async Task<T> GetAllByIdAsync<T>(string StoredProcedureName, object @params, SqlConnection connection)
        {
            DbConnection = connection;
            return await DbConnection.QueryFirstAsync<T>(StoredProcedureName, @params, commandType: CommandType.StoredProcedure);
        }
     
        public async Task<T> InsertAsync<T>(string StoredProcedureName, object model, SqlConnection connection)
        {
            DbConnection = connection;
            return await DbConnection.QueryFirstAsync<T>(StoredProcedureName, model, commandType: CommandType.StoredProcedure);           
        }
     
        public async Task<int> RemoveAsync(string StoreProcedureName, object @params, SqlConnection connection)
        {
            DbConnection = connection;
            return await DbConnection.ExecuteAsync(StoreProcedureName, @params, commandType: CommandType.StoredProcedure);
        }

        public async Task<T> UpdateAsync<T>(string StoredProcedureName, object model, SqlConnection connection)
        {
            DbConnection = connection;
            return await DbConnection.QueryFirstAsync<T>(StoredProcedureName, model, commandType: CommandType.StoredProcedure);
        }
    }
}
