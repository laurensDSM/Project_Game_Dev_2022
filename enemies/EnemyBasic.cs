using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Project_Game_Dev_2022.Animation;

namespace Project_Game_Dev_2022.enemies
{
    public class EnemyBasic : Enemie
    {
        Texture2D enemyTexture;
        private Vector2 speed;
        private Vector2 positionEnemy;
        private Vector2 positionMeegeven;
        private Vector2 positionEnemyDead;
        private bool left = false;
        SoundEffect effect;
        public Rectangle EnemyBox;
        public bool IsAlive = true;

        public EnemyBasic(Texture2D blokTexture, Vector2 positie, SoundEffect effect)
        {
            enemyTexture = blokTexture;
            positionEnemy = positie;
            positionMeegeven = positie;
            positionEnemyDead = new Vector2(-100, -100);
            speed = new Vector2(1, 0);
            this.effect = effect;
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 64, 64, 64)));
            animation.AddFrame(new AnimationFrame(new Rectangle(64, 64, 64, 64)));
            animation.AddFrame(new AnimationFrame(new Rectangle(128, 64, 64, 64)));
            animation.AddFrame(new AnimationFrame(new Rectangle(192, 64, 64, 64)));
            EnemyBox = new Rectangle((int)positionEnemy.X, (int)positionEnemy.Y, 10 * 5, 10 * 5);
        }

        public override void Update(GameTime gameTime)
        {
            if (IsAlive)
            {
                animation.Update(gameTime);
                positionEnemy += speed;
                if (positionEnemy.X > (positionMeegeven.X + 50) || positionEnemy.X < (positionMeegeven.X - 50))
                {
                    speed.X *= -1;
                }
                if (positionEnemy.X > (positionMeegeven.X + 50))
                {
                    left = true;
                }
                if (positionEnemy.X < (positionMeegeven.X - 50))
                {
                    left = false;
                }
            }
            else
            {
                effect.Play();
                positionEnemy = positionEnemyDead;
                IsAlive = true;
            }
            EnemyBox = new Rectangle((int)positionEnemy.X, (int)positionEnemy.Y, 10 * 5, 10 * 5);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (left)
            {
                spriteBatch.Draw(enemyTexture, EnemyBox, animation.CurrentFrame.SourceRectangle, Color.LightBlue);
            }
            else
            {
                //inverse 
                // effects = SpriteEffects.FlipHorizontally;
                spriteBatch.Draw(enemyTexture, EnemyBox, animation.CurrentFrame.SourceRectangle, Color.LightBlue);
            }
        }
    }
}
