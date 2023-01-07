using Microsoft.VisualBasic.Logging;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;
using Project_Game_Dev_2022.enemy_s;
using Project_Game_Dev_2022.Input;
using Project_Game_Dev_2022.money;
using Project_Game_Dev_2022.powerups;
using System.Collections.Generic;
using TiledSharp;

namespace Project_Game_Dev_2022.Levels
{
    public class Level1 : GameScreen
    {
        // bron is https://www.monogameextended.net/docs/features/screen-management/screen-management/
        private new Game1 Game => (Game1)base.Game;

        private Texture2D _heroTexture;
        private Texture2D _trapTexture;
        private Texture2D _moneyTexture;
        private Texture2D _teleportTexture;
        private Texture2D _enemyBasicTexture;
        private Texture2D _powerupTexture;



        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Hero hero;
        private Texture2D _enemyTexture;

        #region TileMaps
        private TmxMap map;
        private TileMapManager tilemapManager;
        private Texture2D tileset;
        private List<Rectangle> colliders;
        #endregion

        #region Lists
        private List<EnemyTeleport> enemysTeleport = new List<EnemyTeleport>();
        private List<EnemyTrap> enemyTraps = new List<EnemyTrap>();
        private List<EnemyBasic> enemyBasic = new List<EnemyBasic>();
        private List<Money> money = new List<Money>();
        private List<Immunity> immunities = new List<Immunity>();
        #endregion


        Texture2D blokTexture;


        public Level1(Game game) : base(game) { }

        public override void Initialize()
        {
            base.Initialize();
        }



        public override void LoadContent()
        {
            blokTexture = new Texture2D(GraphicsDevice, 1, 1);
            blokTexture.SetData(new[] { Color.White });
            _enemyTexture = blokTexture;
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var mm = new MovementManager(colliders);
            var col = new CollisionManager(enemysTeleport, enemyTraps, enemyBasic, money, immunities);

            hero = new Hero(_heroTexture, new KeyboardReader(), mm, col);


            //TRAP valstrik
            Vector2 EnemyLocatie1 = new Vector2(30, 350);
            Vector2 EnemyLocatie2 = new Vector2(220, 350);
            Vector2 EnemyLocatie3 = new Vector2(400, 350);

            enemyTraps.Add(new EnemyTrap(_trapTexture, EnemyLocatie1));
            enemyTraps.Add(new EnemyTrap(_trapTexture, EnemyLocatie2));
            enemyTraps.Add(new EnemyTrap(_trapTexture, EnemyLocatie3));

            //Teleport
            enemysTeleport.Add(new EnemyTeleport(_teleportTexture));

            //Basic
            Vector2 EnemyLocatieBasic1 = new Vector2(640, 350);
            enemyBasic.Add(new EnemyBasic(_enemyBasicTexture, EnemyLocatieBasic1));

            //money
            Vector2 MoneyLocatie1 = new Vector2(110, 350);
            Vector2 MoneyLocatie2 = new Vector2(170, 350);

            money.Add(new Money(_moneyTexture, MoneyLocatie1));
            money.Add(new Money(_moneyTexture, MoneyLocatie2));

            // Immunity
            Vector2 ImmunityLocatie1 = new Vector2(320, 70);
            Vector2 ImmunityLocatie2 = new Vector2(300, 350);
            immunities.Add(new Immunity(_powerupTexture, ImmunityLocatie1));
            immunities.Add(new Immunity(_powerupTexture, ImmunityLocatie2));


            //tilemap
            map = new TmxMap("Content/level1.tmx");
            tileset = Content.Load<Texture2D>(map.Tilesets[0].Name.ToString());
            int tileWidth = map.Tilesets[0].TileWidth;
            int tileHeight = map.Tilesets[0].TileHeight;
            int tileSetTileWidth = tileset.Width / tileWidth;
            tilemapManager = new TileMapManager(map, tileset, tileSetTileWidth, tileWidth, tileHeight);

            colliders = new List<Rectangle>();
            foreach (var item in map.ObjectGroups["CollisionBlocks"].Objects)
            {
                if (item.Name == "")
                {
                    colliders.Add(new Rectangle((int)item.X, (int)item.Y, (int)item.Width, (int)item.Height));
                }
            }



            _heroTexture = Content.Load<Texture2D>("test");
            _trapTexture = Content.Load<Texture2D>("trap");
            _moneyTexture = Content.Load<Texture2D>("coin");
            _teleportTexture = Content.Load<Texture2D>("ghost");
            _enemyBasicTexture = Content.Load<Texture2D>("EnemyBasic");
            _powerupTexture = Content.Load<Texture2D>("powerups");





            base.LoadContent();

        }

        public override void Update(GameTime gameTime)
        {
            hero.Update(gameTime);

            foreach (var i in enemysTeleport)
            {
                i.Update(gameTime);
            }

            foreach (var i in enemyTraps)
            {
                i.Update(gameTime);
            }
            foreach (var item in enemyBasic)
            {
                item.Update(gameTime);
            }

            foreach (var item in money)
            {
                item.Update(gameTime);
            }
            foreach (var item in immunities)
            {
                item.Update(gameTime);

            }

        }
        public override void Draw(GameTime gameTime)
        {
            tilemapManager.Draw(_spriteBatch);


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





            hero.Draw(_spriteBatch);

        }


    }
}
