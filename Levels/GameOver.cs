using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens;
using Mouse = Microsoft.Xna.Framework.Input.Mouse;

namespace Project_Game_Dev_2022.Levels
{
    public class GameOver : GameScreen
    {


        private new Game1 Game => (Game1)base.Game;

        Texture2D blokTexture;
        SpriteFont Ubuntu32;
        Rectangle menu;
        Rectangle stop;
        Rectangle mouse;
        bool hoverMenu = false;
        bool hoverStop = false;

        public static bool Stop = false;
        public static bool Menu = false;

        public GameOver(Game game) : base(game)
        {
        }

        public override void LoadContent()
        {
            blokTexture = new Texture2D(GraphicsDevice, 1, 1);
            blokTexture.SetData(new[] { Color.White });

            menu = new Rectangle(330, 200, 400, 80);
            stop = new Rectangle(330, 400, 400, 80);
            mouse = new Rectangle(0, 0, 10, 10);

            //Text
            Ubuntu32 = Content.Load<SpriteFont>("font/Ubuntu32");


            base.LoadContent();
        }


        public override void Update(GameTime gameTime)
        {
            MouseState state = Mouse.GetState();
            Vector2 mouseVector = new Vector2(state.X, state.Y);
            mouse = new Rectangle((int)mouseVector.X, (int)mouseVector.Y, 10, 10);

            #region MenuUpdate
            if (menu.Intersects(mouse) && state.LeftButton == ButtonState.Pressed)
            {
                Menu = true;

            }
            if (menu.Intersects(mouse))
            {
                hoverMenu = true;

            }
            else
            {
                hoverMenu = false;
            }
            #endregion

            #region StopUpdate
            if (stop.Intersects(mouse) && state.LeftButton == ButtonState.Pressed)
            {
                Stop = true;
            }

            if (stop.Intersects(mouse))
            {
                hoverStop = true;
            }
            else
            {
                hoverStop = false;
            }
            #endregion


        }

        public override void Draw(GameTime gameTime)
        {

            Game._spriteBatch.Begin();

            Game._spriteBatch.DrawString(Ubuntu32, "Game Over !!!", new Vector2(400, 100), Color.White);
            #region MenuDraw
            if (hoverMenu)
            {
                Game._spriteBatch.Draw(blokTexture, menu, Color.LightGreen);

            }
            else
            {
                Game._spriteBatch.Draw(blokTexture, menu, Color.Green);

            }

            Game._spriteBatch.DrawString(Ubuntu32, "MENU     [9]", new Vector2(450, 220), Color.Black);

            #endregion

            #region StopDraw
            if (hoverStop)
            {
                Game._spriteBatch.Draw(blokTexture, stop, Color.LightSalmon);

            }
            else
            {
                Game._spriteBatch.Draw(blokTexture, stop, Color.Red);

            }

            Game._spriteBatch.DrawString(Ubuntu32, "STOP      [0]", new Vector2(450, 420), Color.Black);

            #endregion

            Game._spriteBatch.End();
        }
    }
}
