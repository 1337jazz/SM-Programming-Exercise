using SM_Programming_Exercise.Library.Base;

namespace SM_Programming_Exercise.Library.Entities
{
    public class Table : GridBase
    {
        public Table(int width, int height) : base(width, height)
        {
        }

        // Possibility to override SetGridShape()
        // Possibility to override BoundaryBreached()
    }
}