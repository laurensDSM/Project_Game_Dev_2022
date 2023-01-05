using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project_Game_Dev_2022.enemy_s;
using Project_Game_Dev_2022.Input;
using Project_Game_Dev_2022.money;
using Project_Game_Dev_2022.powerups;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;

namespace Project_Game_Dev_2022
{
    public class Game1 : Game
    {
        private Texture2D _texture;


        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Hero hero;
        private Texture2D _heroTexture;
        private Texture2D _enemyTexture;


        private List<Rectangle> collideablesLevel1 = new List<Rectangle>();


        private List<EnemyTeleport> enemysTeleport = new List<EnemyTeleport>();
        private List<EnemyTrap> enemyTraps = new List<EnemyTrap>();
        private List<EnemyBasic> enemyBasic = new List<EnemyBasic>();
        private List<Money> money = new List<Money>();
        private List<Immunity> immunities = new List<Immunity>();



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





        }

        protected override void Initialize()
        {



            base.Initialize();
            

            //Teleport
            enemysTeleport.Add(new EnemyTeleport(_enemyTexture));



            //TRAP valstrik
            Vector2 EnemyLocatie1 = new Vector2(50, 350);
             Vector2 EnemyLocatie2 = new Vector2(200, 350);
             Vector2 EnemyLocatie3 = new Vector2(400, 350);

            enemyTraps.Add(new EnemyTrap(_enemyTexture, EnemyLocatie1));
            enemyTraps.Add(new EnemyTrap(_enemyTexture, EnemyLocatie2));
            enemyTraps.Add(new EnemyTrap(_enemyTexture, EnemyLocatie3));

            //Basic
            Vector2 EnemyLocatieBasic1 = new Vector2(640, 350);
            enemyBasic.Add(new EnemyBasic(_enemyTexture, EnemyLocatieBasic1));


            //money
            Vector2 MoneyLocatie1 = new Vector2(120, 370);
            Vector2 MoneyLocatie2 = new Vector2(170, 370);
            Vector2 MoneyLocatie3 = new Vector2(170, 370);


            money.Add(new Money(_enemyTexture, MoneyLocatie1));
            money.Add(new Money(_enemyTexture, MoneyLocatie2));


            // Immunity
            Vector2 ImmunityLocatie2 = new Vector2(300, 370);

            immunities.Add(new Immunity(_enemyTexture, ImmunityLocatie2));

            InitializeGameObject();
        }

        private void InitializeGameObject()
        {
            MovementManager mm = new MovementManager(collideablesLevel1);
            CollisionManager col = new CollisionManager(enemysTeleport, enemyTraps, enemyBasic, money, immunities);
            hero = new Hero(_texture, new KeyboardReader(), mm, col);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            blokTexture = new Texture2D(GraphicsDevice, 1, 1);
            blokTexture.SetData(new[] { Color.White });
            _heroTexture = blokTexture;
            _enemyTexture = blokTexture;

            _texture = Content.Load<Texture2D>("test");
                


        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
        
            hero.Update();

            foreach (var i in enemysTeleport)
            {
                i.Update();
            }

            foreach (var i in enemyTraps)
            {
                i.Update();
            }
            foreach (var item in enemyBasic)
            {
                item.Update();
            }

            foreach (var item in money)
            {
                item.Update();
            }
            foreach (var item in immunities)
            {
                item.Update();

            }
            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Navy); // Achtergrond kleur van het scherm

            _spriteBatch.Begin();



            foreach (var i in enemysTeleport)
            {
                i.Draw(_spriteBatch);
            }

            foreach (var i in enemyTraps)
            {
                i.Draw(_spriteBatch);
            }
            foreach (var i in enemyBasic)
            {
                i.Draw(_spriteBatch);
            }
            foreach (var item in money)
            {
                item.Draw(_spriteBatch);
            }
            foreach (var item in immunities)
            {
                item.Draw(_spriteBatch);
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