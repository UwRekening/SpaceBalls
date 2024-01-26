using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace SpaceInvaders_Monogame
{
    internal class Shooting : Sprites
    {
        private Vector2 velocity;
        private float rotationShooting;
        Ship ship;
        public bool isVisible = true;

        public Shooting(string texname, Vector2 pos, Ship Pship) : base(texname, pos)
        {
            ship = Pship;
            position = ship.position;
            rotationShooting = ship._rotation;

            velocity = new Vector2((float)Math.Sin(rotationShooting), -(float)Math.Cos(rotationShooting));
        }
        public void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            if (isVisible)
            {
                position += velocity * 50f;
            }
            if (position.Y > graphics.PreferredBackBufferHeight - texture.Height / 2)
            {
                isVisible = false;
            }

            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }
        public override void Draw()
        {
            Globals.SpriteBatch.Draw(texture, position, null, Color.White, rotationShooting, origin, 1, SpriteEffects.None, 0);
        }
    }
}
