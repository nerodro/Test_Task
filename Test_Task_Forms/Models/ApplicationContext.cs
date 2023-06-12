using Microsoft.EntityFrameworkCore;

namespace Test_Task_Forms.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Form> Forms { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Form>().HasData(
        //            new Form{ Id = 1, CityFrom = "Tom", CityTo = "gg", AddressFrom ="geg",AddressTo="ged",DateOfGet="gegew",Weight="gegher" }
        //    );
        //}
    }
}
