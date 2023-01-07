using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;
using Project_Game_Dev_2022.enemy_s;
using Project_Game_Dev_2022.Input;
using Project_Game_Dev_2022.Levels;
using Project_Game_Dev_2022.money;
using Project_Game_Dev_2022.powerups;
using System.Collections.Generic;
using System.Diagnostics;
using TiledSharp;

namespace Project_Game_Dev_2022
{
    public class Game1 : Game
    {
        public SpriteBatch _spriteBatch;
        public GraphicsDeviceManager _graphics;
        private readonly ScreenManager _screenManager;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _graphics.PreferredBackBufferWidth = 1000;
            _graphics.PreferredBackBufferHeight = 1000;
           // _graphics.IsFullScreen = false;

            IsMouseVisible = true;

            _screenManager = new ScreenManager();
            Components.Add(_screenManager);

        }
        private void MenuScreen()
        {
            _screenManager.LoadScreen(new Menu(this), new FadeTransition(GraphicsDevice, Color.Black));
        }
        private void Level1Screen()
        {
            _screenManager.LoadScreen(new Level1(this), new FadeTransition(GraphicsDevice, Color.Black));
        }
        private void Level2Screen()
        {
            _screenManager.LoadScreen(new Level2(this), new FadeTransition(GraphicsDevice, Color.Black));
        }
        private void GameOverScreen()
        {
            _screenManager.LoadScreen(new GameOver(this), new FadeTransition(GraphicsDevice, Color.Black));

        }
        private void GameEndScreen()
        {
            _screenManager.LoadScreen(new GameEnd(this), new FadeTransition(GraphicsDevice, Color.Black));

        }
        protected override void Initialize()
        {
            base.Initialize();
            // Menu screen is het eerst scherm dat ingeladen zal worden bij de opstart van de game
            MenuScreen();


        }


        protected override void LoadContent()
        {

            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Escape) || keyboardState.IsKeyDown(Keys.NumPad0) || Menu.Stop == true || GameEnd.Stop == true || GameOver.Stop==true)
            {
                Menu.Stop = false;
                GameOver.Stop = false;
                GameEnd.Stop = false;
                Exit();

            }
            if (keyboardState.IsKeyDown(Keys.NumPad1) || Menu.Start == true || GameEnd.Level1==true || keyboardState.IsKeyDown(Keys.NumPad5))
            {
                //LEVEL1 START
                Menu.Start = false;
                GameEnd.Level1 = false;
                Debug.WriteLine("Start Level1");
                Level1Screen();


            }
            else if (Level1.Level1Completed || Level2.Level2Completed)
            {
                Level1.Level1Completed = false;
                Level2.Level2Completed = false;
                GameEndScreen();

            }
            else if (Level1.Level1GameOver || Level2.Level2GameOver)
            {
                Level1.Level1GameOver = false;
                Level2.Level2GameOver = false;

                GameOverScreen();

            }

            else if (keyboardState.IsKeyDown(Keys.NumPad2) || GameEnd.Level2 == true)
            {
                GameEnd.Level2 = false;
                Level2Screen();

            }
            else if(keyboardState.IsKeyDown(Keys.NumPad9) || GameEnd.Menu== true || GameOver.Menu==true)
            {
                GameEnd.Menu = false;
                GameOver.Menu = false;
                MenuScreen();

            }




            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}