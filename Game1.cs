﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project_Game_Dev_2022
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Vector2 snelheid; 
            
        Texture2D blokTexture;
        Rectangle hero;
        Rectangle box;
        Vector2 positie = new Vector2(0, 0);
        Vector2 positie2;
        private int counter;
        



        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            positie2 = new Vector2(120,100);
            snelheid = new Vector2(5, 5);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            hero = new Rectangle((int)positie.X, (int)positie.Y, 10 * 5, 10 * 5);

            box = new Rectangle((int)positie2.X, (int)positie2.Y, 10 * 8, 10 * 8);

        }

        protected override void LoadContent()
        {
            blokTexture = new Texture2D(GraphicsDevice, 1, 1);
            blokTexture.SetData(new[] { Color.White });

          
            _spriteBatch = new SpriteBatch(GraphicsDevice);


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            KeyboardState state = Keyboard.GetState();
            var direction = Vector2.Zero;
            if (state.IsKeyDown(Keys.Left))
            {
                direction.X -= 1;
            }
            if (state.IsKeyDown(Keys.Right))
            {
                direction.X += 1;
            }
            if (state.IsKeyDown(Keys.Up))
            {
                direction.Y -= 1;
            }
            if (state.IsKeyDown(Keys.Down))
            {
                direction.Y += 1;
            }
            direction *= snelheid;
            positie += direction;



            counter++;
            hero = new Rectangle((int)positie.X, (int)positie.Y, 10 * 5, 10 * 5);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Navy);
            _spriteBatch.Begin();
            _spriteBatch.Draw(blokTexture, hero, Color.Green);
            if (counter >= 50)
            {
                _spriteBatch.Draw(blokTexture, box, Color.Red);

            }

            // TODO: Add your drawing code here
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}