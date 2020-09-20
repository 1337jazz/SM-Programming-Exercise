using SM_Programming_Exercise.Library.Enums;
using SM_Programming_Exercise.Library.Interfaces;
using System.Collections.Generic;

namespace SM_Programming_Exercise.Library.Base
{
    /// <summary>
    /// Base class for data entry
    /// </summary>
    public abstract class InputBase : IData
    {
        public int TableWidth { get; set; }
        public int TableHeight { get; set; }
        public int TileStartX { get; set; }
        public int TileStartY { get; set; }
        public IEnumerable<Command> CommandList { get; set; }

        /// <summary>
        /// This constructor helps with testability
        /// </summary>
        /// <param name="read">True by default, dictates if the data should be read</param>
        public InputBase(bool read = true)
        {
            if (read) Read();
        }

        /// <summary>
        /// Read the data. The child class is forced to implement this method
        /// </summary>
        protected abstract void Read();
    }
}