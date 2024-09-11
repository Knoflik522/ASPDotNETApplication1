using Microsoft.AspNetCore.Mvc;
using System;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            var company = new Company
            {
                Name = "Tech Innovations Ltd.",
                Address = "123 Tech Street, Innovation City",
                FoundedYear = 2010,
                Employees = 150
            };

            return View(company);
        }

        public IActionResult RandomNumber()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 101); // Генеруємо число від 0 до 100

            // Передаємо число через ViewBag
            ViewBag.RandomNumber = randomNumber;

            // Повертаємо представлення для відображення числа
            return View();
        }
    }
}
