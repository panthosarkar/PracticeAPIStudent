using Microsoft.EntityFrameworkCore;
using PracticeAPIStudent.Models;


namespace PracticeAPIStudent.Data
{
    public class ApiContext : DbContext
    { 
        public DbSet<StudentInfo> Students { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options): base(options) { }
    }
    
}
