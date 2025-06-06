﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Areas.ProjectManagement.Models;

namespace WebApplication1.Data;

public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Project>Projects { get; set; }
    
    public DbSet<ProjectTask>Tasks{ get; set; }
    public DbSet<ProjectComment> ProjectComments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("Identity");
        modelBuilder.Entity<Project>()
            .HasMany(p => p.Tasks)
            .WithOne(t => t.Project)
            .HasForeignKey(t => t.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);

       
        modelBuilder.Entity<Project>()
            .Property(p => p.StartDate)
            .HasConversion(
                v => v.ToUniversalTime(),  
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc));  

        modelBuilder.Entity<Project>()
            .Property(p => p.EndDate)
            .HasConversion(
                v => v.ToUniversalTime(),
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
        
        modelBuilder.Entity<Project>().HasMany(p => p.Tasks).WithOne(t => t.Project)
            .HasForeignKey(t => t.ProjectId).OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Project>().HasData(
            new Project { ProjectId = 1, Name = "Assignment1", Description = "Comp2139_Assignment1", StartDate = new DateTime(2025, 3, 15, 12, 0, 0, DateTimeKind.Utc), EndDate = new DateTime(2025, 3, 22, 12, 0, 0, DateTimeKind.Utc) },
            new Project { ProjectId = 2, Name = "Assignment2", Description = "Comp2139_Assignment2", StartDate = new DateTime(2025, 3, 16, 12, 0, 0, DateTimeKind.Utc), EndDate = new DateTime(2025, 3, 23, 12, 0, 0, DateTimeKind.Utc) }
        );

        // modelBuilder.Entity<Project>().HasData(
        //     new Project {ProjectId = 1, Name = "Assignment1", Description = "Comp2139_Assignment1"},
        //     new Project {ProjectId = 2, Name = "Assignment2", Description = "Comp2139_Assignment2"}
        //     );
        
        modelBuilder.Entity<ApplicationUser>(entity=>entity.ToTable("ApplicationUser"));
        modelBuilder.Entity<IdentityRole>(entity=>entity.ToTable("Role"));
        modelBuilder.Entity<IdentityUserRole<string>>(entity=>entity.ToTable("UserRoles"));
        modelBuilder.Entity<IdentityUserClaim<string>>(entity=>entity.ToTable("UserClaims"));
        modelBuilder.Entity<IdentityUserToken<string>>(entity=>entity.ToTable("UserTokens"));
        modelBuilder.Entity<IdentityUserLogin<string>>(entity=>entity.ToTable("UserLogins"));
        modelBuilder.Entity<IdentityRoleClaim<string>>(entity=>entity.ToTable("RoleClaims"));
    }
    
}