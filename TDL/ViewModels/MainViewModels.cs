using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;
using TDL.Infrastructure.Commands;
using TDL.ViewModels.Base;

namespace TDL.ViewModels
{
    public class MainViewModels : BaseViewModel
    {
        private BaseViewModel _viewModel = App.Host.Services.GetRequiredService<AddTodoViewModel>();

        public BaseViewModel ViewModel
        {
            get => _viewModel;
            set => Set(ref _viewModel, value);
        }

        private string _title = "TodoApp";
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
        public MainViewModels()
        {

        }

        #region cmds

        private ICommand? toListCmd;
        public ICommand ToListCmd => toListCmd ??= new LambdaCommand(ToListCmdExecute, CanToListCmdExecuted);

        private bool CanToListCmdExecuted(object parameter)
        {
            if(ViewModel is TodoListViewModel)
            {
                return false;
            }
            return true;
        }

        private void ToListCmdExecute(object parameter)
        {
            ViewModel = App.Host.Services.GetRequiredService<TodoListViewModel>();
        }

        private ICommand? toAddCmd;
        public ICommand ToAddCmd => toAddCmd ??= new LambdaCommand(ToAddCmdExecute, CanAddCmdExecuted);

        private bool CanAddCmdExecuted(object parameter)
        {
            if(ViewModel is AddTodoViewModel)
            {
                return false;
            }

            return true;
        }

        private void ToAddCmdExecute(object parameter)
        {
            ViewModel = App.Host.Services.GetRequiredService<AddTodoViewModel>();
        }

        #endregion
    }
}