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
using gpos_sendPdfInv.Services.Repositories;
using System.IO;
using DinkToPdf.Contracts;
using DinkToPdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Http;
using gpos_sendPdfInv.Security.Handlers;
using gpos_sendPdfInv.Security.Requirements;

namespace gpos_sendPdfInv
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public static IConfiguration Configuration { get; private set; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			/*	apply authorize globally*/
			services.AddAuthorization(options =>
			{
				options.FallbackPolicy = new AuthorizationPolicyBuilder()
					.RequireAuthenticatedUser()
					.Build();
			});

			//register DbContext
			services.AddDbContext<admingposContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("appContext")));
			services.AddScoped<admingposContext>();
			/** register services **/
			services.AddScoped<IInvoice,gpos_sendPdfInv.Services.Utility>();
			services.AddScoped<ISetting,SettingRepository>();
			services.AddScoped<IItem,ItemRepository>();
			services.AddTransient<iMailService, MailService>();
			//register migration
			services.AddScoped<Migration>();

			/**	register dll for DinkToPdf	**/
			Path.Combine(Directory.GetCurrentDirectory(), "libwkhtmltox.dll");
			services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));   //DinkToPdf DI

			/**	add httpcontext service**/
			services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddHttpContextAccessor();

			/*add handlers to DI*/
			services.AddSingleton<IAuthorizationHandler, CurrentUserRequirementHandler>();

			/*	add authorizations */
			services.AddAuthorization(options =>
			{
				options.AddPolicy(Constants.CURRENT_USER, policy => policy.Requirements.Add(new CurrentUserRequirement()));
			});
			//Cors
			services.AddCors(options =>
			{
				options.AddDefaultPolicy(builder =>
					builder.SetIsOriginAllowed(_ => true)
					.AllowAnyMethod()
					.AllowAnyHeader()
					.AllowCredentials());
			});

			/**	validation Token lifespan	**/
			services.Configure<DataProtectionTokenProviderOptions>(opt =>
			{
				opt.TokenLifespan = TimeSpan.FromDays(3);
			});
			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			})
					.AddJwtBearer(options =>
					{
						options.RequireHttpsMetadata = false;
						options.SaveToken = true;
						options.TokenValidationParameters = new TokenValidationParameters
						{
							ValidateLifetime = true,
							RequireExpirationTime = true,
							ValidateIssuerSigningKey = true,
							ValidateIssuer = true,
							ValidIssuer = Configuration["Token:Issuer"], // "http//localhost:8088",
							ValidateAudience = true,
							ValidAudience = Configuration["Token:Audience"],   //"http//localhost:8088",
							IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Token:TokenSecretKey"]))
						};
					})
					.AddGoogle(options =>
					{
						IConfigurationSection googleAuthNSection =
								Configuration.GetSection("Authentication:Google");

						options.ClientId = Configuration["Providers:Google:ClientId"];
						options.ClientSecret = Configuration["Providers:Google:ClientSecret"];
						options.SaveTokens = true;
						options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
						options.ClaimActions.MapJsonKey(ClaimTypes.Name, "name");
						options.ClaimActions.MapJsonKey(ClaimTypes.GivenName, "given_name");
						options.ClaimActions.MapJsonKey(ClaimTypes.Surname, "family_name");
						options.ClaimActions.MapJsonKey("urn:google:profile", "link");
						options.ClaimActions.MapJsonKey(ClaimTypes.Email, "email");
						options.ClaimActions.MapJsonKey("picture", "picture");
					})
				.AddMicrosoftAccount(options => {
				options.ClientId = Configuration["Providers:Microsoft:ClientId"];// "1158ee1a-c458-447c-a938-04e6189b9425";
				options.ClientSecret = Configuration["Providers:Microsoft:ClientSecret"];// "sDY~4-n9.zD9.qyKJHN-D4iN669~7vMux6";
			});
			services.AddControllers().AddNewtonsoftJson(action =>action.SerializerSettings.ContractResolver = new DefaultContractResolver());
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env , Migration migration)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseDefaultFiles();
			app.UseStatusCodePages();
			app.UseDefaultFiles();
			app.UseHttpsRedirection();

			app.UseCors();
			app.UseRouting();

			migration.migration().Wait();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
