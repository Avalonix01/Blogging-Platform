using BlogPlatform.Features.DTOs.CommentDTOs;
using BlogPlatform.Features.Comments.Create;
using BlogPlatform.Features.DTOs.BlogDTOs;
using BlogPlatform.Features.Blogs.Create;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using BlogPlatform.Data;
using FluentValidation;

namespace BlogPlatform.Extensions;

public static class DependencyInjection
{
    public static void AddServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<BlogDbContext>(opts =>
        {
            opts.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        });

        services.AddAuthorization();

        services.AddIdentityApiEndpoints<IdentityUser>()
            .AddEntityFrameworkStores<BlogDbContext>();

        services.AddSingleton(TimeProvider.System); // For ASP.NET Identity to work properly

        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(typeof(IAssemblyMarker).Assembly));

        services.AddScoped<IValidator<BlogCreateDto>, CreateBlogValidator>();
        services.AddScoped<IValidator<CommentCreateDto>, CreateCommentValidator>();
        
        services.AddHttpContextAccessor();
        
        #region Swagger configuring
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(opts =>
        {
            opts.SwaggerDoc("v1", new OpenApiInfo()
            {
                Title = "Blogging Platform",
                Version = "v1"
            });

            opts.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                In = ParameterLocation.Header,
                Description = "Please enter a token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer"
            });

            opts.AddSecurityRequirement(new OpenApiSecurityRequirement()
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
                    []
                }
            });
        });
        #endregion
    }
}