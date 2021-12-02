using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FileDefender_MAUI.ViewModels
{
    public class ViewModelBase : Mvvm.BindableBase
    {
        private bool _isBusy;
        private string _title;

        public string Title
        {
            get => _title;
            set
            {
                if (SetProperty(ref _title, value))
                {
                    RaisePropertyChanged(nameof(IsNotBusy));
                }
                    
            }
        }

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public bool IsNotBusy => !IsBusy;
    }
}
