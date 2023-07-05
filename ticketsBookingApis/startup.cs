using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ticketsBookingApis.Data;
using ticketsBookingApis.Models;

namespace ticketsBookingApis
{
    public class startup
    {
        public startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
         //   services.AddRazorPages();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TicketApi", Version = "v1" });
            });
            services.AddDbContext<MovieDb>(opt => opt.UseMySql(Configuration["DefaultConnectionString"], new MySqlServerVersion(new
                 Version(8, 0, 11) ) ) ) ;
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
            }));

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("CorsPolicy");
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmployeeAPI v1"));
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
        }

    }
}
