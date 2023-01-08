using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Project_Game_Dev_2022.Animation;

namespace Project_Game_Dev_2022.powerups
{
    public class Immunity
    {
        Animation.Animation animation;
        private Vector2 immunityMoney;
        private Texture2D immunityTexture;
        public Rectangle ImmunityBox;
        private Vector2 positieImmunity;
        public bool IsUsed = false;
        SoundEffect effect;
        public Immunity(Texture2D blokTexture, Vector2 positie, SoundEffect effect)
        {
            immunityTexture = blokTexture;
            positieImmunity = new Vector2(-100, -100);
            immunityMoney = positie;
            this.effect = effect;
            animation = new Animation.Animation();
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 32, 32)));
            animation.AddFrame(new AnimationFrame(new Rectangle(64, 0, 32, 32)));
            animation.AddFrame(new AnimationFrame(new Rectangle(128, 0, 32, 32)));
            ImmunityBox = new Rectangle((int)immunityMoney.X, (int)immunityMoney.Y, 10 * 5, 10 * 5);
        }

        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
            if (IsUsed)
            {
                effect.Play();
                immunityMoney = positieImmunity;
                ImmunityBox = new Rectangle((int)immunityMoney.X, (int)immunityMoney.Y, 10 * 2, 10 * 2);
                IsUsed = false;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!IsUsed)
            {
                spriteBatch.Draw(immunityTexture, ImmunityBox, animation.CurrentFrame.SourceRectangle, Color.Brown);
            }
        }
    }
}
