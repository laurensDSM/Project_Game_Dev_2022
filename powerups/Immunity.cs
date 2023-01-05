using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project_Game_Dev_2022.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_Dev_2022.powerups
{
    public  class Immunity
    {

      
            private Vector2 immunityMoney;
            private Texture2D immunityTexture;
            public Rectangle ImmunityBox;
            private Vector2 positieImmunity;
            public bool IsUsed = false;



            public Immunity(Texture2D blokTexture, Vector2 positie)
            {
                immunityTexture = blokTexture;
                positieImmunity = new Vector2(-100, -100);
                immunityMoney = positie;
                ImmunityBox = new Rectangle((int)immunityMoney.X, (int)immunityMoney.Y, 10 * 2, 10 * 2);

            }

            public void Update(GameTime gameTime)
            {
                if (IsUsed)
                {
                    immunityMoney = positieImmunity;
                    ImmunityBox = new Rectangle((int)immunityMoney.X, (int)immunityMoney.Y, 10 * 2, 10 * 2);

                }
            }

            public void Draw(SpriteBatch spriteBatch)
            {
                if (!IsUsed)
                {
                    spriteBatch.Draw(immunityTexture, ImmunityBox, Color.Brown);

                }




            }


        
    }
}
