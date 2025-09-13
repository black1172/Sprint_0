using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Graphics; // Utilizes graphics classes developed in the library
using MarioGame.Interfaces;
using System; // For ArgumentNullException

namespace MarioGame.Sprites
{
    /// <summary>
    /// A concrete implementation of ISprite for a moving, non-animated sprite.
    /// Its position updates based on an internal velocity, but it uses a single static texture region.
    /// </summary>
    public class MovingNonAnimatedSprite : ISprite
    {
        // The internal MonoGameLibrary.Graphics.Sprite handles core rendering properties
        protected MonoGameLibrary.Graphics.Sprite _internalSprite;

        // ISprite properties, delegated to the internal sprite or managed directly
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; } // For internal movement logic

        public float Rotation { get => _internalSprite.Rotation; set => _internalSprite.Rotation = value; }
        public Vector2 Scale { get => _internalSprite.Scale; set => _internalSprite.Scale = value; }
        public Color Color { get => _internalSprite.Color; set => _internalSprite.Color = value; }
        public SpriteEffects Effects { get => _internalSprite.Effects; set => _internalSprite.Effects = value; }
        public float LayerDepth { get => _internalSprite.LayerDepth; set => _internalSprite.LayerDepth = value; }
        public Vector2 Origin { get => _internalSprite.Origin; set => _internalSprite.Origin = value; }

        public float Width => _internalSprite.Width; // Calculated from TextureRegion and Scale
        public float Height => _internalSprite.Height; // Calculated from TextureRegion and Scale

        /// <summary>
        /// Creates a new moving, non-animated sprite.
        /// </summary>
        /// <param name="region">The texture region to use for this sprite.</param>
        /// <param name="initialPosition">The initial position on the screen.</param>
        /// <param name="initialVelocity">The initial velocity for movement (pixels per second).</param>
        public MovingNonAnimatedSprite(TextureRegion region, Vector2 initialPosition, Vector2 initialVelocity)
        {
            if (region == null) throw new ArgumentNullException(nameof(region));
            _internalSprite = new MonoGameLibrary.Graphics.Sprite(region); // Creates a new Sprite instance [9]
            Position = initialPosition;
            Velocity = initialVelocity;
        }

        /// <summary>
        /// Updates the sprite's position based on its velocity and elapsed game time.
        /// No animation frame updates as it's non-animated.
        /// </summary>
        /// <param name="gameTime">A snapshot of the timing values.</param>
        public void Update(GameTime gameTime)
        {
            Position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds; // Updates position based on delta time [13]
        }

        /// <summary>
        /// Draws the sprite at its current position using the internal MonoGameLibrary.Graphics.Sprite's Draw method.
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch instance for drawing.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            _internalSprite.Draw(spriteBatch, Position); // [10]
        }
    }
}