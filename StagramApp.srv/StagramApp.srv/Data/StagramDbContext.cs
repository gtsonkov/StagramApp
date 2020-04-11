using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StagramApp.srv.Data.Models;

namespace StagramApp.srv.Data
{
    public class StagramDbContext : IdentityDbContext<User>
    {
        public StagramDbContext(DbContextOptions<StagramDbContext> options)
            : base(options)
        {
        }
    }
}