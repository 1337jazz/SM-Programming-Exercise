using SM_Programming_Exercise.Library.Enums;

namespace SM_Programming_Exercise.Library.Interfaces
{
    public interface ICommandable
    {
        public void ProcessCommand(Command command);

        public void ChangeBearing(Rotation rotation);

        public void Move(Command command);
    }
}