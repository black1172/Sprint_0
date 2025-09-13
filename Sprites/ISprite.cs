using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame.Interfaces
{
    /// <summary>
    /// Defines a common contract for any game sprite (e.g., static images, animated characters, text).
    /// </summary>
    public interface ISprite
    {
        /// <summary>
        /// Gets or sets the 2D position of the sprite on the screen.
        /// </summary>
        Vector2 Position { get; set; }

        /// <summary>
        /// Gets or sets the rotation of the sprite in radians.
        /// </summary>
        float Rotation { get; set; }

        /// <summary>
        /// Gets or sets the scale factor applied to the sprite. Can be uniform (float) or independent (Vector2) for x and y axes.
        /// </summary>
        Vector2 Scale { get; set; }

        /// <summary>
        /// Gets or sets the color mask (tint) applied to the sprite. Color.White applies no tint.
        /// Can also be used to adjust opacity.
        /// </summary>
        Color Color { get; set; }

        /// <summary>
        /// Gets or sets sprite effects like flipping horizontally, vertically, or both.
        /// </summary>
        SpriteEffects Effects { get; set; }

        /// <summary>
        /// Gets or sets the depth at which the sprite is rendered. Higher values are drawn on top when using appropriate SpriteSortMode.
        /// </summary>
        float LayerDepth { get; set; }

        /// <summary>
        /// Gets or sets the origin point of the sprite relative to its top-left corner, used as a reference for rotation and scaling.
        /// </summary>
        Vector2 Origin { get; set; }

        /// <summary>
        /// Gets the calculated width of the sprite, taking its scale into account.
        /// </summary>
        float Width { get; }

        /// <summary>
        /// Gets the calculated height of the sprite, taking its scale into account.
        /// </summary>
        float Height { get; }

        /// <summary>
        /// Updates the sprite's internal state, such as animation frames or movement logic.
        /// </summary>
        /// <param name="gameTime">A snapshot of the timing values for the current frame.</param>
        void Update(GameTime gameTime);

        /// <summary>
        /// Draws the sprite using the provided SpriteBatch.
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch instance used for batching draw calls.</param>
        void Draw(SpriteBatch spriteBatch);
    }
}

