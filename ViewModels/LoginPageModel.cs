using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDefender_MAUI.ViewModels
{
    public class LoginPageModel : INotifyPropertyChanged
    {
        public string EntryValue { get; set; }
        public string TitleValue { get; set; }

        public Command ChangeTitleCommand { get; set; }
        public LoginPageModel()
        {
            ChangeTitleCommand = new Command(() =>
            {
                TitleValue = EntryValue;
                OnPropertyChanged(nameof(TitleValue));
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
