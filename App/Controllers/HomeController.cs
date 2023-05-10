using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using App.Models;
using BusinessLayer.Entities;
using Database.Models;

namespace App.Controllers;

public class HomeController : Controller
{
    public ActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public ActionResult Authorisation()
    {
        return View();
    }

    [HttpPost]
    public string Authorisation(AllDataForUser data)
    {
        User user = new UserBuilder()
            .SetLogin(new Login(data.Login))
            .SetPassword(new Password(data.Password))
            .SetGroupCode(data.IsAdmin ? GroupCode.Admin : GroupCode.User)
            .SetGroupDestruction(data.StateDescription)
            .SetStateDestruction(data.StateDescription)
            .Build();
        Manager.SaveUser(user);
        return JsonSerializer.Serialize(user);
    }

    [HttpGet]
    public ActionResult SingIn()
    {
        return View();
    }

    [HttpPost]
    public string SingIn(SingInPasswordAndLogin data)
    {
        return JsonSerializer.Serialize(data);
    }
}