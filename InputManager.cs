using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace SpaceInvaders_Monogame
{
    internal class InputManager
    {

        Vector2 _direction;
        public Vector2 Direction => _direction;
        public Vector2 _directionArrows;
        public Vector2 DirectionArrows => _directionArrows;


        //public InputManager() 
        //{
        //    Console.WriteLine("Loading InputManager");
        //}

        public void Update()
        {
            var keyboardState = Keyboard.GetState();
            _directionArrows = Vector2.Zero;
            if (keyboardState.IsKeyDown(Keys.W)) _directionArrows.Y++;
            if (keyboardState.IsKeyDown(Keys.S)) _directionArrows.Y--;
            if (keyboardState.IsKeyDown(Keys.A)) _directionArrows.X--;
            if (keyboardState.IsKeyDown(Keys.D)) _directionArrows.X++;
        }
    }
}
