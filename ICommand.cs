namespace MarioGame.Interfaces
{
    /// <summary>
    /// Optional: Defines a command for the Command Design Pattern, abstracting game actions from their triggers.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Executes the action defined by this command.
        /// </summary>
        void Execute();
    }
}