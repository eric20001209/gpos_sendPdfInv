using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using gpos_sendPdfInv.Entities;
using Microsoft.EntityFrameworkCore;
using gpos_sendPdfInv.Services;
using System.IO;
using DinkToPdf.Contracts;
using DinkToPdf;

namespace gpos_sendPdfInv
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
			services.AddDbContext<admingposContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("appContext")));
			services.AddScoped<admingposContext>();
			services.AddScoped<IInvoice,Utility>();
			services.AddTransient<iMailService, MailService>();

			Path.Combine(Directory.GetCurrentDirectory(), "libwkhtmltox.dll");
			services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));   //DinkToPdf DI

			services.AddCors(options =>
			{
				options.AddDefaultPolicy(builder =>
					builder.SetIsOriginAllowed(_ => true)
					.AllowAnyMethod()
					.AllowAnyHeader()
					.AllowCredentials());
			});
			services.AddControllers();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseAuthentication();
			app.UseStatusCodePages();
			app.UseDefaultFiles();
			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();


			app.UseCors();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
