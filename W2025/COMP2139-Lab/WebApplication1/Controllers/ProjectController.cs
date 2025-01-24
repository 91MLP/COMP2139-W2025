using Microsoft.AspNetCore.Mvc;

public class ProjectController:Controller
{
    [HttpGet]
    public IActionResult Index(){
        var projects = new List<Project>(){
            new Project() { ProjectId = 1, Name = "Project 1", Description = "This is project 1" }
        };
        return View(projects);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Project project)
    {
        //Persist new Project to the database
        return RedirectToAction("Index");
        
    }

    public IActionResult Details(int id)
    {
        //Database: Retrieve project from  database
        var project = new Project{ProjectId = 1, Name = "Project 1", Description = "This is project 1"};
        return View(project);
    }
}