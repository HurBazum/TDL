using Microsoft.Extensions.DependencyInjection;
using TDL.BLL;
using TDL.Interfaces;

namespace TDL.ViewModels.Tools
{
    public class ViewModelLocator
    {
        public static MainViewModels MainViewModels => App.Host.Services.GetRequiredService<MainViewModels>();
        public static AddTodoViewModel AddTodoViewModel => App.Host.Services.GetRequiredService<AddTodoViewModel>();
        public static TodoListViewModel TodoListViewModel => App.Host.Services.GetRequiredService<TodoListViewModel>();
    }
}
