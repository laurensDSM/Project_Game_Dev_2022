﻿using Microsoft.Xna.Framework;
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
        Texture2D enemyTexture;
        Rectangle enemyBox;
        public EnemyBasic(Texture2D blokTexture)
        {
            enemyTexture = blokTexture;
            snelheid = new Vector2(1, 0);
            positieEnemy = new Vector2(640, 350);
            enemyBox = new Rectangle((int)positieEnemy.X, (int)positieEnemy.Y, 10 * 5, 10 * 5);

        }


        public override void Update()
        {

            positieEnemy += snelheid;
            if (positieEnemy.X > 650 || positieEnemy.X < 580)
            {
                snelheid.X *= -1;
            }

            enemyBox = new Rectangle((int)positieEnemy.X, (int)positieEnemy.Y, 10 * 5, 10 * 5);

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(enemyTexture, enemyBox, Color.LightBlue);

        }
    }
}
