using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddXmlFile("appsettings.xml", optional: true, reloadOnChange: true)
    .AddIniFile("appsettings.ini", optional: true, reloadOnChange: true);

builder.Services.AddSingleton<IEmployeeService, EmployeeService>();

var app = builder.Build();

app.MapGet("/", (IEmployeeService employeeService, IConfiguration configuration) =>
{
    var companyWithMaxEmployees = employeeService.GetCompanyWithMaxEmployees();

    var name = configuration["PersonalInfo:Name"];
    var age = configuration["PersonalInfo:Age"];
    var city = configuration["PersonalInfo:City"];
    var occupation = configuration["PersonalInfo:Occupation"];

    return $"������� � ��������� ������� �����������: {companyWithMaxEmployees}\r\n" +
           $"�� ��'�: {name}, ³�: {age}, ̳���: {city}, г� ������: {occupation}";
});

app.Run();
