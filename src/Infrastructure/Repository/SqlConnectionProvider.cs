using HRMS.Infrastructure.Abstract;
using HRMS.Shared;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace HRMS.Infrastructure
{
    public class SqlConnectionProvider : ISqlConnectionProvider
    {
        private readonly AppSettings _settings;

        public SqlConnectionProvider(IOptions<AppSettings> settings)
        {
            _settings = settings.Value;
        }

        public int ExecuteNonQuery(string sql, IDbDataParameter[] sqlParameters, CommandType commandType)
        {
            var connection = new SqlConnection(_settings.ConnectionStrings.SqlConnection);
            using (connection)
            {
                connection.Open();

                var cmd = connection.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(sqlParameters);
                var result = cmd.ExecuteNonQuery();
                return result;
            };
        }

        public async Task<int> ExecuteNonQueryAsync(string sql, CommandType commandType)
        {
            var connection = new SqlConnection(_settings.ConnectionStrings.SqlConnection);
            using (connection)
            {
                connection.Open();

                var cmd = connection.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = commandType;

                var result = await cmd.ExecuteNonQueryAsync();
                return result;
            };
        }

        public async Task<int> ExecuteNonQueryAsync(string sql, IDbDataParameter[] sqlParameters, CommandType commandType)
        {
            var connection = new SqlConnection(_settings.ConnectionStrings.SqlConnection);
            using (connection)
            {
                connection.Open();

                var cmd = connection.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(sqlParameters);

                var result = await cmd.ExecuteNonQueryAsync();
                return result;
            };
        }

        public async Task<DataSet> GetDataSetAsync(string storedProcedureName)
        {
            var connection = new SqlConnection(_settings.ConnectionStrings.SqlConnection);
            using (connection)
            {
                var ds = new DataSet();

                await Task.Run(() =>
                {
                    connection.Open();

                    var cmd = connection.CreateCommand();
                    cmd.CommandText = storedProcedureName;
                    cmd.CommandType = CommandType.StoredProcedure;

                    var adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds);
                });

                return ds;
            };
        }

        public async Task<DataSet> GetDataSetAsync(string storedProcedureName, IDbDataParameter[] sqlParameters)
        {
            var connection = new SqlConnection(_settings.ConnectionStrings.SqlConnection);
            using (connection)
            {
                var ds = new DataSet();

                await Task.Run(() =>
                {
                    connection.Open();

                    var cmd = connection.CreateCommand();
                    cmd.CommandText = storedProcedureName;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(sqlParameters);

                    var adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds);
                });

                return ds;
            };
        }

        public async Task<DataTable> GetDataTableAsync(string sql, CommandType commandType)
        {
            var connection = new SqlConnection(_settings.ConnectionStrings.SqlConnection);
            using (connection)
            {
                connection.Open();

                var cmd = connection.CreateCommand();
                var dt = new DataTable();

                cmd.CommandText = sql;
                cmd.CommandType = commandType;
                var rdr = await cmd.ExecuteReaderAsync();


                dt.Load(rdr);
                return dt;
            };
        }

        public async Task<DataTable> GetDataTableAsync(string sql, IDbDataParameter[] sqlParameters, CommandType commandType)
        {
            var connection = new SqlConnection(_settings.ConnectionStrings.SqlConnection);
            using (connection)
            {
                connection.Open();

                var cmd = connection.CreateCommand();
                var dt = new DataTable();

                cmd.CommandText = sql;
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(sqlParameters);

                var rdr = await cmd.ExecuteReaderAsync();


                dt.Load(rdr);
                return dt;
            };
        }
        public IDbDataParameter[] CreateParameterArray(int elements)
        {
            return new SqlParameter[elements];
        }
        public IDbDataParameter CreateInputParameter(string name, DbType type, object value)
        {
            SqlParameter param = new SqlParameter();

            ((IDbDataParameter)param).ParameterName = name;
            ((IDbDataParameter)param).DbType = type;
            ((IDbDataParameter)param).Direction = ParameterDirection.Input;
            ((IDbDataParameter)param).Value = value;

            return param;
        }
    }
}
