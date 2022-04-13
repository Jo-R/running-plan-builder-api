using Microsoft.EntityFrameworkCore;

namespace RunnningPlanBuilderApi.Models
{
    public class RunPlanContext: DbContext
    {
        public RunPlanContext(DbContextOptions<RunPlanContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; } = null!;

        public DbSet<PlanSummary> PlanSummary { get; set; } = null!;

    }
}
