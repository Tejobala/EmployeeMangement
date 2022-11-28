using HospitalInfo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalInfo.Data
{
    public class HospitalDbContext:IdentityDbContext<ApplicationUser>
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> dbContext)
            :base(dbContext) 
        {

        }
        public DbSet<Hospital> Hospitals { get; set; }
    }
}
