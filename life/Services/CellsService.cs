using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using life.Models;
using System.Collections.ObjectModel;

namespace life.Services
{
    public class CellsService
    {
        
        public void Resize(CellsModel model, int x, int y)
        {
            model.Cells = new ObservableCollection<bool>(Enumerable.Repeat(false, x * y));
        }
        public void Step(CellsModel model)
        {
            List<bool> newCells = new List<bool>(Enumerable.Repeat(false, model.x * model.y));
            for (int i = 0; i < model.y; ++i)
            {
                for (int j = 0; j < model.x; ++j)
                {
                    int count = 0;
                    for (int k = 0; k < 9; ++k)
                    {
                        int dx = k % 3 - 1;
                        int dy = k / 3 - 1;
                        if (dx == 0 && dy == 0)
                            continue;
                        int rx = (dx + j + 9999 * model.x) % model.x;
                        int ry = (dy + i + 9999 * model.y) % model.y;
                        if (model.at(rx, ry))
                            count += 1;
                    }
                    if (model.at(j, i))
                    {
                        if (count == 2 || count == 3)
                            newCells[j + model.x * i] = true;
                    }
                    else if (count == 3)
                        newCells[j + model.x * i] = true;
                }
            }
            model.Cells = new ObservableCollection<bool>(newCells);
        }
        public void toggle(int x, int y, CellsModel model)
        {
            model.Cells[x + model.x * y] = !(model.Cells[x + model.x * y]);
        }
        public void clear(CellsModel model)
        {
            List<bool> newCells = new List<bool>(Enumerable.Repeat(false, model.x * model.y));
            model.Cells = new ObservableCollection<bool>(newCells);
        }
    }
}
