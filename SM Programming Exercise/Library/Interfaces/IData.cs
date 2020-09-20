using SM_Programming_Exercise.Library.Enums;
using System.Collections.Generic;

namespace SM_Programming_Exercise.Library.Interfaces
{
    /// <summary>
    /// This interface dictates the data the application is expected to receive
    /// </summary>
    public interface IData
    {
        public int TableWidth { get; set; }
        public int TableHeight { get; set; }
        public int TileStartX { get; set; }
        public int TileStartY { get; set; }
        public IEnumerable<Command> CommandList { get; set; }
    }
}