using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project_Game_Dev_2022.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_Dev_2022
{
    public class Hero:IGameObject
    {
        Texture2D heroTexture;
        private Rectangle hero;
        Vector2 positie = new Vector2(5, 5);
        private Vector2 snelheid;

        Texture2D blokTexture;
        Rectangle box;
        Rectangle ToekomstigePositie;
        Vector2 toekomstP;
        bool isFalling = true;
        private bool canJump;

        public Hero()
        {
            hero = new Rectangle((int)positie.X, (int)positie.Y, 10 * 5, 10 * 5);
            ToekomstigePositie = new Rectangle((int)positie.X, (int)positie.Y, 10 * 5, 10 * 5);
            snelheid = new Vector2(5, 5);


        }

        public void Update()
        {
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
            toekomstP = positie + direction;

            if (toekomstP.X > 800 || toekomstP.X < 0 || toekomstP.Y > 480 || toekomstP.Y < 0)
            {
                canJump = true;
                isFalling = false;
            }

            ToekomstigePositie = new Rectangle((int)toekomstP.X, (int)toekomstP.Y, 10 * 5, 10 * 5);

            if (ToekomstigePositie.Intersects(box))
            {
                isFalling = false;
                canJump = true;
            }
            else
            {
                positie = toekomstP;
                isFalling = true;
            }

            hero = new Rectangle((int)positie.X, (int)positie.Y, 10 * 5, 10 * 5);

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, hero, Color.Green);

        }
    }


}
