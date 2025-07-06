using Microsoft.AspNetCore.Mvc;

namespace RevoApp.Controllers;

public class ChatController : Controller
{
    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Index(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
            return RedirectToAction("Login");

        ViewBag.Username = username;
        return View();
    }
}
