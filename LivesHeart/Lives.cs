using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project_Game_Dev_2022.Animation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_Dev_2022.LivesHeart
{
    public class Lives
    {
        Texture2D livesTexture;
        Animatie animatie;
        private Vector2 positieMoney;
        public Rectangle LivesBox;


        public Lives(Texture2D blokTexture, Vector2 positie)
        {
            livesTexture = blokTexture;
            positieMoney = positie;
            animatie = new Animatie();
            animatie.AddFrame(new AnimationFrame(new Rectangle(0, 0, 32, 32)));
            LivesBox = new Rectangle((int)positieMoney.X, (int)positieMoney.Y, 10 * 4, 10 * 4);

        }

        public void Update(GameTime gameTime)
        {
            animatie.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(livesTexture, LivesBox, animatie.CurrentFrame.SourceRectangle, Color.White);

        }
    }
}
