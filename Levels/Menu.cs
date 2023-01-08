using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens;
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
        private TmxMap map;
        private TileMapManager tilemapManager;
        private Texture2D tileset;
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
            Ubuntu32 = Content.Load<SpriteFont>("font/Ubuntu32");
            map = new TmxMap("Content/screen.tmx");
            tileset = Content.Load<Texture2D>(map.Tilesets[0].Name.ToString());
            int tileWidth = map.Tilesets[0].TileWidth;
            int tileHeight = map.Tilesets[0].TileHeight;
            int tileSetTileWidth = tileset.Width / tileWidth;
            tilemapManager = new TileMapManager(map, tileset, tileSetTileWidth, tileWidth, tileHeight);
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
            Game.SpriteBatch.Begin();
            tilemapManager.Draw(Game.SpriteBatch);
            Game.SpriteBatch.DrawString(Ubuntu32, "WELKOM BIJ HET SPEL VAN LAURENS", new Vector2(150, 100), Color.White);
            #region StartDraw
            if (hoverStart)
            {
                Game.SpriteBatch.Draw(blokTexture, start, Color.LightGreen);
            }
            else
            {
                Game.SpriteBatch.Draw(blokTexture, start, Color.Green);
            }
            Game.SpriteBatch.DrawString(Ubuntu32, "START     [5]", new Vector2(450, 220), Color.Black);
            #endregion
            #region StopDraw
            if (hoverStop)
            {
                Game.SpriteBatch.Draw(blokTexture, stop, Color.LightSalmon);
            }
            else
            {
                Game.SpriteBatch.Draw(blokTexture, stop, Color.Red);
            }
            Game.SpriteBatch.DrawString(Ubuntu32, "STOP      [0]", new Vector2(450, 420), Color.Black);
            #endregion
            Game.SpriteBatch.End();
        }
    }
}
