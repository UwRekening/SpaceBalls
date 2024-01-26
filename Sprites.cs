using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvaders_Monogame
{
    internal class Sprites
    {
        protected readonly Texture2D texture;
        protected readonly Vector2 origin;
        public Rectangle rectangle;
        public Vector2 position;
        protected int speed;

        public Sprites(string texname, Vector2 pos)
        {
            texture = Globals.Content.Load<Texture2D>(texname);
            position = pos;
            speed = 800;
            origin = new(texture.Width / 2, texture.Height / 2);
        }
        public virtual void Draw()
        {
            Globals.SpriteBatch.Draw(texture, position, null, Color.White, 0, origin, 1, SpriteEffects.None, 0);
        }
    }
}
