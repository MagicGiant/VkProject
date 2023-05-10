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
    public ActionResult Registration()
    {
        return View();
    }

    [HttpPost]
    public string Registration(AllDataForUser data)
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
        User user = Manager.GetUserAndCheckPassword(new Login(data.Login), new Password(data.Password));
        return JsonSerializer.Serialize(user);
    }
}