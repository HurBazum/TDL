using Microsoft.Extensions.DependencyInjection;
using TDL.BLL;
using TDL.Interfaces;

namespace TDL.ViewModels.Tools
{
    public static class ViewModelRegister
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services) => services
            .AddTransient<MainViewModels>()
            .AddTransient<AddTodoViewModel>()
            .AddTransient<TodoListViewModel>()
            .AddTransient<TodoViewModel>();
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddTransient<IEntityService<TodoViewModel>, TodoService<TodoViewModel>>();
    }
}