namespace SM_Programming_Exercise.Library.Interfaces
{
    public interface ITable
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int[,] Grid { get; set; }        
    }
}