using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project_Game_Dev_2022.interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Game_Dev_2022
{
    public class Enemy : IGameObject
    {
        private Vector2 snelheid;
        private Vector2 positieEnemy;
        Texture2D enemyTexture;
        Rectangle enemyBox;




        public Enemy(Texture2D blokTexture)
        {
            enemyTexture = blokTexture;
            snelheid = new Vector2(1, 0);
            positieEnemy = new Vector2(640, 350);
            enemyBox = new Rectangle((int)positieEnemy.X, (int)positieEnemy.Y, 10 * 5, 10 * 5);

        }




        public void Update()
        {

            positieEnemy += snelheid;
            if (positieEnemy.X > 650|| positieEnemy.X < 580)
            {
                snelheid.X *= -1;
            }

            enemyBox = new Rectangle((int)positieEnemy.X, (int)positieEnemy.Y, 10 * 5, 10 * 5);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(enemyTexture, enemyBox, Color.Brown);

        }
    }
}
