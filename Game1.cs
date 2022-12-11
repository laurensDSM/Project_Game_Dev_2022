using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        Hero hero;



            
        Texture2D blokTexture;
        Rectangle box;
        Vector2 positie2;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            positie2 = new Vector2(30,120);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            box = new Rectangle((int)positie2.X, (int)positie2.Y, 10 * 8, 10 * 8);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            blokTexture = new Texture2D(GraphicsDevice, 1, 1);
            blokTexture.SetData(new[] { Color.White });

       
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            InitializeGameObject();


            // TODO: use this.Content to load your game content here
        }

        private void InitializeGameObject()
        {
            hero = new Hero();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            hero.Update();


           base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Navy);
            _spriteBatch.Begin();
            _spriteBatch.Draw(blokTexture, box, Color.Red);
            hero.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}