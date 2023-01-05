using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project_Game_Dev_2022.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_Dev_2022.money
{
    public class Money : IGameObject
    {
        private Vector2 positieMoney;
        private Texture2D moneyTexture;
        public Rectangle MoneyBox;
        private Vector2 positieMoneyUsed;
        public bool IsUsed = false;



        public Money(Texture2D blokTexture, Vector2 positie)
        {
            moneyTexture = blokTexture;
            positieMoneyUsed = new Vector2(-100,-100);
            positieMoney = positie;
            MoneyBox = new Rectangle((int)positieMoney.X, (int)positieMoney.Y, 10 * 2, 10 * 2);

        }

        public void Update(GameTime gameTime)
        {
            if (IsUsed)
            {
                positieMoney = positieMoneyUsed;
                MoneyBox = new Rectangle((int)positieMoney.X, (int)positieMoney.Y, 10 * 2, 10 * 2);

            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!IsUsed)
            {
                spriteBatch.Draw(moneyTexture, MoneyBox, Color.Gold);

            }




        }


    }
}
