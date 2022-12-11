using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project_Game_Dev_2022.Input;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;

namespace Project_Game_Dev_2022
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Hero hero;
        private Texture2D _heroTexture;



        Texture2D blokTexture;
        Rectangle box;
        Rectangle box1;
        Rectangle box2;
        Rectangle box3;
        Rectangle box4;
        Rectangle box5;
        Rectangle box6;
        Rectangle box7;
        Rectangle box8;
        Rectangle box9;

        Vector2 positie1;
        Vector2 positie0;
        Vector2 positie2;
        Vector2 positie3;
        Vector2 positie4;
        Vector2 positie5;
        Vector2 positie6;
        Vector2 positie7;
        Vector2 positie8;
        Vector2 positie9;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            positie0 = new Vector2(0, 400);
            positie1 = new Vector2(80,400);
            positie2 = new Vector2(160, 400);
            positie3 = new Vector2(0, 120);
            positie4 = new Vector2(160, 120);
            positie5 = new Vector2(320, 120);
            positie6 = new Vector2(400, 120);
            positie7 = new Vector2(240, 400);
            positie8 = new Vector2(320, 400);
            positie9 = new Vector2(400, 400);

        }

        protected override void Initialize()
        {
            box = new Rectangle((int)positie0.X, (int)positie0.Y, 10 * 8, 10 * 8);
            box1 = new Rectangle((int)positie1.X, (int)positie1.Y, 10 * 8, 10 * 8);
            box2 = new Rectangle((int)positie2.X, (int)positie2.Y, 10 * 8, 10 * 8);
            box3 = new Rectangle((int)positie3.X, (int)positie3.Y, 10 * 8, 10 * 8);
            box4 = new Rectangle((int)positie4.X, (int)positie4.Y, 10 * 8, 10 * 8);
            box5 = new Rectangle((int)positie5.X, (int)positie5.Y, 10 * 8, 10 * 8);
            box6 = new Rectangle((int)positie6.X, (int)positie6.Y, 10 * 8, 10 * 8);
            box7 = new Rectangle((int)positie7.X, (int)positie7.Y, 10 * 8, 10 * 8);
            box8 = new Rectangle((int)positie8.X, (int)positie8.Y, 10 * 8, 10 * 8);
            box9 = new Rectangle((int)positie8.X, (int)positie9.Y, 10 * 8, 10 * 8);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            blokTexture = new Texture2D(GraphicsDevice, 1, 1);
            blokTexture.SetData(new[] { Color.White });



        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

         base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Navy); // Achtergrond kleur van het scherm

            _spriteBatch.Begin();
            _spriteBatch.Draw(blokTexture, box, Color.Red);
            _spriteBatch.Draw(blokTexture, box1, Color.Red);
            _spriteBatch.Draw(blokTexture, box2, Color.Red);
            _spriteBatch.Draw(blokTexture, box3, Color.Red);
            _spriteBatch.Draw(blokTexture, box4, Color.Red);
            _spriteBatch.Draw(blokTexture, box5, Color.Red);
            _spriteBatch.Draw(blokTexture, box6, Color.Red);
            _spriteBatch.Draw(blokTexture, box7, Color.Red);
            _spriteBatch.Draw(blokTexture, box8, Color.Red);
            _spriteBatch.Draw(blokTexture, box9, Color.Red);



            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}