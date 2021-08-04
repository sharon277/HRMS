using System.Data;
using System.Threading.Tasks;

namespace HRMS.Infrastructure.Abstract
{
    public interface ISqlConnectionProvider
    {
        Task<int> ExecuteNonQueryAsync(string sql, CommandType commandType);
        Task<int> ExecuteNonQueryAsync(string sql, IDbDataParameter[] sqlParameters, CommandType commandType);
        int ExecuteNonQuery(string sql, IDbDataParameter[] sqlParameters, CommandType commandType);
        Task<DataSet> GetDataSetAsync(string storedProcedureName);
        Task<DataSet> GetDataSetAsync(string storedProcedureName, IDbDataParameter[] sqlParameters);
        Task<DataTable> GetDataTableAsync(string sql, CommandType commandType);
        Task<DataTable> GetDataTableAsync(string sql, IDbDataParameter[] sqlParameters, CommandType commandType);
        public IDbDataParameter[] CreateParameterArray(int elements);
        public IDbDataParameter CreateInputParameter(string name, DbType type, object value);
    }
}
