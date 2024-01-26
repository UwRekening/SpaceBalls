using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Timers;

namespace SpaceInvaders_Monogame
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameManager _gameManager;

        private Texture2D mainScreen;
        private Texture2D deadScreen;

        private SpriteFont font;

        Score score = Score.GetInstance();

        Timer timer;
        int secondsLeft;

        bool gameStarted = false;
        bool playerDead = false;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Globals.Content = Content;
            _graphics.PreferredBackBufferWidth = _graphics.GraphicsDevice.DisplayMode.Width;
            _graphics.PreferredBackBufferHeight = _graphics.GraphicsDevice.DisplayMode.Height;

            //_graphics.IsFullScreen = true;

            _graphics.ApplyChanges();


            _gameManager = new();

            base.Initialize();

            addTimer();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.SpriteBatch = _spriteBatch;
            font = Content.Load<SpriteFont>("Fonts/File");

            mainScreen = Content.Load<Texture2D>("mainScreen");
            deadScreen = Content.Load<Texture2D>("deadScreen");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Globals.Update(gameTime);
            if (!gameStarted && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                gameStarted = true;
            }
            if (playerDead && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                Exit();
            } else
            {
                _gameManager.Update(_graphics, gameTime);
            }



            base.Update(gameTime);
        }

        void addTimer()
        {
            int initialDelay = 1000;

            timer = new Timer(initialDelay);
            timer.Elapsed += TimerElapsed;
            timer.Start();

            secondsLeft = 61;
        }
        void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (secondsLeft > 0)
            {
                secondsLeft--;
            }
            else
            {
                timer.Stop();
                playerDead = true;
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();
            if (!gameStarted)
            {
                _spriteBatch.DrawString(font, "Press Any Key To Start!", new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), Color.White);
                _spriteBatch.DrawString(font, "Shoot at the ball and get the highest score!", new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2 - 100), Color.White);
            }
            else if (playerDead)    
            {
                _spriteBatch.DrawString(font, $"Your Score: {score.score.ToString()}", new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), Color.White);
                _spriteBatch.DrawString(font, "Press Any Key To Exit The Game", new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2 - 100), Color.White);
            }
            else
            {
                _gameManager.Draw();

                _spriteBatch.DrawString(font, $"Score: {score.score.ToString()}", new Vector2(50, 50), Color.White);

                _spriteBatch.DrawString(font, $"Timer: {secondsLeft.ToString()}", new Vector2(50, 120), Color.White);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}