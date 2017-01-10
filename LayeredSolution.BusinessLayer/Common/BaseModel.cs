using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LayeredSolution.BusinessLayer.Common
{
    public class BaseModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }
        protected virtual bool OnPropertyChanged<T>(
            ref T valueRef, T newValue, 
            [CallerMemberName] string propertyName = null)
        {
            if (Equals(valueRef, newValue)) return false;
            valueRef = newValue;
            PropertyChanged?.Invoke(this, 
                new PropertyChangedEventArgs(propertyName));
            return true;
        }
    }
}
