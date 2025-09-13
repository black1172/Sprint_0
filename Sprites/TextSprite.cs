using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MarioGame.Interfaces;
using System; // For ArgumentNullException

namespace MarioGame.Sprites
{
    /// <summary>
    /// A concrete implementation of ISprite for displaying text using SpriteFont.
    /// </summary>
    public class TextSprite : ISprite
    {
        public SpriteFont Font { get; set; } // The font asset to use for rendering [16]
        public string TextContent { get; set; } // The actual string content to display

        // ISprite properties for drawing text, directly managed by this class
        public Vector2 Position { get; set; }
        public float Rotation { get; set; } = 0.0f;
        public Vector2 Scale { get; set; } = Vector2.One;
        public Color Color { get; set; } = Color.White;
        public SpriteEffects Effects { get; set; } = SpriteEffects.None;
        public float LayerDepth { get; set; } = 0.0f;
        public Vector2 Origin { get; set; } = Vector2.Zero;

        /// <summary>
        /// Gets the calculated width of the text string based on the font and content. [17]
        /// </summary>
        public float Width => Font?.MeasureString(TextContent).X ?? 0;

        /// <summary>
        /// Gets the calculated height of the text string based on the font and content. [17]
        /// </summary>
        public float Height => Font?.MeasureString(TextContent).Y ?? 0;

        /// <summary>
        /// Creates a new text sprite.
        /// </summary>
        /// <param name="font">The SpriteFont to use for rendering.</param>
        /// <param name="textContent">The text string to display.</param>
        /// <param name="initialPosition">The initial position on the screen.</param>
        public TextSprite(SpriteFont font, string textContent, Vector2 initialPosition)
        {
            Font = font ?? throw new ArgumentNullException(nameof(font)); // [16]
            TextContent = textContent ?? "";
            Position = initialPosition;
        }

        /// <summary>
        /// Text sprites typically do not have internal update logic, though their content or position
        /// can be updated externally in response to game events (e.g., score changes).
        /// </summary>
        /// <param name="gameTime">A snapshot of the timing values.</param>
        public void Update(GameTime gameTime)
        {
            // No operation
        }

        /// <summary>
        /// Draws the text string using the SpriteBatch.DrawString method, which is specific to text rendering. [18]
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch instance for drawing.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            if (Font != null && !string.IsNullOrEmpty(TextContent))
            {
                spriteBatch.DrawString(
                    Font,
                    TextContent,
                    Position,
                    Color,
                    Rotation,
                    Origin,
                    Scale,
                    Effects,
                    LayerDepth
                );
            }
        }
    }
}