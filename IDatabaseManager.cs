using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DappperDatabaseManager
{
    public interface IDatabaseManager
    {

        /// <summary>
        /// <para>Use this method to retrieve data from Database</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="StoredProcedureName"></param>
        /// <param name="params"></param>
        /// <param name="connection"></param>
        /// <returns>Return IEnumerable Type of T Type -- Here T can be any object</returns>
        Task<IEnumerable<T>> GetAllAsync<T>(string StoredProcedureName, object @params, SqlConnection connection);
        /// <summary>
        /// <para>Use this method to insert data into database</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="StoredProcedureName"></param>
        /// <param name="model"></param>
        /// <param name="connection"></param>
        /// <returns>Returns object of Type T</returns>
        Task<T> InsertAsync<T>(string StoredProcedureName, object model,SqlConnection connection);

        /// <summary>
        /// <para>Use this method for data updation</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="StoredProcedureName"></param>
        /// <param name="model"></param>
        /// <param name="connection"></param>
        /// <returns>Returns object of Type T</returns>
        Task<T> UpdateAsync<T>(string StoredProcedureName, object model,SqlConnection connection);
        /// <summary>
        /// <para>Use this method to retrieve single row data from database</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="StoredProcedureName"></param>
        /// <param name="params"></param>
        /// <param name="connection"></param>
        /// <returns>Returns single object of Type T</returns>
        Task<T> GetAllByIdAsync<T>(string StoredProcedureName,object @params,SqlConnection connection);

        /// <summary>
        /// <para>Use this method to remove data from database</para>
        /// </summary>
        /// <param name="StoreProcedureName"></param>
        /// <param name="params"></param>
        /// <param name="connection"></param>
        /// <returns>Returns No of Affected Rows int Type</returns>
        Task<int> RemoveAsync(string StoreProcedureName, object @params,SqlConnection connection);


        // return dynamic Type ..It can be anything list,datatable,single object etc 

        Task<dynamic> ExecuteAsync<dynamic>(string StoredProcedureName, object @params,SqlConnection connection);


    }
}
