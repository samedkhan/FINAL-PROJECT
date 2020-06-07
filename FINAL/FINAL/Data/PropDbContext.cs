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
        public DbSet<AddType> AddTypes { get; set; }

        public DbSet<Addvertisiment> Addvertisiments { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<District> Districts { get; set; }

        public DbSet<Feature> Features { get; set; }

        public DbSet<Flat> Flats { get; set; }

        public DbSet<Floor> Floors { get; set; }

        public DbSet<PropDoc> PropDocs { get; set; }

        public DbSet<Property> Properties { get; set; }

        public DbSet<PropertySort> PropertySorts { get; set; }

        public DbSet<PropFeature> PropFeatures { get; set; }

        public DbSet<PropPhoto> PropPhotos { get; set; }

        public DbSet<PropProject> PropProjects { get; set; }
        
        public DbSet<User> Users { get; set; }

        public DbSet<UserType> UserTypes { get; set; }

        public DbSet<WebsiteSetting> WebsiteSettings { get; set; }

        public DbSet<Message> Messages { get; set; }
    }
}
