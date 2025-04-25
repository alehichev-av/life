using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace life.Models
{
    internal class CellModel
    {
        public bool IsAlive {
            get;
            set;
        }
        public CellModel(bool alive = false)
        {
            IsAlive = alive;
        }
        public void Toggle()
        {
            IsAlive = !IsAlive;
        }
    }
}
