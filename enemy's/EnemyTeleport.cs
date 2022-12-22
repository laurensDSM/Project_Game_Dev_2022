using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_Dev_2022.enemy_s
{
    public class EnemyTeleport : Enemy
    {
        private Vector2 snelheid;
        private Vector2 positieEnemy;
        private Vector2 maximalePositieEnemy;
        private Vector2 positieRechts;
        private Vector2 positieLinks;

        Texture2D enemyTexture;
        Rectangle enemyBox;
        private int counter;
        DateTime Start = DateTime.Now;

        public EnemyTeleport(Texture2D blokTexture)
        {
            enemyTexture = blokTexture;
            snelheid = new Vector2(1, 0);
            positieEnemy = new Vector2(180, 70);
            maximalePositieEnemy = new Vector2(20, 20);
            enemyBox = new Rectangle((int)positieEnemy.X, (int)positieEnemy.Y, 10 * 5, 10 * 5);

        }
        public override void Update()
        {
            counter++;
            Debug.Write(counter);
            Random rand = new Random();
            DateTime StartUpdate = DateTime.Now;
            TimeSpan span = (Start - StartUpdate );
             int tijdsverschil  = (int) span.TotalSeconds;

            if (tijdsverschil <=  -10)
            {
                Debug.WriteLine("Ja 10 seconde");
           
            int mogelijkePositie = rand.Next(0, 5);
            Debug.WriteLine(mogelijkePositie);
            
            switch (mogelijkePositie)
            {

                case 0:
                    positieEnemy = new Vector2(10, 70);
                    counter = 0;
                         Start = DateTime.Now;

                        break;
                case 1:
                    positieEnemy = new Vector2(300, 350);
                    counter = 0;
                         Start = DateTime.Now;

                        break;
                case 2:
                    positieEnemy = new Vector2(400, 70);
                    counter = 0;
                         Start = DateTime.Now;

                        break;
                case 3:
                    positieEnemy = new Vector2(180, 350);
                    counter = 0;
                         Start = DateTime.Now;


                        break;
                }
            }

            positieEnemy += snelheid;
            positieRechts = positieEnemy - maximalePositieEnemy;
            positieLinks = positieEnemy + maximalePositieEnemy;
            Debug.Write($"Rechts" + positieRechts + "links" + positieLinks);
            if (positieEnemy.X > positieLinks.X || positieEnemy.X < positieRechts.X)
            {
                snelheid.X *= -1;
            }


            enemyBox = new Rectangle((int)positieEnemy.X, (int)positieEnemy.Y, 10 * 5, 10 * 5);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(enemyTexture, enemyBox, Color.Pink);

        }
    }
}
