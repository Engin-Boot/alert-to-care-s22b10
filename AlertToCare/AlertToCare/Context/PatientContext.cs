using AlertToCare.Models;
using Microsoft.EntityFrameworkCore;

namespace AlertToCare.Context
{
    public class PatientContext: DbContext
    {
        public PatientContext(DbContextOptions<PatientContext> options) : base(options)
        {

        }
        public DbSet<PatientDataModel> patient_info { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}
