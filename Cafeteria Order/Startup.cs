using CafeteriaOrders.data;
using CafeteriaOrders.logic.GenericRepo;
using CafeteriaOrders.Service;
using CafeteriaOrders.Service.CartServices;
using CafeteriaOrders.Service.Registeration;
using CafeteriaOrders.Service.Review;
using CafeteriaOrders.Service.VerificationServices;
using CafeteriaOrders.Service.VerificationServices.OTPConfig;
using CafeteriaOrders.UnitOfWork.GenericUnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafeteria_Order
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();
            /*adding automapping...*/
            services.AddAutoMapper(typeof(Startup));

            // adding service layer...
            services.AddScoped<IReviewService, ReviewServices>();
            services.AddScoped<ImealServices, MealServices>();
            services.AddScoped<ICartService, CartServices>();
            services.AddScoped<IUserServicescs, UserServicescs>();

            /*add twilo verification*/
            
            services.AddScoped<IVerification, Verification>();
            //services.AddSingleton<IVerification>(new Verification(
            //    Configuration.GetSection("Twilio").Get<TwilioConfig>()));
            services.Configure<TwilioConfig>(Configuration);

            //services.AddSingleton<IVerification>(new Verification(
                
            //    ));
            //Configuration.GetSection("Twilio").Get<Configuration.Twilio>()





            /* Injecting IUnitOfWork in our application
             * we need to register IUnitOfWork and IRepository<T> to our Dependency Injection container
             * DI Microsoft container for ASP NET Core apps.
            ** Unit of work is created we need to update the startup class,
            ** so it will be injected in our dependency injection framework
            */
            services.AddScoped<IUnitOfWork, UnitOfWorkGeneric>();
                services.AddScoped(typeof(IGenericRepository<>), typeof (GenericRepository<>));
            


            /* to handle json parsing for -> list of cartitem within each cart ..*/
            services.AddControllers().AddNewtonsoftJson(x =>
             x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddApplicationInsightsTelemetry();

            //services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentity<IdentityUser, IdentityRole>(option =>
            {
                option.User.RequireUniqueEmail = false;
                option.Password.RequireLowercase = false;
                option.Password.RequireUppercase = false;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireDigit = false;
                option.Password.RequiredLength = 4;
            }).AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();

            
            // JWT Configuration
            var jwtSettings = Configuration.GetSection("JwtSettings");
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // one for api
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; //for web
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
                    ValidAudience = jwtSettings.GetSection("validAudience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.GetSection("securityKey").Value))
                };
            });
            /*Adding sesssions*/
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = System.TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
