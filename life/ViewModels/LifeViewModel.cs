using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace life.ViewModels
{
    public class LifeViewModel
    {
        private int rows = 20;
        private int columns = 20;
        public ObservableCollection<CellViewModel> Cells { get; }
        public int Rows { get => rows; }
        public int Columns { get => columns; }

        public LifeViewModel()
        {
            Cells = new ObservableCollection<CellViewModel>();
            for (int i = 0; i < Rows * Columns; ++i)
                Cells.Add(new CellViewModel()); 
        }
    }
}
