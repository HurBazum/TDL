﻿using System;
using System.Collections.Generic;
using System.Windows.Input;
using TDL.BLL;
using TDL.Infrastructure.Commands;
using TDL.Interfaces;
using TDL.ViewModels.Base;

namespace TDL.ViewModels
{
    public class AddTodoViewModel(IEntityService<TodoViewModel> entityService) : BaseViewModel
    {
        private readonly IEntityService<TodoViewModel> _entityService = entityService;

        private string _title = "add todo item";
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        private string _todoText = string.Empty;
        public string TodoText
        {
            get => _todoText;
            set => Set(ref _todoText, value);
        }

        private string _message = string.Empty;
        public string Message
        {
            get => _message;
            set => Set(ref _message, value);
        }

        ICommand? addTodoItemCmd;
        public ICommand AddTodoItemCmd => addTodoItemCmd ??= new LambdaCommand(AddTodoItemCmdExecute, CanAddTodoItemCmdExecuted);

        private async void AddTodoItemCmdExecute(object parameter)
        {
            var todoResponse = await _entityService.CreateAsync(new TodoViewModel { Content = TodoText });

            if(todoResponse.Value is null)
            {
                Message = "catch an ex";
            }
            else
            {
                TodoText = string.Empty;
                Message = $"todo was added {todoResponse.Value.Id}";
            }
        }

        private bool CanAddTodoItemCmdExecuted(object parameter)
        {
            if(TodoText == string.Empty)
            {
                return false;
            }

            return true;
        }


    }
}