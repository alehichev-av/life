using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;
using life.Models;
using life.Services;
using MVVM.Commands;
using System.Windows.Input;
using System.Runtime.CompilerServices;

namespace life.ViewModels
{
    public class LifeViewModel
    {

        public CellsModel Cells { get; init; }
        public ICommand Resize { get; init; }
        public ICommand Step { get; init; }
        public ICommand Clear { get; init; }
        public int Rows { get; set; }
        public int Columns { get; set; }

        public CellsService service { get; init; }

        public class Point: INotifyPropertyChanged
        {
            public int x;
            public int y;
            public LifeViewModel model;
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            public ICommand toggleCommand { get; init; }
            public bool IsAlive { get
                {
                    return model.Cells.at(this.x, this.y);
                }
            }
            public void toggled()
            {
                OnPropertyChanged("IsAlive");
            }
            public Point(int x, int y, LifeViewModel model)
            {
                this.x = x;
                this.y = y;
                this.model = model;
                toggleCommand = new RelayCommand(() => { this.model.service.toggle(this.x, this.y, this.model.Cells);
                                                         OnPropertyChanged("IsAlive"); } );
                OnPropertyChanged("IsAlive");
            }
        }
        public ObservableCollection<Point> Coords { get; set; }
        

        private void updateCoords () {         
            Coords = new ObservableCollection<Point>();
            for (int i = 0; i < Rows; ++i)
                for (int j = 0; j < Columns; j++)
                    Coords.Add(new Point(j, i, this));
        }
        private void updateWholeField()
        {
            for (int i = 0; i < Rows; ++i)
                for (int j = 0; j < Columns; j++)
                    Coords[i * Columns + j].toggled();
        }

        public LifeViewModel()
        {
            Rows = 20;
            Columns = 20;
            updateCoords();
            Cells = new CellsModel(Rows, Columns);
            service = new CellsService();
            Resize = new RelayCommand(() => { service.Resize(Cells, Rows, Columns); });
            Step = new RelayCommand(() =>
            {
                service.Step(Cells);
                this.updateWholeField();
            });
            Clear = new RelayCommand(() => { service.clear(Cells); this.updateWholeField(); });
        }
    }
}
