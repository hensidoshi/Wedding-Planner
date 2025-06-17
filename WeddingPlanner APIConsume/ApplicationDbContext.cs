using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WeddingPlanner_APIConsume.Models;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{
	}

	public DbSet<ContactFormModel> ContactForms { get; set; }
}
