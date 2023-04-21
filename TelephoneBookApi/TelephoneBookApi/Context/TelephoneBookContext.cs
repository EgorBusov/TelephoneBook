using Microsoft.EntityFrameworkCore;
using TelephoneBookApi.Authorize;
using TelephoneBookApi.Models;

namespace TelephoneBookApi.Context
{
    public class TelephoneBookContext : DbContext
    {
        public TelephoneBookContext(DbContextOptions<TelephoneBookContext> options)
        : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Persone> Persones { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
