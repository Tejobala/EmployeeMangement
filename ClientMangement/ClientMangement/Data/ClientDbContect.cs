using ClientMangement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ClientMangement.Data
{
    public class ClientDbContect:IdentityDbContext<ApplicationUser>
    {
        public ClientDbContect(DbContextOptions<ClientDbContect> dbContext)
           : base(dbContext)
        {

        }
        public DbSet<Client> Client { get; set; }
    }
}
