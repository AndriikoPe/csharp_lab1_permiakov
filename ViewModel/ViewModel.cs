using System.ComponentModel;

namespace permiakov_lab1.ViewModel
{
    internal class ViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModel()
        {
        }

        private void ExecuteCalculate(object parameter)
        {
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
