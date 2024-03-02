using permiakov_lab1.Command;
using System.ComponentModel;

namespace permiakov_lab1.ViewModel
{
    internal class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand CalculateCommand => new(
            execute => CalculateUserAge(),
            canExecute => { return true; });

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CalculateUserAge()
        {
            
        }
    }
}
