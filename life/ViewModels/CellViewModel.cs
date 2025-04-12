using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using life.Utils;
using System.Runtime.CompilerServices;

namespace life.ViewModels
{
    public class CellViewModel : INotifyPropertyChanged
    {
        private bool _isAlive;
        public bool IsAlive
        {
            get => _isAlive;
            set
            {
                if (_isAlive == value) return;
                _isAlive = value;
                OnPropertyChanged(nameof(IsAlive));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        private ICommand toggleCommand;
        public ICommand ToggleCommand { get => toggleCommand; }

        public CellViewModel()
        {
            toggleCommand = new RelayCommand(_ => Toggle()); 
        }

        private void Toggle()
        {
            IsAlive = !IsAlive;
        }
       
    }
}
