namespace WebApplication1.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IConfiguration _configuration;

        public EmployeeService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetCompanyWithMaxEmployees()
        {
            var companies = new List<(string Name, int Employees)>();

            // Отримуємо дані з конфігурацій
            var microsoftEmployees = _configuration.GetValue<int>("Companies:Microsoft:Employees");
            var appleEmployees = _configuration.GetValue<int>("Companies:Apple:Employees");
            var googleEmployees = _configuration.GetValue<int>("Companies:Google:Employees");

            companies.Add(("Microsoft", microsoftEmployees));
            companies.Add(("Apple", appleEmployees));
            companies.Add(("Google", googleEmployees));

            // Знаходимо компанію з найбільшою кількістю співробітників
            var companyWithMaxEmployees = companies.OrderByDescending(c => c.Employees).FirstOrDefault();
            return companyWithMaxEmployees.Name;
        }
    }
}
