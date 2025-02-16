using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    [ValidateAntiForgeryToken]
    public IActionResult Create(Project project)
    {
        if (ModelState.IsValid)
        {
            _context.Project.Add(project);
            _context.SaveChange();
               //Persist new Project to the database
                    return RedirectToAction("Index");
        }
        return View(project);
     
        
    }

    public IActionResult Details(int id)
    {
        //Database: Retrieve project from  database
        var project = _context.Project.FirstOrDefault(p=>p.ProjectId == id);
        if ( project == null)
        {
            return NotFound();
        }
        return View(project);
        
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        //Returns project or null
        var project=_context.Projects.Find(id);
        if (project == null)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public IActionResult Edit(int id, [Bind("ProjectId,Name, Description")] Project project)
    {
        if (id != project.ProjectId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Projects.Update(project);
                _context.SaveChanges();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!projectExits(project.ProjectId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
    }

    private bool projectExits(int projectId)
    {
        return _context.Projects.Any(e => e.Project == id);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var project = _context.Projects.FirstOrDefault(p => p.ProjectId == id);
        if
    }
}