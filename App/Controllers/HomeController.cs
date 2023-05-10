using System.Diagnostics;
using System.Text.Json;
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
        return JsonSerializer.Serialize(data);
    }
}