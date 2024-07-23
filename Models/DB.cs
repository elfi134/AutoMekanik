using Microsoft.EntityFrameworkCore;
using System.Drawing.Text;

namespace AutoMekanikV3Final.Models
{
    public class DB : DbContext
    {
        public DB(DbContextOptions<DB> options): base(options)
        {
         
        }
        //1. Define the connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=ELFIDELL\\SQLEXPRESS;Integrated Security=True; Database=AutoMekanik;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        //2. Define the models that will be tables in the database
        public DbSet<Cars> Cars { get; set; }

        public DbSet<Tasks> Tasks { get; set;}
        
        public DbSet<kategori> kategori { get; set; }
    }
}
