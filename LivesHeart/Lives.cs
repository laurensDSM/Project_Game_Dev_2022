using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project_Game_Dev_2022.Animation;

namespace Project_Game_Dev_2022.LivesHeart
{
    public class Lives
    {
        Texture2D livesTexture;
        Animation.Animation animation;
        private Vector2 positionMoney;
        public Rectangle LivesBox;
        public Lives(Texture2D blokTexture, Vector2 positie)
        {
            livesTexture = blokTexture;
            positionMoney = positie;
            animation = new Animation.Animation();
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 32, 32)));
            LivesBox = new Rectangle((int)positionMoney.X, (int)positionMoney.Y, 10 * 4, 10 * 4);
        }
        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(livesTexture, LivesBox, animation.CurrentFrame.SourceRectangle, Color.White);

        }
    }
}
