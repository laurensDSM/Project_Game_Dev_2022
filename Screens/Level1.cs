using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Project_Game_Dev_2022.enemies;
using Project_Game_Dev_2022.Input;
using Project_Game_Dev_2022.LivesHeart;
using Project_Game_Dev_2022.Managers;
using Project_Game_Dev_2022.money;
using Project_Game_Dev_2022.powerups;
using Project_Game_Dev_2022.HeroMap;
using Project_Game_Dev_2022.Game1Map;
using System.Collections.Generic;
using TiledSharp;

namespace Project_Game_Dev_2022.Levels
{
    public class Level1 : LevelBase
    {
        private new Game1 Game => (Game1)base.Game;
        public override int Enemies { get; set; }

        SpriteFont Ubuntu32;
        private Texture2D _heroTexture;
        private Texture2D _trapTexture;
        private Texture2D _moneyTexture;
        private Texture2D _teleportTexture;
        private Texture2D _enemyBasicTexture;
        private Texture2D _powerupTexture;
        private Texture2D _livesTexture;
        SoundEffect _soundMoney;
        SoundEffect _soundTrap;
        SoundEffect _soundImmunity;
        SoundEffect _soundEnemie;
        private Hero hero;
        public static bool Level_1_Completed = false;
        public static bool Level1GameOver = false;
        private Lives lives1;
        private Lives lives2;
        private Lives lives3;
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
        public Level1(Game game) : base(game) { }

        public override void Initialize()
        {
            Enemies = 2;
            _heroTexture = Content.Load<Texture2D>("hero");
            _trapTexture = Content.Load<Texture2D>("trap");
            _moneyTexture = Content.Load<Texture2D>("coin");
            _teleportTexture = Content.Load<Texture2D>("ghost");
            _enemyBasicTexture = Content.Load<Texture2D>("EnemyBasic");
            _powerupTexture = Content.Load<Texture2D>("powerups");
            _livesTexture = Content.Load<Texture2D>("heart");
            _soundMoney = Content.Load<SoundEffect>("moneySound");
            _soundTrap = Content.Load<SoundEffect>("trapSound");
            _soundImmunity = Content.Load<SoundEffect>("immunitySound");
            _soundEnemie = Content.Load<SoundEffect>("enemieSound");

            //TRAP valstrik
            Vector2 EnemyLocatie1 = new Vector2(60, 430);
            Vector2 EnemyLocatie2 = new Vector2(220, 300);
            Vector2 EnemyLocatie3 = new Vector2(230, 685);
            enemyTraps.Add(new EnemyTrap(_trapTexture, EnemyLocatie1, _soundTrap));
            enemyTraps.Add(new EnemyTrap(_trapTexture, EnemyLocatie2, _soundTrap));
            enemyTraps.Add(new EnemyTrap(_trapTexture, EnemyLocatie3, _soundTrap));

            //Teleport
            enemysTeleport.Add(new EnemyTeleport(_teleportTexture, _soundEnemie));

            //Basic
            Vector2 EnemyLocatieBasic1 = new Vector2(700, 425);
            enemyBasic.Add(new EnemyBasic(_enemyBasicTexture, EnemyLocatieBasic1, _soundEnemie));

            //money
            Vector2 MoneyLocatie1 = new Vector2(170, 180);
            Vector2 MoneyLocatie2 = new Vector2(200, 800);
            Vector2 MoneyLocatie3 = new Vector2(500, 920);
            Vector2 MoneyLocatie4 = new Vector2(600, 920);
            Vector2 MoneyLocatie5 = new Vector2(110, 800);
            money.Add(new Money(_moneyTexture, MoneyLocatie1, _soundMoney));
            money.Add(new Money(_moneyTexture, MoneyLocatie2, _soundMoney));
            money.Add(new Money(_moneyTexture, MoneyLocatie3, _soundMoney));
            money.Add(new Money(_moneyTexture, MoneyLocatie4, _soundMoney));
            money.Add(new Money(_moneyTexture, MoneyLocatie5, _soundMoney));

            // Immunity
            Vector2 ImmunityLocatie1 = new Vector2(320, 920);
            Vector2 ImmunityLocatie2 = new Vector2(350, 300);
            immunities.Add(new Immunity(_powerupTexture, ImmunityLocatie1, _soundImmunity));
            immunities.Add(new Immunity(_powerupTexture, ImmunityLocatie2, _soundImmunity));

            base.Initialize();
        }
        public override void LoadContent()
        {
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
            var mm = new MovementManager(colliders);
            var col = new CollisionManager(enemysTeleport, enemyTraps, enemyBasic, money, immunities, this);
            hero = new Hero(_heroTexture, new KeyboardReader(), mm, col);
            //lives
            Vector2 lives1Locatie = new Vector2(900, 10);
            Vector2 lives2Locatie = new Vector2(850, 10);
            Vector2 lives3Locatie = new Vector2(800, 10);
            lives1 = new Lives(_livesTexture, lives1Locatie);
            lives2 = new Lives(_livesTexture, lives2Locatie);
            lives3 = new Lives(_livesTexture, lives3Locatie);
            Ubuntu32 = Content.Load<SpriteFont>("font/Ubuntu32");
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
            if (Enemies == 0)
            {
                Level_1_Completed = true;
            }
            if (hero.levels == 0)
            {
                Level1GameOver = true;
            }
        }
        public override void Draw(GameTime gameTime)
        {
            Game.SpriteBatch.Begin();
            tilemapManager.Draw(Game.SpriteBatch);
            Game.SpriteBatch.DrawString(Ubuntu32, "Level 1", new Vector2(10, 5), Color.Black);
            Game.SpriteBatch.DrawString(Ubuntu32, $"$" + Wallet.Instance.Value, new Vector2(230, 5), Color.Gold);
            Game.SpriteBatch.DrawString(Ubuntu32, $"immunity :  " + Powerups.Instance.Value, new Vector2(500, 0), Color.Gold);
            foreach (var i in enemysTeleport)
            {
                i.Draw(Game.SpriteBatch);
            }
            foreach (var i in enemyTraps)
            {
                i.Draw(Game.SpriteBatch);
            }
            foreach (var i in enemyBasic)
            {
                i.Draw(Game.SpriteBatch);
            }
            foreach (var item in money)
            {
                item.Draw(Game.SpriteBatch);
            }
            foreach (var item in immunities)
            {
                item.Draw(Game.SpriteBatch);
            }
            switch (hero.levels)
            {
                case 1:
                    lives1.Draw(Game.SpriteBatch);
                    break;
                case 2:
                    lives1.Draw(Game.SpriteBatch);
                    lives2.Draw(Game.SpriteBatch);
                    break;
                case 3:
                    lives1.Draw(Game.SpriteBatch);
                    lives2.Draw(Game.SpriteBatch);
                    lives3.Draw(Game.SpriteBatch);
                    break;
            }
            hero.Draw(Game.SpriteBatch);
            Game.SpriteBatch.End();
        }
    }
}
