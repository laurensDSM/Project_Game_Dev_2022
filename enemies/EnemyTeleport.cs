﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Project_Game_Dev_2022.Animation;
using System;

namespace Project_Game_Dev_2022.enemies
{
    public class EnemyTeleport : Enemy
    {

        Texture2D enemyTexture;
        private Vector2 snelheid;
        private Vector2 positieEnemy;
        private Vector2 maximalePositieEnemy;
        private Vector2 positieRechts;
        private Vector2 positieLinks;
        private Vector2 positieEnemyDead;

        private int  play;
        public Rectangle EnemyBox;
        private int counter;
        DateTime Start = DateTime.Now;
        public bool IsAlive = true;
        SoundEffect effect;

        public EnemyTeleport(Texture2D blokTexture, SoundEffect effect)
        {
            enemyTexture = blokTexture;
            snelheid = new Vector2(1, 0);
            positieEnemy = new Vector2(200, 190);
            positieEnemyDead = new Vector2(-20, -20);
            maximalePositieEnemy = new Vector2(20, 20);
            this.effect = effect;

            animatie = new Animatie();
            animatie.AddFrame(new AnimationFrame(new Rectangle(0, 0, 32, 32)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(32, 0, 32, 32)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(64, 0, 32, 32)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(96, 0, 32, 32)));



            EnemyBox = new Rectangle((int)positieEnemy.X, (int)positieEnemy.Y, 10 * 5, 10 * 5);

        }
        public override void Update(GameTime gameTime)
        {

            if (IsAlive)
            {

                animatie.Update(gameTime);

                counter++;
                //Debug.Write(counter);
                Random rand = new Random();
                DateTime StartUpdate = DateTime.Now;
                TimeSpan span = (Start - StartUpdate);
                int tijdsverschil = (int)span.TotalSeconds;

                if (tijdsverschil <= -7)
                {
                    //Debug.WriteLine("Ja 7 seconde");

                    int mogelijkePositie = rand.Next(0, 5);


                    // Debug.WriteLine(mogelijkePositie);

                    switch (mogelijkePositie)
                    {

                        case 0:
                            positieEnemy = new Vector2(200, 190);
                            counter = 0;
                            Start = DateTime.Now;

                            break;
                        case 1:
                            positieEnemy = new Vector2(300, 910);
                            counter = 0;
                            Start = DateTime.Now;

                            break;
                        case 2:
                            positieEnemy = new Vector2(300, 430);
                            counter = 0;
                            Start = DateTime.Now;

                            break;
                        case 3:
                            positieEnemy = new Vector2(200, 800);
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
                play++;
                if (play==1)
                {
                    effect.Play();

                }
                positieEnemy = positieEnemyDead;
                EnemyBox = new Rectangle((int)positieEnemy.X, (int)positieEnemy.Y, 10 * 5, 10 * 5);
            }

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
