using System;
using Microsoft.EntityFrameworkCore;
using QR_Menu.Models;

namespace QR_Menu.Data
{
	public class ApplicationContext : DbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{
		}
        public DbSet<QR_Menu.Models.State>? States { get; set; }
        public DbSet<QR_Menu.Models.Company>? Companies { get; set; }
		public DbSet<QR_Menu.Models.Food>? Foods { get; set; }
        public DbSet<QR_Menu.Models.Category>? Categories { get; set; }
        public DbSet<QR_Menu.Models.Restaurant>? Restaurants { get; set; }
    }
}