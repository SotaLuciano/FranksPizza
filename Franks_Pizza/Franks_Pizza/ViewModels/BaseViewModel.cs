using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Franks_Pizza.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetValue<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
                return;

            backingField = value;

            OnPropertyChanged(propertyName);
        }

        protected void AddValue(ref int backingField, int value, [CallerMemberName] string propertyName = null)
        {
            backingField += value;

            OnPropertyChanged(propertyName);
        }

        protected void SetAvatar(ref string backingField, string value, IPageService pageService, [CallerMemberName] string propertyName = null)
        {

        }
    }
}
