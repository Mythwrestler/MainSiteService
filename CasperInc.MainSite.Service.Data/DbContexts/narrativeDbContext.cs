using System;
using CasperInc.MainSite.Service.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CasperInc.MainSite.Service.Data
{
    public class NarrativeDbContext : DbContext
    {

        private ILogger<NarrativeDbContext> _logger;

        public NarrativeDbContext(DbContextOptions<NarrativeDbContext> options, ILogger<NarrativeDbContext> logger) : base(options)
        {
            _logger = logger;
            Database.Migrate();
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<TagDataModel>()
						.HasIndex(t => t.KeyWord)
						.IsUnique();

			modelBuilder.Entity<NarrativeTagDataModel>()
				.HasKey(t => new { t.NarrativeId, t.TagId });

			modelBuilder.Entity<NarrativeTagDataModel>()
				.HasOne(pt => pt.NarrativeData)
				.WithMany(p => p.NarrativeTags)
				.HasForeignKey(pt => pt.NarrativeId);

			modelBuilder.Entity<NarrativeTagDataModel>()
				.HasOne(pt => pt.TagData)
				.WithMany(t => t.NarrativeTags)
				.HasForeignKey(pt => pt.TagId);
		}


		public DbSet<NarrativeDataModel> NarrativeData { get; set; }
		public DbSet<TagDataModel> TagData { get; set; }
		public DbSet<NarrativeTagDataModel> NarrativeTagCrossWalk { get; set; }

    }
}
