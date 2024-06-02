using Microsoft.Extensions.DependencyInjection;
using TDL.DAL.Repositories;
using TDL.DAL.Entities;
using TDL.Interfaces;

namespace TDL.DAL
{
    public static class DALRegister
    {
        public static IServiceCollection Adddatabase(this IServiceCollection services) => services
            .AddDbContext<TodoContext>(ServiceLifetime.Singleton);

        public static IServiceCollection AddRepositories(this IServiceCollection services) => services
            .AddTransient<IRepository<TodoEntity>, Repository>();
    }
}
