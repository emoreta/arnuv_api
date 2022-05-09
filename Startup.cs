using arnuv_api.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace arnuv_api
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
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "arnuv_api", Version = "v1" });
            });
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );


            services.AddDbContext<DbContextUser>(options => options.UseSqlServer(Configuration.GetConnectionString("ArnuvConnection")))
                .AddDbContext<DbContextIva>(options => options.UseSqlServer(Configuration.GetConnectionString("ArnuvConnection")))
                .AddDbContext<DbContextAccountbank>(options => options.UseSqlServer(Configuration.GetConnectionString("ArnuvConnection")))
                .AddDbContext<DbContextRole>(options => options.UseSqlServer(Configuration.GetConnectionString("ArnuvConnection")))
                .AddDbContext<DbContextRolemenu>(options => options.UseSqlServer(Configuration.GetConnectionString("ArnuvConnection")))
                .AddDbContext<DbContextMenu>(options => options.UseSqlServer(Configuration.GetConnectionString("ArnuvConnection")))
                .AddDbContext<DbContextAdditionalcosts>(options => options.UseSqlServer(Configuration.GetConnectionString("ArnuvConnection")))
                .AddDbContext<DbContextCredittype>(options => options.UseSqlServer(Configuration.GetConnectionString("ArnuvConnection")))
                .AddDbContext<DbContextDetailaccountpay>(options => options.UseSqlServer(Configuration.GetConnectionString("ArnuvConnection")))
                .AddDbContext<DbContextFile>(options => options.UseSqlServer(Configuration.GetConnectionString("ArnuvConnection")))
                .AddDbContext<DbContextPettycash>(options => options.UseSqlServer(Configuration.GetConnectionString("ArnuvConnection")))
                .AddDbContext<DbContextProduct>(options => options.UseSqlServer(Configuration.GetConnectionString("ArnuvConnection")))
                .AddDbContext<DbContextProvider>(options => options.UseSqlServer(Configuration.GetConnectionString("ArnuvConnection")))
                .AddDbContext<DbContextPurchases>(options => options.UseSqlServer(Configuration.GetConnectionString("ArnuvConnection")))
                .AddDbContext<DbContextStorage>(options => options.UseSqlServer(Configuration.GetConnectionString("ArnuvConnection")))
                .AddDbContext<DbContextTypeprovider>(options => options.UseSqlServer(Configuration.GetConnectionString("ArnuvConnection")))
                .AddDbContext<DbContextMenu>(options => options.UseSqlServer(Configuration.GetConnectionString("ArnuvConnection")))
                .AddDbContext<DbContextArnuv>(options => options.UseSqlServer(Configuration.GetConnectionString("ArnuvConnection")))
                .AddDbContext<DbContextAccountpay>(options => options.UseSqlServer(Configuration.GetConnectionString("ArnuvConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "arnuv_api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(builder =>
            {
                builder.WithOrigins("http://localhost:3000");
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
