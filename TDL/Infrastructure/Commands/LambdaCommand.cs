using TDL.Infrastructure.Commands.Base;

namespace TDL.Infrastructure.Commands
{
    public class LambdaCommand(Action<object> execute, Func<object, bool> canExecute) : Command
    {
        Action<object> _execute = execute;
        Func<object, bool> _canExecute = canExecute;
        public override bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter) ?? true;

        public override void Execute(object? parameter) => _execute(parameter);
    }
}