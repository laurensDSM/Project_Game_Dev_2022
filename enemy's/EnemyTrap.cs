using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_Dev_2022.enemy_s
{
    public class EnemyTrap : Enemy
    {
        private Vector2 snelheid;
        private Vector2 positieEnemy;
        Texture2D enemyTexture;
        public Rectangle EnemyBox;
        public EnemyTrap(Texture2D blokTexture, Vector2 positie)
        {
            enemyTexture = blokTexture;
            snelheid = new Vector2(1, 0);

            positieEnemy = positie;
            EnemyBox = new Rectangle((int)positieEnemy.X, (int)positieEnemy.Y, 10 * 5, 10 * 5);

        }

        public override void Update()
        {


        }
        public override void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(enemyTexture, EnemyBox, Color.Yellow);

        }
    }
}
