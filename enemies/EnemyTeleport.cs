using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Project_Game_Dev_2022.Animation;
using System;

namespace Project_Game_Dev_2022.enemies
{
    public class EnemyTeleport : Enemie
    {

        Texture2D enemyTexture;
        private Vector2 speed;
        private Vector2 positionEnemy;
        private Vector2 maxPositionEnemy;
        private Vector2 positionRight;
        private Vector2 positionLeft;
        private Vector2 positionEnemyDead;
        private int play;
        private int counter;
        public bool IsAlive = true;
        public Rectangle EnemyBox;
        DateTime Start = DateTime.Now;
        SoundEffect effect;

        public EnemyTeleport(Texture2D blokTexture, SoundEffect effect)
        {
            enemyTexture = blokTexture;
            speed = new Vector2(1, 0);
            positionEnemy = new Vector2(200, 190);
            positionEnemyDead = new Vector2(-20, -20);
            maxPositionEnemy = new Vector2(20, 20);
            this.effect = effect;
            animation = new Animation.Animation();
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 32, 32)));
            animation.AddFrame(new AnimationFrame(new Rectangle(32, 0, 32, 32)));
            animation.AddFrame(new AnimationFrame(new Rectangle(64, 0, 32, 32)));
            animation.AddFrame(new AnimationFrame(new Rectangle(96, 0, 32, 32)));
            EnemyBox = new Rectangle((int)positionEnemy.X, (int)positionEnemy.Y, 10 * 5, 10 * 5);
        }
        public override void Update(GameTime gameTime)
        {
            if (IsAlive)
            {
                animation.Update(gameTime);
                counter++;
                Random rand = new Random();
                DateTime StartUpdate = DateTime.Now;
                TimeSpan span = (Start - StartUpdate);
                int tijdsverschil = (int)span.TotalSeconds;

                if (tijdsverschil <= -7)
                {
                    int mogelijkePositie = rand.Next(0, 5);
                    switch (mogelijkePositie)
                    {
                        case 0:
                            positionEnemy = new Vector2(200, 190);
                            counter = 0;
                            Start = DateTime.Now;
                            break;
                        case 1:
                            positionEnemy = new Vector2(300, 910);
                            counter = 0;
                            Start = DateTime.Now;
                            break;
                        case 2:
                            positionEnemy = new Vector2(300, 430);
                            counter = 0;
                            Start = DateTime.Now;
                            break;
                        case 3:
                            positionEnemy = new Vector2(200, 800);
                            counter = 0;
                            Start = DateTime.Now;
                            break;
                    }
                }
                positionEnemy += speed;
                positionRight = positionEnemy - maxPositionEnemy;
                positionLeft = positionEnemy + maxPositionEnemy;
                //  Debug.Write($"Rechts" + positieRechts + "links" + positieLinks);
                if (positionEnemy.X > positionLeft.X || positionEnemy.X < positionRight.X)
                {
                    speed.X *= -1;
                }
                EnemyBox = new Rectangle((int)positionEnemy.X, (int)positionEnemy.Y, 10 * 5, 10 * 5);
            }
            else
            {
                play++;
                if (play == 1)
                {
                    effect.Play();
                }
                positionEnemy = positionEnemyDead;
                EnemyBox = new Rectangle((int)positionEnemy.X, (int)positionEnemy.Y, 10 * 5, 10 * 5);
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (IsAlive)
            {
                spriteBatch.Draw(enemyTexture, EnemyBox, animation.CurrentFrame.SourceRectangle, Color.Pink);
            }
        }
    }
}
