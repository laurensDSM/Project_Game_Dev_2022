﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Project_Game_Dev_2022.Animation;
using Project_Game_Dev_2022.interfaces;

namespace Project_Game_Dev_2022.money
{
    public class Money : IGameObject
    {

        Texture2D moneyTexture;
        Animatie animatie;
        private Vector2 positieMoney;
        public Rectangle MoneyBox;
        private Vector2 positieMoneyUsed;
        public bool IsUsed = false;
        SoundEffect effect;



        public Money(Texture2D blokTexture, Vector2 positie, SoundEffect effect)
        {
            moneyTexture = blokTexture;
            positieMoneyUsed = new Vector2(-100, -100);
            positieMoney = positie;

            animatie = new Animatie();
            animatie.AddFrame(new AnimationFrame(new Rectangle(0, 0, 16, 16)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(16, 0, 16, 16)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(0, 16, 16, 16)));
            this.effect = effect;

            MoneyBox = new Rectangle((int)positieMoney.X, (int)positieMoney.Y, 10 * 7, 10 * 7);

        }

        public void Update(GameTime gameTime)
        {
            animatie.Update(gameTime);


            if (IsUsed)
            {
                effect.Play();

                positieMoney = positieMoneyUsed;
                MoneyBox = new Rectangle((int)positieMoney.X, (int)positieMoney.Y, 10 * 2, 10 * 2);
                IsUsed = false;
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            if (!IsUsed)
            {
                spriteBatch.Draw(moneyTexture, MoneyBox, animatie.CurrentFrame.SourceRectangle, Color.Gold);

            }




        }


    }
}
