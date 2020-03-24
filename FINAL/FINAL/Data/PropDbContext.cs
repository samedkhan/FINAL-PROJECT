using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FINAL.Models;

namespace FINAL.Data
{
    public class PropDbContext:DbContext
    {
        public PropDbContext(DbContextOptions<PropDbContext> options) : base(options)
        {

        }

        public DbSet<City> Cities { get; set; }

        public DbSet<ContactNumber> ContactNumbers { get; set; }

        public DbSet<District> Districts { get; set; }

        public DbSet<PropAdd> PropAdds { get; set; }

        public DbSet<PropertyCharacter> PropertyCharacters { get; set; }

        public DbSet<PropertySort> PropertySorts { get; set; }

        public DbSet<PropPhoto> PropPhotos { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<WebsiteSetting> WebsiteSettings { get; set; }


    }
}
