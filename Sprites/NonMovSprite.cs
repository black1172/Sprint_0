using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Graphics; // Utilizes graphics classes developed in the library
using MarioGame.Interfaces;
using System; // For ArgumentNullException

namespace MarioGame.Sprites
{
    /// <summary>
    /// A concrete implementation of ISprite for a non-moving, non-animated visual element.
    /// It draws a single static texture region at a specified position.
    /// </summary>
    public class NonMovingNonAnimatedSprite : ISprite
    {
        // The internal MonoGameLibrary.Graphics.Sprite handles core rendering properties
        protected MonoGameLibrary.Graphics.Sprite _internalSprite;

        // ISprite properties, delegated to the internal sprite or managed directly
        public Vector2 Position { get; set; }
        public float Rotation { get => _internalSprite.Rotation; set => _internalSprite.Rotation = value; }
        public Vector2 Scale { get => _internalSprite.Scale; set => _internalSprite.Scale = value; }
        public Color Color { get => _internalSprite.Color; set => _internalSprite.Color = value; }
        public SpriteEffects Effects { get => _internalSprite.Effects; set => _internalSprite.Effects = value; }
        public float LayerDepth { get => _internalSprite.LayerDepth; set => _internalSprite.LayerDepth = value; }
        public Vector2 Origin { get => _internalSprite.Origin; set => _internalSprite.Origin = value; }

        public float Width => _internalSprite.Width; // Calculated from TextureRegion and Scale
        public float Height => _internalSprite.Height; // Calculated from TextureRegion and Scale

        /// <summary>
        /// Creates a new non-moving, non-animated sprite.
        /// </summary>
        /// <param name="region">The texture region to use for this sprite.</param>
        /// <param name="initialPosition">The initial position on the screen.</param>
        public NonMovingNonAnimatedSprite(TextureRegion region, Vector2 initialPosition)
        {
            if (region == null) throw new ArgumentNullException(nameof(region));
            _internalSprite = new MonoGameLibrary.Graphics.Sprite(region); // Creates a new Sprite instance [9]
            Position = initialPosition;
        }

        /// <summary>
        /// This sprite is non-moving and non-animated, so it has no internal update logic.
        /// Its position remains constant or is managed externally.
        /// </summary>
        /// <param name="gameTime">A snapshot of the timing values.</param>
        public void Update(GameTime gameTime)
        {
            // No operation needed for static, non-animated sprites.
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