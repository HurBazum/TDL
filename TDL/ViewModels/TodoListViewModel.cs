using System.Collections.ObjectModel;
using System.Windows.Input;
using TDL.Infrastructure.Commands;
using TDL.Interfaces;
using TDL.ViewModels.Base;

namespace TDL.ViewModels
{
    public class TodoListViewModel : BaseViewModel
    {
        private readonly IEntityService<TodoViewModel> _entityService;
        public ObservableCollection<TodoViewModel>? Todos { get; set; }

        public TodoListViewModel(IEntityService<TodoViewModel> entityService)
        {
            _entityService = entityService;
            InitializeTodos();
        }

        private async void InitializeTodos()
        {
            var list = (await _entityService.GetAllAsync()).Value;
            Todos = new(list);
            OnPropertyChanged(nameof(Todos));
        }

        #region properties

        private string _deleteBtnContent = "Delete";
        public string DeleteBtnContent
        {
            get => _deleteBtnContent;
            set => Set(ref _deleteBtnContent, value);
        }

        private string _updateBtnContent = "Update";
        public string UpdateBtnContent
        {
            get => _updateBtnContent;
            set => Set(ref _updateBtnContent, value);
        }

        private TodoViewModel? selectedTodo;
        public TodoViewModel? SelectedTodo
        {
            get => selectedTodo;
            set => Set(ref selectedTodo, value);
        }

        #endregion


        #region cmds

        private ICommand? deleteTodoCmd;
        public ICommand DeleteTodoCmd => deleteTodoCmd ??= new LambdaCommand(DeleteTodoCmdExecute, TodoWasSelected);

        private bool TodoWasSelected(object parameter)
        {
            if(SelectedTodo is not null)
            {
                return true;
            }

            return false;
        }

        private async void DeleteTodoCmdExecute(object parameter)
        {
            var result = await _entityService.DeleteAsync(SelectedTodo);

            if(result.Value is not null)
            {
                SelectedTodo = null;
                var todo = Todos.First(x => x.Id == result.Value.Id);
                Todos.Remove(todo);
                OnPropertyChanged(nameof(Todos));
            }
            else
            {
                DeleteBtnContent = "error";
            }
        }

        private ICommand? updateTodoCmd;
        public ICommand UpdateTodoCmd => updateTodoCmd ??= new LambdaCommand(UpdateTodoCmdExecute, TodoWasSelected);

        private async void UpdateTodoCmdExecute(object parameter)
        {
            var result = await _entityService.UpdateAsync(SelectedTodo);
            if(result.Value is not null)
            {
                SelectedTodo = null;
                var todo = Todos.First(x => x.Id == result.Value.Id);
                Todos[Todos.IndexOf(todo)] = result.Value;
            }
            else
            { 
                UpdateBtnContent = "error";
            }
        }

        private ICommand? selectTodoByCheckBoxCmd;
        public ICommand SelectTodoByCheckBoxCmd => selectTodoByCheckBoxCmd ??= new LambdaCommand(SelectTodoByCheckBoxCmdExecute, CanSelectTodoByCheckBoxCmdExecuted);

        private bool CanSelectTodoByCheckBoxCmdExecuted(object parameter) => true;

        private void SelectTodoByCheckBoxCmdExecute(object parameter)
        {
            if(parameter is (TodoViewModel))
            {
                SelectedTodo = (TodoViewModel)parameter;
            }
        }

        #endregion
    }
}