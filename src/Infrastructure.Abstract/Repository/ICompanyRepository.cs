using HRMS.ApplicationCore.Abstract;
namespace HRMS.Infrastructure.Abstract
{
    public interface ICompanyRepository 
    {
        public void Save(ICompany company);
    }
}
