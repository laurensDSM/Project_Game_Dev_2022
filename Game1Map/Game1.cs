using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;
using Project_Game_Dev_2022.Levels;

namespace Project_Game_Dev_2022.Game1Map
{
    public class Game1 : Game
    {
        public SpriteBatch SpriteBatch;
        public GraphicsDeviceManager Graphics;
        private readonly ScreenManager _screenManager;
        enum state
        {
            Menu, Level1, Level2, GameOver, GameEnd, Uit
        }
        state theState;


        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Graphics.PreferredBackBufferWidth = 1000;
            Graphics.PreferredBackBufferHeight = 1000;
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
        }
        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            State();
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Escape) || keyboardState.IsKeyDown(Keys.NumPad0) || Menu.Stop == true || GameEnd.Stop == true || GameOver.Stop == true)
            {
                Menu.Stop = false;
                GameOver.Stop = false;
                GameEnd.Stop = false;
                Exit();
            }
            if (keyboardState.IsKeyDown(Keys.NumPad1) || Menu.Start == true || GameEnd.Level1 == true || keyboardState.IsKeyDown(Keys.NumPad5))
            {
                //LEVEL1 START
                Menu.Start = false;
                GameEnd.Level1 = false;
                if (theState != state.Level1)
                {
                    theState = state.Level1;
                }
            }
            else
            {
                theState = state.Uit;
            }


            if (Level1.Level_1_Completed || Level2.Level2Completed)
            {
                Level1.Level_1_Completed = false;
                Level2.Level2Completed = false;
                theState = state.GameEnd;
            }
            if (Level1.Level1GameOver || Level2.Level2GameOver)
            {
                Level1.Level1GameOver = false;
                Level2.Level2GameOver = false;
                theState = state.GameOver;
            }

            if (keyboardState.IsKeyDown(Keys.NumPad2) || GameEnd.Level2 == true)
            {
                GameEnd.Level2 = false;
                theState = state.Level2;
            }
            if (keyboardState.IsKeyDown(Keys.NumPad9) || GameEnd.Menu == true || GameOver.Menu == true)
            {
                GameEnd.Menu = false;
                GameOver.Menu = false;
                theState = state.Menu;
            }
            base.Update(gameTime);

        }

        public void State() //switch 
        {
            switch (theState)
            {
                case state.Menu:
                    MenuScreen();
                    break;
                case state.Level1:
                    Level1Screen();
                    break;
                case state.Level2:
                    Level2Screen();
                    break;
                case state.GameOver:
                    GameOverScreen();
                    break;
                case state.GameEnd:
                    GameEndScreen();
                    break;
                case state.Uit:
                    break;
                default:
                    break;
            }
        }
        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}