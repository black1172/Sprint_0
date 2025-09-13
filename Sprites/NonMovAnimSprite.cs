using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Graphics; // Utilizes graphics classes developed in the library
using MarioGame.Interfaces;
using System; // For ArgumentNullException

namespace MarioGame.Sprites
{
    /// <summary>
    /// A concrete implementation of ISprite for an animated sprite whose position is fixed (non-moving).
    /// It cycles through animation frames but does not change its screen position internally.
    /// </summary>
    public class NonMovingAnimatedSprite : ISprite
    {
        // The internal MonoGameLibrary.Graphics.AnimatedSprite handles animation and rendering properties
        protected AnimatedSprite _internalAnimatedSprite;

        // ISprite properties, delegated to the internal animated sprite or managed directly
        public Vector2 Position { get; set; }
        public float Rotation { get => _internalAnimatedSprite.Rotation; set => _internalAnimatedSprite.Rotation = value; }
        public Vector2 Scale { get => _internalAnimatedSprite.Scale; set => _internalAnimatedSprite.Scale = value; }
        public Color Color { get => _internalAnimatedSprite.Color; set => _internalAnimatedSprite.Color = value; }
        public SpriteEffects Effects { get => _internalAnimatedSprite.Effects; set => _internalAnimatedSprite.Effects = value; }
        public float LayerDepth { get => _internalAnimatedSprite.LayerDepth; set => _internalAnimatedSprite.LayerDepth = value; }
        public Vector2 Origin { get => _internalAnimatedSprite.Origin; set => _internalAnimatedSprite.Origin = value; }

        public float Width => _internalAnimatedSprite.Width; // Inherited from Sprite
        public float Height => _internalAnimatedSprite.Height; // Inherited from Sprite

        /// <summary>
        /// Creates a new non-moving, animated sprite.
        /// </summary>
        /// <param name="animation">The animation sequence for this sprite.</param>
        /// <param name="initialPosition">The initial fixed position on the screen.</param>
        public NonMovingAnimatedSprite(Animation animation, Vector2 initialPosition)
        {
            if (animation == null) throw new ArgumentNullException(nameof(animation));
            _internalAnimatedSprite = new AnimatedSprite(animation); // Creates a new AnimatedSprite instance [11]
            Position = initialPosition;
        }

        /// <summary>
        /// Updates the animation frames of the sprite using the internal AnimatedSprite's Update method.
        /// The sprite's screen position is not updated internally.
        /// </summary>
        /// <param name="gameTime">A snapshot of the timing values.</param>
        public void Update(GameTime gameTime)
        {
            _internalAnimatedSprite.Update(gameTime); // [12] (implicitly by AnimatedSprite inheriting from Sprite, which has an update)
        }

        /// <summary>
        /// Draws the animated sprite at its current position using the internal AnimatedSprite's Draw method.
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch instance for drawing.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            _internalAnimatedSprite.Draw(spriteBatch, Position); // [12]
        }
    }
}