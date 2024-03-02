using Permiakov.Lab1.Model;
using permiakov_lab1.Command;
using System;
using System.ComponentModel;
using System.Windows;

namespace permiakov_lab1.ViewModel
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private UserModel? _userModel;

        public event PropertyChangedEventHandler PropertyChanged;
        public DateTime BirthDate
        {
            get => _userModel?.Birthday ?? DateTime.Today;
            set
            {
                if (_userModel == null)
                {
                    _userModel = new UserModel(value);
                }
                else if (_userModel.Birthday != value)
                {
                    _userModel.Birthday = value;
                }
            }
        }

        public string AgeText => _userModel != null ? $"You are {_userModel.Age} years old."
            : "Please enter your birthdate.";
        public string BirthdayMessage => _userModel != null ? (_userModel.HasBirthday 
            ? "Happy birthday!" : "Today is not your birthday") : string.Empty;
        public string WesternZodiac => _userModel?.WesternSign ?? string.Empty;
        public string ChineseZodiac => _userModel?.ChineseSign ?? string.Empty;

        public RelayCommand CalculateCommand => new(
            execute => CalculateUserAge(),
            canExecute => { return true; });

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CalculateUserAge()
        {
            if (_userModel == null)
            {
                _userModel = new(DateTime.Today);
            }

            if (_userModel.Age is >= 0 and <= 135)
            {
                OnPropertyChanged(nameof(AgeText));
                OnPropertyChanged(nameof(BirthdayMessage));
                OnPropertyChanged(nameof(WesternZodiac));
                OnPropertyChanged(nameof(ChineseZodiac));
            }
            else
            {
                _ = MessageBox.Show("Age is invalid, try again please");
            }
        }
    }
}
