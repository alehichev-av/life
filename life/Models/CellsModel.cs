using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace life.Models
{
    public class CellsModel
    {
        public ObservableCollection<bool> Cells { get; set; }
        public int x;
        public int y;
        public CellsModel (int x, int y)
        {
            Cells = new ObservableCollection<bool>(Enumerable.Repeat(false, x * y));
            this.x = x;
            this.y = y;
        }
        public bool at(int x, int y) { return Cells[x + this.x * y]; }
        public void set(int x, int y, bool val) { Cells[x + this.x * y] = val; }
    }
}
