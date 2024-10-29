using Microsoft.Extensions.Configuration;
using System.Linq;

namespace WebApplication1.Models
{
    public class CompanyAnalysisService: ICompanyAnalysisService
    {
        private readonly IConfiguration _configuration;

        public CompanyAnalysisService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetCompanyWithMostEmployees()
        {
            var companiesFromJson = _configuration.GetSection("companies").Get<Company[]>();
            var companiesFromXml = _configuration.GetSection("companies").Get<Company[]>();
            var companiesFromIni = new[]
            {
            new Company { Name = "Microsoft", Employees = int.Parse(_configuration["Microsoft:employees"]) },
            new Company { Name = "Apple", Employees = int.Parse(_configuration["Apple:employees"]) },
            new Company { Name = "Google", Employees = int.Parse(_configuration["Google:employees"]) }
        };

            var allCompanies = companiesFromJson.Concat(companiesFromXml).Concat(companiesFromIni);

            var companyWithMostEmployees = allCompanies
                .GroupBy(c => c.Name) // Групуємо компанії за ім'ям
                .Select(g => new Company { Name = g.Key, Employees = g.Max(c => c.Employees) }) // Беремо максимум
                .OrderByDescending(c => c.Employees)
                .FirstOrDefault();

            return companyWithMostEmployees?.Name ?? "No companies found";
        }
    }
}
