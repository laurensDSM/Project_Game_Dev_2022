﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledSharp;

namespace Project_Game_Dev_2022.Levels
{
    public class Menu : GameScreen
    {
        private new Game1 Game => (Game1)base.Game;

        Texture2D blokTexture;
        SpriteFont Ubuntu32;
        Rectangle start;
        Rectangle stop;
        Rectangle mouse;
        bool hoverStart = false;
        bool hoverStop = false;

        public static bool Stop = false;
        public static bool Start = false;




        public Menu(Game game) : base(game)
        {
        }

        public override void LoadContent()
        {
            blokTexture = new Texture2D(GraphicsDevice, 1, 1);
            blokTexture.SetData(new[] { Color.White });
            
            start = new Rectangle(330, 200, 400, 80);
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

            #region StartUpdate
            if (start.Intersects(mouse) && state.LeftButton == ButtonState.Pressed)
            {
                Start = true;

            }
            if (start.Intersects(mouse))
            {
                hoverStart = true;

            }
            else
            {
                hoverStart = false;
            }
            #endregion

            #region StopUpdate
            if (stop.Intersects(mouse) && state.LeftButton == ButtonState.Pressed)
            {
                Stop = true;
            }
           
            if (stop.Intersects(mouse) )
            {
                hoverStop = true;
            }
            else
            {
                hoverStop= false;
            }
            #endregion

        }
        public override void Draw(GameTime gameTime)
        {

            Game._spriteBatch.Begin();

            Game._spriteBatch.DrawString(Ubuntu32, "WELKOM BIJ HET SPEL VAN LAURENS", new Vector2(150, 100), Color.White);
            #region StartDraw
            if (hoverStart)
            {
                Game._spriteBatch.Draw(blokTexture, start, Color.LightGreen);

            }
            else
            {
                Game._spriteBatch.Draw(blokTexture, start, Color.Green);

            }

            Game._spriteBatch.DrawString(Ubuntu32, "START     1", new Vector2(450, 220), Color.White);

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

            Game._spriteBatch.DrawString(Ubuntu32, "STOP      0", new Vector2(450, 420), Color.White);

            #endregion

            Game._spriteBatch.End();

        }


    }
}
