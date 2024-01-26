using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Timers;

namespace SpaceInvaders_Monogame
{
    internal class GameManager
    {
        private Enemy enemy;
        private Ship _ship;
        private List<Shooting> _shooting = new List<Shooting>();
        private bool _isShooting;

        Score score = Score.GetInstance();

        public GameManager()
        {
            _ship = new("yct20hubfk061", new(500, 500));
            enemy = new("ball", new(500, 0));
            _shooting.Add(new Shooting("Bullet", new(0,0), _ship));
        }

        public void Update(GraphicsDeviceManager graphics, GameTime gameTime)
        {
            _ship.Update(graphics);
            enemy.Update(graphics, gameTime);
            UpdateBullets(gameTime, graphics);

            var mouseState = Mouse.GetState();


            if (mouseState.LeftButton == ButtonState.Pressed && !_isShooting)
            {
                _shooting.Add(new Shooting("Bullet", new(0, 0), _ship));
                _isShooting = true;

                foreach(var bullet in _shooting)
                {
                    bullet.isVisible = true;
                }
            }
            else if (mouseState.LeftButton == ButtonState.Released && _isShooting)
            {
                _isShooting = false;
            }
            foreach(var bullet in _shooting)
            {
                if (bullet.rectangle.Intersects(enemy.rectangle))
                {
                    Console.WriteLine("Collision");
                    score.score += 1;
                    bullet.isVisible = false;
                    enemy.Respawn(graphics);
                }
            }
        }

        public void Draw()
        {
            _ship.Draw();
            enemy.Draw();

            DrawBullets();
        }
        void DrawBullets()
        {
            for (int i = 0; i < _shooting.Count; i++)
            {
                if (_shooting[i].isVisible)
                {
                    _shooting[i].Draw();
                }
            }
        }
        void UpdateBullets(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            for (int i = 0; i < _shooting.Count; ++i)
            {
                if (_shooting[i].isVisible)
                {
                    _shooting[i].Update(gameTime, graphics);
                } else
                {
                    _shooting.RemoveAt(i);
                    Console.WriteLine("Destroyed");
                }
            }
        }
    }
}
