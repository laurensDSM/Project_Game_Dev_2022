using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project_Game_Dev_2022.Input;
using System;
using System.Collections.Generic;
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

        private List<Rectangle> collideablesLevel1 = new List<Rectangle>();


        Texture2D blokTexture;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            collideablesLevel1.Add(new Rectangle(0, 400, 10 * 8, 10 * 8));
            collideablesLevel1.Add(new Rectangle(80,400, 10 * 8, 10 * 8));
            collideablesLevel1.Add(new Rectangle(160, 400, 10 * 8, 10 * 8));
            collideablesLevel1.Add(new Rectangle(0, 120, 10 * 8, 10 * 8));
            collideablesLevel1.Add(new Rectangle(160, 120, 10 * 8, 10 * 8));
            collideablesLevel1.Add(new Rectangle(320, 120, 10 * 8, 10 * 8));
            collideablesLevel1.Add(new Rectangle(260, 250, 10 * 5, 10 * 5));
            collideablesLevel1.Add(new Rectangle(400,120, 10 * 8, 10 * 8));
            collideablesLevel1.Add(new Rectangle(240, 400, 10 * 8, 10 * 8));
            collideablesLevel1.Add(new Rectangle(320, 400, 10 * 8, 10 * 8));
            collideablesLevel1.Add(new Rectangle(400, 400, 10 * 8, 10 * 8));
            collideablesLevel1.Add(new Rectangle(560, 400, 10 * 8, 10 * 8));
            collideablesLevel1.Add(new Rectangle(640, 400, 10 * 8, 10 * 8));



        }

        protected override void Initialize()
        {



            base.Initialize();
            MovementManager mm = new MovementManager(collideablesLevel1);
            hero = new Hero(_heroTexture, new KeyboardReader(), mm);

            //movementmanager(hero, colliderLIst)

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            blokTexture = new Texture2D(GraphicsDevice, 1, 1);
            blokTexture.SetData(new[] { Color.White });
            _heroTexture = blokTexture;



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
            GraphicsDevice.Clear(Color.Navy); // Achtergrond kleur van het scherm

            _spriteBatch.Begin();
            

            foreach (var i in collideablesLevel1)
            {
                _spriteBatch.Draw(blokTexture, i, Color.Green);
            }


            hero.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}