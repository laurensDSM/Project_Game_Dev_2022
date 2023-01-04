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
    public class EnemyBasic : Enemy
    {
        private Vector2 snelheid;
        private Vector2 positieEnemy;
        private Texture2D enemyTexture;
        public Rectangle EnemyBox;
        public bool IsAlive = true;
        private Vector2 positieEnemyDead;


        public EnemyBasic(Texture2D blokTexture, Vector2 positie)
        {
            enemyTexture = blokTexture;
            positieEnemy = positie;
            positieEnemyDead = new Vector2(-100, -100);
            snelheid = new Vector2(1, 0);
            EnemyBox = new Rectangle((int)positieEnemy.X, (int)positieEnemy.Y, 10 * 5, 10 * 5);

        }


        public override void Update()
        {
            if (IsAlive)
            {
                positieEnemy += snelheid;
                if (positieEnemy.X > 650 || positieEnemy.X < 580)
                {
                    snelheid.X *= -1;
                }
            }
            else
            {
                positieEnemy = positieEnemyDead;
            }


            EnemyBox = new Rectangle((int)positieEnemy.X, (int)positieEnemy.Y, 10 * 5, 10 * 5);

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(enemyTexture, EnemyBox, Color.LightBlue);

        }
    }
}
