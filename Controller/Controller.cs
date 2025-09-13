using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary.Input;
using MarioGame.Interfaces;

namespace MarioGame.Controller
{
	public class KeyControls : IController
	{
		/// <summary>
		/// A concrete controller for keyboard input, implementing IController.
		/// It encapsulates the functionality of MonoGameLibrary.Input.KeyboardInfo.
		/// </summary>
		public class CustomKeyboardController : IController
		{
			private KeyboardInfo _keyboardInfo; // Wraps the KeyboardInfo class from the library

			/// <summary>
			/// Initializes a new instance of the CustomKeyboardController.
			/// </summary>
			public CustomKeyboardController()
			{
				_keyboardInfo = new KeyboardInfo(); // Initializes KeyboardInfo with current state
			}

			/// <summary>
			/// Updates the keyboard's state by calling the underlying KeyboardInfo's Update method.
			/// </summary>
			/// <param name="gameTime">A snapshot of the timing values.</param>
			public void Update(GameTime gameTime)
			{
				_keyboardInfo.Update();
			}

			/// <summary>
			/// The keyboard is generally considered always connected in a desktop environment.
			/// </summary>
			public bool IsConnected => true;

			// Exposing specific keyboard input query methods from KeyboardInfo
			public bool IsKeyDown(Keys key) => _keyboardInfo.IsKeyDown(key);
			public bool IsKeyUp(Keys key) => _keyboardInfo.IsKeyUp(key);
			public bool WasKeyJustPressed(Keys key) => _keyboardInfo.WasKeyJustPressed(key); // Detects single-frame presses
			public bool WasKeyJustReleased(Keys key) => _keyboardInfo.WasKeyJustReleased(key); // Detects single-frame releases
		}
	}
}
