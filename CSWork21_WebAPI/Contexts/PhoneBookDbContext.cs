using CSWork21.Enities;
using CSWork21_WebAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CSWork21_WebAPI.Contexts
{
    public class PhoneBookDbContext : IdentityDbContext<User>
    {
        public DbSet<Contact> Contacts { get; set; }

        public PhoneBookDbContext(DbContextOptions options) : base(options) {}

    }
}
