using SM_Programming_Exercise.Library.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM_Programming_Exercise.Library.Interfaces
{
    public interface IProtocolData
    {
        public int TableWidth { get; set; }
        public int TableHeight { get; set; }
        public int TileStartX { get; set; }
        public int TileStartY { get; set; }
        public IEnumerable<Command> CommandList { get; set; }

        public void Read();

        public void Populate();
    }
}