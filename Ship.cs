using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace SpaceInvaders_Monogame
{
    internal class Ship : Sprites
    {
        public float _rotation;
        private readonly float _rotationSpeed;

        InputManager inputManager = new InputManager();

        public Ship(string texname, Vector2 pos) : base(texname, pos)
        {
            _rotation = 0;
            _rotationSpeed = 8f;
        }
        public void Update(GraphicsDeviceManager graphics)
        {
            inputManager.Update();
            Console.WriteLine($"Ship Position: {position}");

            _rotation += inputManager.DirectionArrows.X * _rotationSpeed * Globals.TotalSeconds;
            Vector2 direction = new((float)Math.Sin(_rotation), -(float)Math.Cos(_rotation));
            position += inputManager.DirectionArrows.Y * direction * speed * Globals.TotalSeconds;

            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public override void Draw()
        {
            Globals.SpriteBatch.Draw(texture, position, null, Color.White, _rotation, origin, 1, SpriteEffects.None, 0);
        }
    }
}