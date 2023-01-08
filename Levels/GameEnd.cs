using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledSharp;

namespace Project_Game_Dev_2022.Levels
{
    public class GameEnd : GameScreen
    {
        private new Game1 Game => (Game1)base.Game;

        Texture2D blokTexture;
        SpriteFont Ubuntu32;
        Rectangle menu;
        Rectangle stop;
        Rectangle level1;
        Rectangle level2;
        Rectangle mouse;
        bool hoverMenu = false;
        bool hoverStop = false;
        bool hoverLevel1 = false;
        bool hoverLevel2 = false;

        public static bool Stop = false;
        public static bool Menu = false;
        public static bool Level1 = false;
        public static bool Level2 = false;

        private TmxMap map;
        private TileMapManager tilemapManager;
        private Texture2D tileset;
        public GameEnd(Game game) : base(game)
        {
        }

        public override void LoadContent()
        {
            blokTexture = new Texture2D(GraphicsDevice, 1, 1);
            blokTexture.SetData(new[] { Color.White });

            menu = new Rectangle(330, 200, 400, 80);
            level1 = new Rectangle(330, 400, 400, 80);
            level2 = new Rectangle(330, 600, 400, 80);
            stop = new Rectangle(330, 800, 400, 80);



            mouse = new Rectangle(0, 0, 10, 10);

            //Text
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

            #region MenuUpdate
            if (menu.Intersects(mouse) && state.LeftButton == ButtonState.Pressed)
            {
                Menu = true;

            }
            if (menu.Intersects(mouse))
            {
                hoverMenu = true;

            }
            else
            {
                hoverMenu = false;
            }
            #endregion


            #region Level1Update
            if (level1.Intersects(mouse) && state.LeftButton == ButtonState.Pressed)
            {
                Level1 = true;

            }
            if (level1.Intersects(mouse))
            {
                hoverLevel1 = true;

            }
            else
            {
                hoverLevel1 = false;
            }
            #endregion

            #region Level2Update
            if (level2.Intersects(mouse) && state.LeftButton == ButtonState.Pressed)
            {
                Level2 = true;

            }
            if (level2.Intersects(mouse))
            {
                hoverLevel2 = true;

            }
            else
            {
                hoverLevel2 = false;
            }
            #endregion

            #region StopUpdate
            if (stop.Intersects(mouse) && state.LeftButton == ButtonState.Pressed)
            {
                Stop = true;
            }

            if (stop.Intersects(mouse))
            {
                hoverStop = true;
            }
            else
            {
                hoverStop = false;
            }
            #endregion

        }
        public override void Draw(GameTime gameTime)
        {

            Game.SpriteBatch.Begin();
            tilemapManager.Draw(Game.SpriteBatch);

            Game.SpriteBatch.DrawString(Ubuntu32, "Bravo u heeft iedereen gedood", new Vector2(150, 100), Color.White);
            #region MenuDraw
            if (hoverMenu)
            {
                Game.SpriteBatch.Draw(blokTexture, menu, Color.LightGreen);

            }
            else
            {
                Game.SpriteBatch.Draw(blokTexture, menu, Color.Green);

            }

            Game.SpriteBatch.DrawString(Ubuntu32, "Menu      [9]", new Vector2(450, 220), Color.Black);

            #endregion

            #region Levell1Draw
            if (hoverLevel1)
            {
                Game.SpriteBatch.Draw(blokTexture, level1, Color.LightYellow);

            }
            else
            {
                Game.SpriteBatch.Draw(blokTexture, level1, Color.Yellow);

            }

            Game.SpriteBatch.DrawString(Ubuntu32, "Level 1     [1]", new Vector2(450, 420), Color.Black);

            #endregion

            #region Level2Draw
            if (hoverLevel2)
            {
                Game.SpriteBatch.Draw(blokTexture, level2, Color.LightYellow);

            }
            else
            {
                Game.SpriteBatch.Draw(blokTexture, level2, Color.Yellow);

            }

            Game.SpriteBatch.DrawString(Ubuntu32, "Level 2    [2]", new Vector2(450, 620), Color.Black);

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

            Game.SpriteBatch.DrawString(Ubuntu32, "STOP      [0]", new Vector2(450, 820), Color.Black);

            #endregion

            Game.SpriteBatch.End();







        }
    }
}
