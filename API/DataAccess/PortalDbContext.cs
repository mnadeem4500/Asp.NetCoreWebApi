using ExtremeClassified.Core.Providers.EntityFramework;
using ExtremeClassified.Domain.Identity;
using ExtremeClassified.Domain.Portal;
using ExtremeClassified.Domain.Listing;
using Microsoft.EntityFrameworkCore;

namespace ExtremeClassified.DataAccess
{
    public class PortalDbContext : DbContextBase
    {
        #region Definitions
        #endregion

        #region Constructor
        public PortalDbContext(string ConnectionString) : base(ConnectionString) { }

        // TEMP CODE  only for migration
        public PortalDbContext(DbContextOptions<PortalDbContext> options) : base(options) { }
        #endregion

        #region Events
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
        #endregion

        #region DbSets

        #region Listing

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryProperty> CategoryProperties { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<ListingAttachment> Attachments { get; set; }
        public DbSet<ListingFavorite> ListingFavorites { get; set; }
        public DbSet<ListingProperty> ListingProperties { get; set; }
        public DbSet<ListingVersion> ListingVersions { get; set; }
        public DbSet<ListingAlert> ListingAlerts { get; set; }

        #endregion

        #region Portal
        public DbSet<CatalogueMaster> CatalogueMasters { get; set; }
        public DbSet<CatalogueDetail> CatalogueDetails { get; set; }
        public DbSet<CountryAdministrativeDivision> CountryAdministrativeDivisions { get; set; }
        public DbSet<PortalCountry> PortalCountries { get; set; }
        public DbSet<ScreenControl> ScreenControls { get; set; }


        #endregion

        #region Identity

        public DbSet<Group> Groups { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<UserAccess> UserAccesses { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }
        public DbSet<UserDevice> UserDevices { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<UserPwdHistory> UserPwdHistory { get; set; }
        public DbSet<UserRegion> UserRegions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }

        #endregion

        #endregion
    }
}
