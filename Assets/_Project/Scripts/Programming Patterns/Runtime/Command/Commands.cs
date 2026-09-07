namespace Patterns
{
    public interface IUndoableCommand : ICommand
    {
        void Undo();
        void Redo();
    }
}
