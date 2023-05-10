using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using App.Models;

namespace App.Controllers;

public class HomeController : Controller
{
    public ActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public ActionResult Registration()
    {
        return View();
    }

    [HttpPost]
    public string Registration(AllDataForUser data)
    {
        return $"login is {data.login}";
    }
}