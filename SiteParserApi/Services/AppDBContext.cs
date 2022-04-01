using Microsoft.EntityFrameworkCore;
using SiteParserApi.Data.Models;

namespace SiteParserApi.Services
{
    public class AppDBContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<MediaType> MediaType { get; set; }

        public AppDBContext (DbContextOptions<AppDBContext> options) : base(options)
        {

        }
    }
}
