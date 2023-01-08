using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Project_Game_Dev_2022.Animation;
using Project_Game_Dev_2022.interfaces;

namespace Project_Game_Dev_2022.money
{
    public class Money : IGameObject
    {
        Texture2D moneyTexture;
        Animation.Animation animation;
        private Vector2 positionMoney;
        public Rectangle MoneyBox;
        private Vector2 positionMoneyUsed;
        public bool IsUsed = false;
        SoundEffect effect;
        public Money(Texture2D blokTexture, Vector2 positie, SoundEffect effect)
        {
            moneyTexture = blokTexture;
            positionMoneyUsed = new Vector2(-100, -100);
            positionMoney = positie;
            animation = new Animation.Animation();
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 16, 16)));
            animation.AddFrame(new AnimationFrame(new Rectangle(16, 0, 16, 16)));
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 16, 16, 16)));
            this.effect = effect;
            MoneyBox = new Rectangle((int)positionMoney.X, (int)positionMoney.Y, 10 * 7, 10 * 7);
        }

        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
            if (IsUsed)
            {
                effect.Play();
                positionMoney = positionMoneyUsed;
                MoneyBox = new Rectangle((int)positionMoney.X, (int)positionMoney.Y, 10 * 2, 10 * 2);
                IsUsed = false;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!IsUsed)
            {
                spriteBatch.Draw(moneyTexture, MoneyBox, animation.CurrentFrame.SourceRectangle, Color.Gold);
            }
        }
    }
}
