using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Eudwia.Server.Data;
using Eudwia.Server.Data.Contexts;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using System.Text;
using Eudwia.Server.Providers;
using Eudwia.Server.Settings;
using Eudwia.Shared.Authorization;
using Eudwia.Shared.Enums;
using FluentValidation.AspNetCore;

namespace Eudwia.Server;

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
        services.AddControllers().AddFluentValidation(s =>
        {
            s.RegisterValidatorsFromAssemblyContaining<Language>();
            s.DisableDataAnnotationsValidation = false;
        });
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Eudwia.Server",
                Description = "An ASP.NET Core API app for Eudwia"
            });
            c.EnableAnnotations();
            c.OperationFilter<AddResponseHeadersFilter>();
            c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>(); // Adds "(Auth)" to the summary so that you can see which endpoints have Authorization
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = " JWT Authorization header using the Bearer scheme. \r\n\r\n Put **_ONLY_** your JWT Bearer token on textbox below!"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());

        //configure appdbcontext
        services.AddScoped<DbContext, ApplicationDbContext>().AddDbContext<ApplicationDbContext>();

        services.AddSingleton<IContextConfiguration, DataContextConfiguration>();


        //configure identity
        services.Configure<IdentityOptions>(options =>
        {
            // Password settings.
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 8;
            options.Password.RequiredUniqueChars = 1;
        });

        services.AddIdentity<Member, IdentityRole<Guid>>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        var jwtSettings = Configuration.GetSection(JwtSettings.Position).Get<JwtSettings>();
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Issuer,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecurityKey))
            };
        });

        services.AddSingleton(jwtSettings);
        services.Configure<SuperAdminAccountSettings>(Configuration.GetSection(SuperAdminAccountSettings.Position));

        //configure authorization
        services.AddAuthorization(config =>
        {
            config.AddPolicy(Policies.IsSuperAdmin, Policies.IsSuperAdminPolicy());
            config.AddPolicy(Policies.IsAdmin, Policies.IsAdminPolicy());
            config.AddPolicy(Policies.IsUser, Policies.IsUserPolicy());
            config.AddPolicy(Policies.IsCurrentdUser, policy => policy.Requirements.Add(new ConnectedUserRequirement()));
        });

        //current user provider
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<ICurrentUserProvider, CurrentUserProvider>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Eudwia.Server v1"); });

            app.UseWebAssemblyDebugging();
        }

        app.UseHttpsRedirection();
        app.UseBlazorFrameworkFiles();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapFallbackToFile("index.html");
        });
    }
}
