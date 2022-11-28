using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ClientDbContext:DbContext
    {
        public ClientDbContext(DbContextOptions<ClientDbContext> dbContext)
            :base(dbContext)
        {

        }
        public DbSet<Client> Client { get; set; }
    }
}
