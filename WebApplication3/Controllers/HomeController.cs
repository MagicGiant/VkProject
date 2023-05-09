using System.Diagnostics;
using BusinessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers;

public class HomeController : Controller
{
    public ActionResult Index()
    {
        // получаем из бд все объекты Book
        IEnumerable<User> books = new Manager().GetUsers();
        // передаем все объекты в динамическое свойство Books в ViewBag
        ViewBag.Books = books;
        // возвращаем представление
        return View();
    }
}