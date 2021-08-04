using HRMS.ApplicationCore.Abstract;
using HRMS.Infrastructure.Abstract;

namespace HRMS.ApplicationCore
{
    public class CompanyService : ICompanyService
    {
        private ICompanyRepository companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }
        public void Save(ICompany company)
        {
            companyRepository.Save(company);
        }
    }
}
