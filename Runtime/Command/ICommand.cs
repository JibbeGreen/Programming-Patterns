namespace Patterns 
{
    public interface ICommand
    {
        public string Name {get; }
        public bool Execute();
    }
}
