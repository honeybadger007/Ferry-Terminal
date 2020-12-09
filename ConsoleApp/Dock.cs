using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class Dock
    {
        public int Id { get; private set; }
        public List<int> FerrysIds { get; set; }

        public Dock(int dockId)
        {
            Id = dockId;
            FerrysIds = new List<int>();
        }
    }
}
