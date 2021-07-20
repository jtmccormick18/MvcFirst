using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcFirst.Models;
using System;
using System.Linq;

namespace MvcFirst.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcFirstContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcFirstContext>>()))
            {
                // Look for any movies.
                if (context.CamaSystem.Any() || context.Review.Any())
                {
                    return;   // DB has been seeded
                }

                context.CamaSystem.AddRange(
                    new CamaSystem
                    {
                        Name = "WinGap",
                        PropertyKeyName = "REALKEY",
                        OwnerKeyName = "OWNKEY"
                    },

                    new CamaSystem
                    {
                        Name = "ProVal ",
                        PropertyKeyName = "LRSN",
                        OwnerKeyName = "OWNER"
                    }

                );


                // For Reviews, Counties/State Combo would ideally have their own table reference by a foreign key on reviews also
                context.Review.AddRange(
                  new Review
                  {
                      CamaOriginKey = 7,
                      CamaOriginParcelNo = "",
                      AssignedAt = DateTime.Now,
                      CompletedAt = DateTime.MaxValue,
                      State = "GA",
                      County = "Greene",
                      CamaSystemId = 1
                  },

                  new Review
                  {
                      CamaOriginKey = 23,
                      CamaOriginParcelNo = "",
                      AssignedAt = DateTime.Now,
                      CompletedAt = DateTime.MaxValue,
                      State = "GA",
                      County = "Gwinnett",
                      CamaSystemId = 2
                  }
              );
                context.SaveChanges();
            }
        }
    }
}