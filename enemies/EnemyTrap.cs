using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Project_Game_Dev_2022.Animation;

namespace Project_Game_Dev_2022.enemies
{
    public class EnemyTrap : Enemie
    {
        Texture2D trapTexture;
        private Vector2 positionEnemy;
        private Vector2 positionHitEnemy;
        private Vector2 positionTrapUsed;
        public Rectangle EnemyBox;
        public Rectangle EnemyHitBox;
        public bool IsAlive = true;
        SoundEffect effect;
        public EnemyTrap(Texture2D blokTexture, Vector2 positie, SoundEffect effect)
        {
            trapTexture = blokTexture;
            positionEnemy = positie;
            positionHitEnemy = positie;
            animation = new Animation.Animation();
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 32, 32)));
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 32, 32)));
            positionTrapUsed = new Vector2(-100, -100);
            this.effect = effect;
            EnemyBox = new Rectangle((int)positionEnemy.X, (int)positionEnemy.Y, 10 * 5, 10 * 5);
            positionHitEnemy.X = positionHitEnemy.X - 5;
            positionHitEnemy.Y = positionHitEnemy.Y + 20;
            EnemyHitBox = new Rectangle((int)positionHitEnemy.X, (int)positionHitEnemy.Y, 10 * 5, 10 * 5);
        }

        public override void Update(GameTime gameTime)
        {
            if (IsAlive)
            {
                animation.Update(gameTime);
            }
            else
            {
                effect.Play();
                positionEnemy = positionTrapUsed;
                positionHitEnemy = positionTrapUsed;
                EnemyBox = new Rectangle((int)positionEnemy.X, (int)positionEnemy.Y, 10 * 5, 10 * 5);
                EnemyHitBox = new Rectangle((int)positionHitEnemy.X, (int)positionHitEnemy.Y, 10 * 5, 10 * 5);
                IsAlive = true;
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(trapTexture, EnemyBox, animation.CurrentFrame.SourceRectangle, Color.White);
        }
    }
}
