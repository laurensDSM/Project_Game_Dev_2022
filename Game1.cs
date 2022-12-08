using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;

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
        Rectangle ToekomstigePositie;
        Vector2 positie = new Vector2(5, 5);
        Vector2 positie2;
        Vector2 toekomstP;
        private int counter;
        private int counter1;

        bool isFalling = true;
        private bool canJump;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            positie2 = new Vector2(30,120);
            snelheid = new Vector2(5, 5);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            hero = new Rectangle((int)positie.X, (int)positie.Y, 10 * 5, 10 * 5);

            box = new Rectangle((int)positie2.X, (int)positie2.Y, 10 * 8, 10 * 8);

            ToekomstigePositie = new Rectangle((int)positie.X, (int)positie.Y, 10 * 5, 10 * 5);

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
/*
                Debug.WriteLine("KeyDown");

                if (counter1 == 1)
                {
                    direction.Y -= 1;
                    if (canJump)
                    {
                        Debug.WriteLine("canJump is waar");

                        direction.Y -= 1;
                        counter1 = 0;
                        Debug.WriteLine($"counter1" + "=" + counter1);

                    }

                }
                else
                {
                    counter1++;
                    Debug.WriteLine("counter ++");

                }
*/



            }
            if (state.IsKeyDown(Keys.Down))
            {
                direction.Y += 1;
            }
            if (direction.Y == -1)
            {

                
                if (canJump)
                {
                    isFalling = false;
                }
                else
                {
                    isFalling = true;
                }
               
            }
            if (isFalling)
            {
                direction.Y = 1;
            }
            direction *= snelheid;
            //positie += direction;
            toekomstP = positie + direction;
            //toekomstP = (positie + snelheid + direction);
            //




            if (toekomstP.X > 800 || toekomstP.X < 0 || toekomstP.Y > 480 || toekomstP.Y < 0)
            {
                counter = 100;
                canJump = true;
                isFalling = false; 
            }
            if (toekomstP.X < 800 && toekomstP.X > 0 && toekomstP.Y < 480 && toekomstP.Y > 0)
            {
                counter = 0;

            }
            ToekomstigePositie = new Rectangle((int)toekomstP.X, (int)toekomstP.Y, 10 * 5, 10 * 5);

            if (ToekomstigePositie.Intersects(box))
            {
                counter = 200;
                isFalling = false;
                canJump = true;
            }
            else
            {
                positie = toekomstP;
                isFalling = true;
            }



            //counter++;
            hero = new Rectangle((int)positie.X, (int)positie.Y, 10 * 5, 10 * 5);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Navy);
            _spriteBatch.Begin();
            _spriteBatch.Draw(blokTexture, hero, Color.Green);
            _spriteBatch.Draw(blokTexture, box, Color.Red);

            if (counter == 100)
            {
                _spriteBatch.Draw(blokTexture, box, Color.Black);
               

            }
            if (counter == 200)
            {
                _spriteBatch.Draw(blokTexture, box, Color.Gold);


            }


            // TODO: Add your drawing code here
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}