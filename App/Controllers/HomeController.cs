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
    public ActionResult SingIn(SingInPasswordAndLogin data)
    {
        Manager.GetUserAndCheckPassword(new Login(data.Login), new Password(data.Password));
        return RedirectToAction("User", "Home",  new { login = data.Login });
    }
    
    [HttpGet]
    public ActionResult User(string login)
    {
        ViewBag.JsonString =JsonSerializer
            .Serialize(Manager.GetUser(new Login(login)), new JsonSerializerOptions { WriteIndented = true });
        TempData["login"] = login;
        return View();
    }

    [HttpPost]
    public ActionResult User()
    {
        string login = TempData["login"].ToString();
        User user = Manager.GetUser(new Login(login));
        
        if (user.UserStateData.Code == StateCode.Blocked)
            user.UserStateData.Code = StateCode.Active;
        else
            user.UserStateData.Code = StateCode.Blocked;
        
        Manager.UpdateUser(user);
        return RedirectToAction("User", new { login = login });
    }
}