using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Areas.ProjectManagement.Models;
using WebApplication1.Data;

namespace WebApplication1.Areas.ProjectManagement.Controllers;
[Area("ProjectManagement")]
[Route("[area]/[controller]/[action]")]
public class ProjectCommentController: Controller
{
    private readonly ApplicationDbContext _context;

    public ProjectCommentController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetComments(int projectId)
    {
        var comments = await _context.ProjectComments
            .Where(c => c.ProjectId == projectId).OrderByDescending(c=>c.DatePosted)
            .ToListAsync();
        return Json(comments);
    }

    public async Task<IActionResult> AddComment([FromBody] ProjectComment comment)
    {
        if (ModelState.IsValid)
        {
            comment.DatePosted=DateTime.Now;
            _context.ProjectComments.Add(comment);
            await _context.SaveChangesAsync();
            
            return Json(new {success=true,message="Comment added successfully"});
            
        }
        return Json(new {success=false,message="Comment added failed"});
        
    }
    
}