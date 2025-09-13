using Microsoft.Xna.Framework;

namespace MarioGame.Interfaces // Or MonoGameLibrary.Interfaces
{
    /// <summary>
    /// Defines a common contract for any game controller (e.g., keyboard, mouse, gamepad).
    /// </summary>
    public interface IController
    {
        /// <summary>
        /// Updates the state of the controller for the current frame.
        /// This method is crucial for refreshing input states each game cycle.
        /// </summary>
        /// <param name="gameTime">A snapshot of the timing values for the current frame.</param>
        void Update(GameTime gameTime);
		/// <summary>
    }
}

