using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Areas.ProjectManagement.Controllers;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        _logger.LogTrace("Accessed HomeController Index {Time}", DateTimeOffset.Now);
        return View();
    }

    public IActionResult Privacy()
    {
        _logger.LogTrace("Accessed HomeController Privacy {Time}", DateTimeOffset.Now);
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        _logger.LogTrace("Accessed HomeController Error {Time}", DateTimeOffset.Now);
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    [HttpGet]
    public IActionResult GeneralSearch(string searchType, string searchString)
    {
        _logger.LogTrace("Accessed HomeController GeneralSearch {Time}", DateTimeOffset.Now);
        searchType = searchType?.Trim().ToLower();
        if (string.IsNullOrWhiteSpace(searchType)||string.IsNullOrWhiteSpace(searchString))
        {
            return RedirectToAction(nameof(Index));
        }
        if (searchType == "projects")
        {
            return RedirectToAction(nameof(ProjectController.Search), "Project", new { area = "ProjectManagement" , searchString });

        }

        if (searchType == "tasks")
        {
            return RedirectToAction(nameof(ProjectTaskController.Search), "ProjectTask", new { area = "ProjectManagement", searchString });
        }

        return RedirectToAction(nameof(Index), "Home");

    }

    public IActionResult NotFound(int statusCode)
    {
        _logger.LogTrace("NotFound invoked at {Time}", DateTimeOffset.Now);
        if (statusCode == 404)
        {
            return View("NotFound");
        }

        return View("Error");
    }
}
