using System.Collections.Generic;
using System.Windows.Forms;

public class KeyControls : IController
{
	// Implementation for keyboard input controller
	// Dictionary mapping Keys to action names
	public Dictionary<Keys, string> KeyBindings { get; set; } = new Dictionary<Keys, string>
	{
		{ Keys.W, "MoveUp" },
		{ Keys.A, "MoveLeft" },
		{ Keys.S, "MoveDown" },
		{ Keys.D, "MoveRight" },
		{ Keys.Space, "Jump" },
		{ Keys.D0, "Quit" },
		{ Keys.D1, "DisplaySingleFrameSprite" },
		{ Keys.D2, "DisplayAnimatedSpriteFixedPosition" },
		{ Keys.D3, "DisplaySingleFrameSpriteMoveUpDown" },
		{ Keys.D4, "DisplayAnimatedSpriteMoveLeftRight" }
	};
}
