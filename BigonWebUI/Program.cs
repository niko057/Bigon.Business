using Bigon.Business;
using Bigon.Data;
using Bigon.Infrastructure.Commons;
using Bigon.Infrastructure.Services.Abstracts;
using Bigon.Infrastructure.Services.Concretes;
using Microsoft.EntityFrameworkCore;

namespace BigonWebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            var cstring = builder.Configuration.GetConnectionString("cString");

            DataServiceInjection.InstallDataServices(builder.Services, builder.Configuration);

            builder.Services.Configure<EmailOptions>(
                cfg =>
                {
                    builder.Configuration.GetSection("emailAccount").Bind(cfg);
                });

            builder.Services.AddSingleton<IEmailService,EmailService>();

            builder.Services.AddSingleton<IDateTimeServive, DateTimeServive>();

            builder.Services.AddScoped<IIdentityService, IdentityService>();

            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(IBusinessReferance).Assembly);
            });

            var app = builder.Build();

           app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );
            app.UseStaticFiles();
            app.MapControllerRoute("default", "{controller=home}/{action=index}/{id?}");

           

            

            app.Run();
        }
    }
}