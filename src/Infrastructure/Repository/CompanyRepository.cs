using HRMS.ApplicationCore.Abstract;
using HRMS.Infrastructure.Abstract;
using System.Data;

namespace HRMS.Infrastructure
{
    public class CompanyRepository : ICompanyRepository
    {
        private ISqlConnectionProvider sqlConnectionProvider;

        public CompanyRepository(ISqlConnectionProvider sqlConnectionProvider)
        {
            this.sqlConnectionProvider = sqlConnectionProvider;
        }
        public void Save(ICompany company)
        {
            var parameters = sqlConnectionProvider.CreateParameterArray(1);
            parameters.SetValue(sqlConnectionProvider.CreateInputParameter("@Name", DbType.String, company.Name), 0);
            sqlConnectionProvider.ExecuteNonQuery("[dbo].[UpdateCompany]", parameters, CommandType.StoredProcedure);
        }
    }
}
