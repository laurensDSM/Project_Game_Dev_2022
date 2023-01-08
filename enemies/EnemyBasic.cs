using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project_Game_Dev_2022.Animation;

namespace Project_Game_Dev_2022.enemies
{
    public class EnemyBasic : Enemy
    {

        Texture2D enemyTexture;

        private Vector2 snelheid;
        private Vector2 positieEnemy;
        private Vector2 positieMeegeven;
        public Rectangle EnemyBox;
        public bool IsAlive = true;
        private Vector2 positieEnemyDead;

        public SpriteEffects effects;

        public EnemyBasic(Texture2D blokTexture, Vector2 positie)
        {
            enemyTexture = blokTexture;
            positieEnemy = positie;
            positieMeegeven = positie;
            positieEnemyDead = new Vector2(-100, -100);
            snelheid = new Vector2(1, 0);
            effects = SpriteEffects.None;

            animatie.AddFrame(new AnimationFrame(new Rectangle(0, 64, 64, 64)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(64, 64, 64, 64)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(128, 64, 64, 64)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(192, 64, 64, 64)));
            EnemyBox = new Rectangle((int)positieEnemy.X, (int)positieEnemy.Y, 10 * 5, 10 * 5);

        }


        public override void Update(GameTime gameTime)
        {
            if (IsAlive)
            {
                animatie.Update(gameTime);

                positieEnemy += snelheid;
                if (positieEnemy.X > (positieMeegeven.X+50) || positieEnemy.X < (positieMeegeven.X-50))
                {
                    snelheid.X *= -1;
                    effects = SpriteEffects.FlipHorizontally;
                }
            }
            else
            {
                positieEnemy = positieEnemyDead;
                effects = SpriteEffects.None;

            }


            EnemyBox = new Rectangle((int)positieEnemy.X, (int)positieEnemy.Y, 10 * 5, 10 * 5);

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(enemyTexture, EnemyBox, animatie.CurrentFrame.SourceRectangle, Color.LightBlue);


        }
    }
}
