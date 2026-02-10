using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Application.Mappings;
using CleanArchMVC.Application.Services;

using CleanArchMVC.Domain.Interfaces;
using CleanArchMVC.Infra.Data.Context;
using CleanArchMVC.Infra.Data.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMVC.infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryServices, CategoryService>();
            services.AddScoped<IProductServices, ProductService>();
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
            
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ProductService).Assembly));
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CategoryService).Assembly));

            var myHandlers = AppDomain.CurrentDomain.Load("CleanArchMVC.Application");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(myHandlers));


            return services;
        }
    }
}
