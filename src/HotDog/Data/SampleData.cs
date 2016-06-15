using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using HotDog.Models;
using System.Collections.Generic;

namespace HotDog.Data
{
    public class SampleData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            // Ensure db
            context.Database.EnsureCreated();

            // Ensure Stephen (IsAdmin)
            var stephen = await userManager.FindByNameAsync("Stephen.Walther@CoderCamps.com");
            if (stephen == null)
            {
                // create user
                stephen = new ApplicationUser
                {
                    UserName = "Stephen.Walther@CoderCamps.com",
                    Email = "Stephen.Walther@CoderCamps.com",
                    Blogs = new List<Blog>
                    {
                        new Blog {
                            Title = "Hello from Coder Camps",
                            Message = "Stephen Message 1",
                            IsActive = true,
                            TimeCreated = DateTime.UtcNow
                        },
                        new Blog {
                            Title = "A blog to be finished",
                            Message = "Stephen Message 2",
                            IsActive = false,
                            TimeCreated = DateTime.UtcNow
                        },
                        new Blog {
                            Title = "Advantages of C# over other languages",
                            Message = "Stephen Message 3",
                            IsActive = true,
                            TimeCreated = DateTime.UtcNow
                        },
                    }
                };
                await userManager.CreateAsync(stephen, "Secret123!");

                // add claims
                await userManager.AddClaimAsync(stephen, new Claim("IsAdmin", "true"));
            }

            // Ensure Mike (not IsAdmin)
            var mike = await userManager.FindByNameAsync("Mike@CoderCamps.com");
            if (mike == null)
            {
                // create user
                mike = new ApplicationUser
                {
                    UserName = "Mike@CoderCamps.com",
                    Email = "Mike@CoderCamps.com",
                    Blogs = new List<Blog>
                    {
                        new Blog {
                            Title = "Started learning JS",
                            Message = "Mike Message 1 - oops made a mistake let's delete this!",
                            IsActive = false,
                            TimeCreated = DateTime.UtcNow
                        },
                        new Blog {
                            Title = "Experiencing Coder Camps",
                            Message = "Mike Message 2",
                            IsActive = true,
                            TimeCreated = DateTime.UtcNow
                        },
                        new Blog {
                            Title = "Why learn TypeScript",
                            Message = "Mike Message 3",
                            IsActive = true,
                            TimeCreated = DateTime.UtcNow
                        },
                    }
                };
                await userManager.CreateAsync(mike, "Secret123!");
            }


        }

    }
}
