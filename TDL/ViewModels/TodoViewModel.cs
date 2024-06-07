using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TDL.Infrastructure.Commands;
using TDL.Interfaces;
using TDL.ViewModels.Base;

namespace TDL.ViewModels
{
    public class TodoViewModel : BaseViewModel, IEntity
    {
        public int Id { get; set; }

        private string _content = string.Empty;
        public string Content
        {
            get => _content;
            set => Set(ref _content, value);
        }

        private bool _isCompleted = false;
        public bool IsCompleted
        {
            get => _isCompleted;
            set => Set(ref _isCompleted, value);
        }

        private ICommand? doneCmd;
        public ICommand DoneCmd => doneCmd ??= new LambdaCommand(DoneCmdExecute, CanDoneCmdExecuted);

        private bool CanDoneCmdExecuted(object parameter) => true;

        private async void DoneCmdExecute(object parameter)
        {
            var service = App.Host.Services.GetRequiredService<IEntityService<TodoViewModel>>();

            if (service != null)
            {
                Content += "g";
                await service.UpdateAsync(this);
            }
        }

        public override string ToString()
        {
            return $"This is {Id} todo, content: {Content}\nstatus: {IsCompleted}";
        }
    }
}