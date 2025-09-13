using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Graphics; // Utilizes graphics classes developed in the library
using MarioGame.Interfaces;
using System; // For ArgumentNullException

namespace MarioGame.Sprites
{
    /// <summary>
    /// A concrete implementation of ISprite for a moving, animated sprite.
    /// It updates both its position based on velocity and its animation frames.
    /// This reflects behavior seen in the `_slime` and `_bat` objects in the game's Update methods. [14, 15]
    /// </summary>
    public class MovingAnimatedSprite : ISprite
    {
        // The internal MonoGameLibrary.Graphics.AnimatedSprite handles animation and rendering properties
        protected AnimatedSprite _internalAnimatedSprite;

        // ISprite properties, delegated to the internal animated sprite or managed directly
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; } // For internal movement logic

        public float Rotation { get => _internalAnimatedSprite.Rotation; set => _internalAnimatedSprite.Rotation = value; }
        public Vector2 Scale { get => _internalAnimatedSprite.Scale; set => _internalAnimatedSprite.Scale = value; }
        public Color Color { get => _internalAnimatedSprite.Color; set => _internalAnimatedSprite.Color = value; }
        public SpriteEffects Effects { get => _internalAnimatedSprite.Effects; set => _internalAnimatedSprite.Effects = value; }
        public float LayerDepth { get => _internalAnimatedSprite.LayerDepth; set => _internalAnimatedSprite.LayerDepth = value; }
        public Vector2 Origin { get => _internalAnimatedSprite.Origin; set => _internalAnimatedSprite.Origin = value; }

        public float Width => _internalAnimatedSprite.Width; // Inherited from Sprite
        public float Height => _internalAnimatedSprite.Height; // Inherited from Sprite

        /// <summary>
        /// Creates a new moving, animated sprite.
        /// </summary>
        /// <param name="animation">The animation sequence for this sprite.</param>
        /// <param name="initialPosition">The initial position on the screen.</param>
        /// <param name="initialVelocity">The initial velocity for movement (pixels per second).</param>
        public MovingAnimatedSprite(Animation animation, Vector2 initialPosition, Vector2 initialVelocity)
        {
            if (animation == null) throw new ArgumentNullException(nameof(animation));
            _internalAnimatedSprite = new AnimatedSprite(animation); // Creates a new AnimatedSprite instance [11]
            Position = initialPosition;
            Velocity = initialVelocity;
        }

        /// <summary>
        /// Updates both the animation frames and the sprite's position based on its velocity.
        /// </summary>
        /// <param name="gameTime">A snapshot of the timing values.</param>
        public void Update(GameTime gameTime)
        {
            _internalAnimatedSprite.Update(gameTime); // Updates animation frames [12]
            Position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds; // Updates position based on delta time [13]
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