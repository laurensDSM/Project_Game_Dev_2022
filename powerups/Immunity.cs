using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project_Game_Dev_2022.Animation;

namespace Project_Game_Dev_2022.powerups
{
    public class Immunity
    {

        Animatie animatie;
        private Vector2 immunityMoney;
        private Texture2D immunityTexture;
        public Rectangle ImmunityBox;
        private Vector2 positieImmunity;
        public bool IsUsed = false;




        public Immunity(Texture2D blokTexture, Vector2 positie)
        {
            immunityTexture = blokTexture;
            positieImmunity = new Vector2(-100, -100);
            immunityMoney = positie;

            animatie = new Animatie();
            animatie.AddFrame(new AnimationFrame(new Rectangle(0, 0, 32, 32)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(64, 0, 32, 32)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(128, 0, 32, 32)));




            ImmunityBox = new Rectangle((int)immunityMoney.X, (int)immunityMoney.Y, 10 * 5, 10 * 5);

        }

        public void Update(GameTime gameTime)
        {
            animatie.Update(gameTime);

            if (IsUsed)
            {
                immunityMoney = positieImmunity;
                ImmunityBox = new Rectangle((int)immunityMoney.X, (int)immunityMoney.Y, 10 * 2, 10 * 2);

            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!IsUsed)
            {
                spriteBatch.Draw(immunityTexture, ImmunityBox, animatie.CurrentFrame.SourceRectangle, Color.Brown);

            }




        }



    }
}
