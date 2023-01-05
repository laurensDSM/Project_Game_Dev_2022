using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project_Game_Dev_2022.Animation;
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

        Texture2D enemyTexture;
        Animatie animatie;
        private Vector2 snelheid;
        private Vector2 positieEnemy;
        private Vector2 maximalePositieEnemy;
        private Vector2 positieRechts;
        private Vector2 positieLinks;
        private Vector2 positieEnemyDead;


        public Rectangle EnemyBox;
        private int counter;
        DateTime Start = DateTime.Now;
        public bool IsAlive = true;

        public EnemyTeleport(Texture2D blokTexture)
        {
            enemyTexture = blokTexture;
            snelheid = new Vector2(1, 0);
            positieEnemy = new Vector2(180, 70);
            positieEnemyDead = new Vector2(-20, -20);
            maximalePositieEnemy = new Vector2(20, 20);

            animatie = new Animatie();
            animatie.AddFrame(new AnimationFrame(new Rectangle(0, 0, 32, 32)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(32, 0, 32, 32)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(64, 0, 32, 32)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(96, 0, 32, 32)));



            EnemyBox = new Rectangle((int)positieEnemy.X, (int)positieEnemy.Y, 10 * 5, 10 * 5);

        }
        public override void Update(GameTime gameTime)
        {

            if (IsAlive) {

                animatie.Update(gameTime);

                counter++;
            //Debug.Write(counter);
            Random rand = new Random();
            DateTime StartUpdate = DateTime.Now;
            TimeSpan span = (Start - StartUpdate );
             int tijdsverschil  = (int) span.TotalSeconds;

            if (tijdsverschil <=  -10)
            {
                //Debug.WriteLine("Ja 10 seconde");
           
            int mogelijkePositie = rand.Next(0, 5);
           // Debug.WriteLine(mogelijkePositie);
            
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
          //  Debug.Write($"Rechts" + positieRechts + "links" + positieLinks);
            if (positieEnemy.X > positieLinks.X || positieEnemy.X < positieRechts.X)
            {
                snelheid.X *= -1;
            }


            EnemyBox = new Rectangle((int)positieEnemy.X, (int)positieEnemy.Y, 10 * 5, 10 * 5);
            }
            else
            {
                positieEnemy = positieEnemyDead;
            }
            EnemyBox = new Rectangle((int)positieEnemy.X, (int)positieEnemy.Y, 10 * 5, 10 * 5);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (IsAlive)
            {
                spriteBatch.Draw(enemyTexture, EnemyBox, animatie.CurrentFrame.SourceRectangle, Color.Pink);

            }

        }
    }
}
