using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

       
         public DbSet<AppInformation> ApplicationInformationDetails { get; set; }
         public DbSet<Quotation> Quotations { get; set; }
         public DbSet<PackagingCondition> PackagingConditions { get; set; }
         public DbSet<SpecialRequirement> SpecialRequirements { get; set; }
        public DbSet<QuotationStatus> QuotationStatuses { get; set; }
        public DbSet<ItemImage> ItemImages { get; set; }
    }
}