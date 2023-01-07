using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project_Game_Dev_2022.Animation;

namespace Project_Game_Dev_2022.enemy_s
{
    public class EnemyTrap : Enemy
    {

        Texture2D trapTexture;
        Animatie animatie1;

        private Vector2 snelheid;
        private Vector2 positieEnemy;
        public Rectangle EnemyBox;
        private Vector2 positieTrapUsed;
        public bool IsAlive = true;



        public EnemyTrap(Texture2D blokTexture, Vector2 positie)
        {
            trapTexture = blokTexture;
            snelheid = new Vector2(1, 0);
            positieEnemy = positie;

            animatie1 = new Animatie();
            animatie1.AddFrame(new AnimationFrame(new Rectangle(0, 0, 32, 32)));
            animatie1.AddFrame(new AnimationFrame(new Rectangle(0, 0, 32, 32)));

            positieTrapUsed = new Vector2(-100, -100);

            EnemyBox = new Rectangle((int)positieEnemy.X, (int)positieEnemy.Y, 10 * 5, 10 * 5);

        }

        public override void Update(GameTime gameTime)
        {
            if (IsAlive)
            {
                animatie1.Update(gameTime);
            }
            else
            {
                positieEnemy = positieTrapUsed;
                EnemyBox = new Rectangle((int)positieEnemy.X, (int)positieEnemy.Y, 10 * 5, 10 * 5);

            }


        }
        public override void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(trapTexture, EnemyBox, animatie1.CurrentFrame.SourceRectangle, Color.White);

        }
    }
}
