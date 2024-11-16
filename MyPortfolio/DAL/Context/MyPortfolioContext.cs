using Microsoft.EntityFrameworkCore;
using MyPortfolio.DAL.Entities;

namespace MyPortfolio.DAL.Context
{
    public class MyPortfolioContext : DbContext //DbContext'ten miras aldım. DbContext sınıfına ait bazı propertiesler ve methodlar var. Bunları kullanabilmek için.
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //override, istediğim formatta işi gerçekleştirmek için kullandım. 
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-O1DRK0LF; initial Catalog=MyPortfolioDb;integrated Security=true;");
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
    }
}
