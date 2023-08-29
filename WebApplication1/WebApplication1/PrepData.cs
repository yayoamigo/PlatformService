using PlatformServiceCore.Domain.Entity;
using PlatformServiceInfrastructure.DBContext;

namespace PlatformServiceUI
{
    public class PrepData
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<PlatformDbContext>());
            }
        }
        private static void SeedData(PlatformDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding data...");
                context.Platforms.AddRange(
                                       new Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                                                          new Platform() { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
                                                                             new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }
                                                                                            );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}
