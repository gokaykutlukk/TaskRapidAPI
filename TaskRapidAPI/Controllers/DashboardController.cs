using TaskRapidAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

public class DashboardController : Controller
{
    public async Task<IActionResult> Index()
    {
       
        return View();
    }
}