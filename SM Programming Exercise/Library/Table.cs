namespace SM_Programming_Exercise.Library
{
    public class Table
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Table(int width, int height)
        {
            // Initialise the initial width and height of the table
            Width = width;
            Height = height;
        }
    }
}