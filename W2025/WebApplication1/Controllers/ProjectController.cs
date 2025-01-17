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

    

}