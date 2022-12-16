using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project_Game_Dev_2022.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Game_Dev_2022
{
    public class Enemy : IGameObject
    {
        private Vector2 snelheid;
        private Vector2 postieEnemy;
        Texture2D enemyTexture;
        Rectangle enemyBox;


        public Enemy(Texture2D blokTexture)
        {
            enemyTexture = blokTexture;
            postieEnemy = new Vector2(600, 350);
            enemyBox = new Rectangle((int)postieEnemy.X, (int)postieEnemy.Y, 10 * 5, 10 * 5);


        }




        public void Update()
        {


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(enemyTexture, enemyBox, Color.Brown);


        }
    }
}
