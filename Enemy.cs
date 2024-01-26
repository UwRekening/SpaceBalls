using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace SpaceInvaders_Monogame
{
    internal class Enemy : Sprites
    {
        Vector2 velocity;

        public Enemy(string texname, Vector2 pos) : base(texname, pos)
        {
            velocity.Y = (float)0.3;
        }
        public void Update(GraphicsDeviceManager graphics, GameTime gameTime)
        {
            Console.WriteLine($"Enemy Position: {position}");

            if (position.Y > graphics.PreferredBackBufferHeight - texture.Height / 2)
            {
                Respawn(graphics);
            }
            position += velocity * (float)gameTime.TotalGameTime.TotalSeconds;

            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public void Respawn(GraphicsDeviceManager graphics)
        { 
            Random random = new Random();
            position.Y = random.Next(-200, -50);
            position.Y += texture.Height / 2;
            position.X = random.Next(1, graphics.PreferredBackBufferWidth - texture.Width / 2);
            
        }
        public override void Draw()
        {
            Globals.SpriteBatch.Draw(texture, position, null, Color.White, 0 , origin, 1, SpriteEffects.None, 0);
        }
    }
}
