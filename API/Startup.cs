using API.Helpers;
using Entity.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config) // inject configuration into startup class
        {
            _config = config; // Injecting IConfiguration for accessing configuration settings - gives us access to variables inside appsettings.development.json and appsettings.json
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // add CourseRepository service to use the methods. Mention the scope of the service (how long it will be available)
            // the repository will be injected into the controllers, a new instance of the repository will be created when we make the http request to the api
            // created when the http comes to the api, controller then knows to create the repository until after the request is finished, it then disposes of the controller and repository
            services.AddScoped<ICourseRepository, CourseRepository>(); // repository lifecycle
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
            // map dto's
            services.AddAutoMapper(typeof(MappingProfiles));
            // Adding MVC controllers
            services.AddControllers();
            // register db
            services.AddDbContext<StoreContext>(x =>
            {
                x.UseSqlite(_config.GetConnectionString("DefaultConnection")); // Using SQLite as the database provider
            });
            // allow any frontend requests from localhost:3000
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
                });
            });
            // Configuring Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // Exception page and Swagger UI enabled only in Development environment
                app.UseDeveloperExceptionPage();
                app.UseSwagger(); // localhost/swagger/index.html
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            // Middleware configuration
            // app.UseHttpsRedirection(); - not using https in development
            app.UseRouting(); // Configures routing for HTTP requests. Looks at endpoint of the http request and sends it to the appropriate controller
            app.UseCors("CorsPolicy"); // Using CORS middleware to handle cross-origin requests
            app.UseAuthorization(); // Adding authorization middleware
            // Directs middleware to endpoints
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // Mapping controllers to endpoints
            });
        }
    }
}
