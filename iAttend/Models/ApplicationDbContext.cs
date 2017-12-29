using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace iAttend.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Event> Events { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}