using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project_Game_Dev_2022.enemy_s;
using Project_Game_Dev_2022.Input;
using System.Collections.Generic;

namespace Project_Game_Dev_2022
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Hero hero;
        private Enemy enemy1;
        private Enemy enemy2;
        private Enemy enemy3;
        private Texture2D _heroTexture;
        private Texture2D _enemyTexture;


        private List<Rectangle> collideablesLevel1 = new List<Rectangle>();
        private List<Enemy> enemyDB = new List<Enemy>();


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
            collideablesLevel1.Add(new Rectangle(270, 260, 10 * 4, 10 * 4));
            collideablesLevel1.Add(new Rectangle(400,120, 10 * 8, 10 * 8));
            collideablesLevel1.Add(new Rectangle(240, 400, 10 * 8, 10 * 8));
            collideablesLevel1.Add(new Rectangle(320, 400, 10 * 8, 10 * 8));
            collideablesLevel1.Add(new Rectangle(400, 400, 10 * 8, 10 * 8));
            collideablesLevel1.Add(new Rectangle(560, 400, 10 * 8, 10 * 8));
            collideablesLevel1.Add(new Rectangle(640, 400, 10 * 8, 10 * 8));


            // enemy meegeven aan list

            enemyDB.Add(new EnemyBasic(_enemyTexture));
            // collideEnemy.Add(new EnemyBasic(_enemyTexture));
            enemyDB.Add(new EnemyTeleport(_enemyTexture));
            // collideEnemy.Add(new EnemyTeleport(_enemyTexture));
            enemyDB.Add(new EnemyTrap(_enemyTexture));
           // collideEnemy.Add(new EnemyBasic(_enemyTexture));




        }

        protected override void Initialize()
        {



            base.Initialize();
            MovementManager mm = new MovementManager(collideablesLevel1);
            hero = new Hero(_heroTexture, new KeyboardReader(), mm);
            //enemy1 = new EnemyBasic(_enemyTexture);
            //enemy2 = new EnemyTeleport(_enemyTexture);
            //enemy3 = new EnemyTrap(_enemyTexture);



        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            blokTexture = new Texture2D(GraphicsDevice, 1, 1);
            blokTexture.SetData(new[] { Color.White });
            _heroTexture = blokTexture;
            _enemyTexture = blokTexture;
            



        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
        
            hero.Update();
            //enemy1.Update();
            //enemy2.Update();
            //enemy3.Update();
            foreach (var i in enemyDB)
            {
                i.Update();
            }


            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Navy); // Achtergrond kleur van het scherm

            _spriteBatch.Begin();
            //enemy1.Draw(_spriteBatch);
            //enemy2.Draw(_spriteBatch);
            //enemy3.Draw(_spriteBatch);


            foreach (var i in enemyDB)
            {
                i.Draw(_spriteBatch);
            }

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