using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Entity;
using Microsoft.Extensions.Logging;

namespace Infrastructure
{
    public class StoreContextSeed
    {
        // Static method to seed initial data into the db
        public static async Task SeedAsync(StoreContext context, ILogger logger)
        {

            try {
                // check if db is empty
                if (!context.Categories.Any())
                {
                    // Read JSON data from a file
                    var categoryData = File.ReadAllText("../Infrastructure/SeedData/categories.json");
                    // Deserialize JSON data into a list of category objects. Serialize the file into the obj
                    var categories = JsonSerializer.Deserialize<List<Category>>(categoryData);

                    // Add each category to the Categories DbSet
                    foreach (var item in categories)
                    {
                        context.Categories.Add(item);
                    }
                    // Save changes to the db
                    await context.SaveChangesAsync();
                }

                // Check if the Courses table is empty
                if (!context.Courses.Any())
                {
                    // Read JSON data from a file and stores as a string
                   var courseData = File.ReadAllText("../Infrastructure/SeedData/courses.json");
                   // Deserialize JSON data into a list of Course objects
                   var courses = JsonSerializer.Deserialize<List<Course>>(courseData);

                   // Add each course to the Courses DbSet
                  foreach (var item in courses)
                  {
                      context.Courses.Add(item);
                  }
                  // Save changes to db
                  await context.SaveChangesAsync();
                }

                if (!context.Learnings.Any())
                {
                    var learningData = File.ReadAllText("../Infrastructure/SeedData/learnings.json");
                    var learnings = JsonSerializer.Deserialize<List<Learning>>(learningData);

                    foreach (var item in learnings)
                    {
                        context.Learnings.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Requirements.Any())
                {
                    var requirementData = File.ReadAllText("../Infrastructure/SeedData/requirements.json");

                    var requirements = JsonSerializer.Deserialize<List<Requirement>>(requirementData);

                    foreach (var item in requirements)
                    {
                        context.Requirements.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
            }
               catch(Exception ex)
               {
                   // Log any exceptions that occur during the seeding process
                   logger.LogError(ex.Message);
               }
        }
    }
}