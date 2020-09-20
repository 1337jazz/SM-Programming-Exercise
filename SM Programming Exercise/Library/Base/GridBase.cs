using SM_Programming_Exercise.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM_Programming_Exercise.Library.Base
{
    public class GridBase
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int[,] Grid { get; set; }

        public GridBase(int width, int height)
        {
            // Initialise the initial width and height of the grid
            Width = width;
            Height = height;

            // Set the shape of the grid
            SetGridShape();
        }

        /// <summary>
        /// Set which elements of the grid should be on (meaning the tile move to it,
        /// represented by '1') and off (meaning the the tile will fall off, represented by '0').
        /// By default this method turns all of the elements "on" so the default shape is a
        /// rectangle of area Width * Height, however the child class can override this method.
        /// </summary>
        public virtual void SetGridShape()
        {
            Grid = new int[Width, Height];

            for (int row = 0; row < Width; row++)
            {
                for (int column = 0; column < Height; column++)
                {
                    Grid[row, column] = 1;
                }
            }
        }

        /// <summary>
        /// Checks if the boundary is breached. The child class can override this method
        /// in order to implement boundary logic of a different shape
        /// </summary>
        /// <param name="gridRow"></param>
        /// <param name="gridColumn"></param>
        /// <returns></returns>
        public virtual bool BoundaryBreached(int gridRow, int gridColumn)
        {
            if (gridRow > Width - 1 || gridRow < 0) return true;
            if (gridColumn > Height - 1 || gridColumn < 0) return true;

            return Grid[gridRow, gridColumn] == 0 ? true : false;
        }
    }
}