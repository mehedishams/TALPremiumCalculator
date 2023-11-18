using Microsoft.EntityFrameworkCore;
namespace DataModel.Context
{
    public class TALDBContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TALDBContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public TALDBContext(DbContextOptions<TALDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            //Table Configurations
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TALDBContext).Assembly);
        }
    }
}
