using System;
using System.Windows.Input;

namespace JG.TechLearning.WPF.CarDiagnostic.GlobalCommonTypes
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action execute;
        private readonly Func<bool> canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public void Execute(object parameter) => execute?.Invoke();
        public bool CanExecute(object parameter) => canExecute == null || canExecute();

        public void OnCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

    }
}
