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
            if (keyboardState.IsKeyDown(Keys.Escape) || keyboardState.IsKeyDown(Keys.NumPad0) || Menu.Stop == true)
            {
                Menu.Stop = false;
                Exit();

            }
            if (keyboardState.IsKeyDown(Keys.NumPad1) || Menu.Start == true)
            {
                //LEVEL1 START
                Menu.Start = false;
                Debug.WriteLine("Start Level1");
                Level1Screen();


            }
            else if (Level1.Level1Completed)
            {
                //HERO LEVEL = 0 == GAMEOVER
                Level1.Level1Completed = false;
                GameEndScreen();

            }
            else if (Level1.Level1GameOver)
            {
                //HERO WINT DUS GAME END
                GameOverScreen();

            }

            else if (keyboardState.IsKeyDown(Keys.NumPad2))
            {
                //LEVEL2 START
                Level2Screen();

            }




            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}