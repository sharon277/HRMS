using HRMS.ApplicationCore;
using HRMS.ApplicationCore.Abstract;
using Microsoft.AspNetCore.Mvc;
namespace HRMS.Web
{
    public class CompanyController : Controller
    {
        private ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }
       
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(Company company)
        {
            companyService.Save(company);
            return View("Create", company);
        }
    }
}
