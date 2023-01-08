using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project_Game_Dev_2022.Animation;
using Project_Game_Dev_2022.Input;
using Project_Game_Dev_2022.interfaces;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Project_Game_Dev_2022
{


    public class Hero : IGameObject
    {

        Texture2D heroTexture;
        Animatie animatie;


        private Vector2 snelheid;
        private Vector2 positieHero;
        Rectangle hitBox;
        internal bool canJump;
        internal bool isFalling;
        internal int counter;
        internal bool collidedWithTrap;
        internal bool collidedWithEnemyTeleport;
        internal bool collidedWithEnemyBasic;
        internal bool collidedWithMoney;
        internal bool invisible;
        internal int money;
        internal int immunity = 0;
        internal int levels = 3;
        internal int counterInv;

        internal int counterPinky;
        DateTime Start = DateTime.Now;





        public IInputReader InputReader { get; set; }
        public MovementManager MovementManager { get; set; }
        public CollisionManager CollisionManager { get; set; }





        public Hero(Texture2D blokTexture, IInputReader inputReader, MovementManager mm, CollisionManager col)
        {
            canJump = true;
            isFalling = true;
            heroTexture = blokTexture;
            MovementManager = mm;
            CollisionManager = col;
            counter = 0;
            InputReader = inputReader;
            snelheid = new Vector2(5, 5);
            positieHero = new Vector2(70, 70);


            animatie = new Animatie();
            animatie.AddFrame(new AnimationFrame(new Rectangle(0, 0, 180, 247)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(180, 0, 180, 247)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(360, 0, 180, 247)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(540, 0, 180, 247)));






            hitBox = new Rectangle((int)positieHero.X, (int)positieHero.Y, 10 * 5, 10 * 5);


        }

        public void Update(GameTime gameTime)
        {




            counterPinky++;
            Vector2 direction = InputReader.ReadInput();

            direction = MovementManager.Move(this, direction);


            var afstand = direction * snelheid;
            var toekomstPositie = positieHero + afstand;
            Rectangle toekomstRectangle = new Rectangle((int)toekomstPositie.X, (int)toekomstPositie.Y, 10 * 5, 10 * 5);

            bool hasCollided = MovementManager.HasCollided(this, toekomstRectangle);
            if (!hasCollided)
            {
                positieHero = toekomstPositie;

            }



            bool hasCollidedWithTrap = CollisionManager.HasCollidedWithTrap(this, toekomstRectangle);
            bool hasCollidedWithEnemieTeleport = CollisionManager.HasCollidedWithEnemieTeleport(this, toekomstRectangle);
            bool hasCollidedWithEnemieBasic = CollisionManager.HasCollidedWithEnemieBasic(this, toekomstRectangle);
            CollisionManager.HasCollidedWithMoney(this, toekomstRectangle);
            CollisionManager.HasCollidedWithImmunity(this, toekomstRectangle);



            if (hasCollidedWithTrap)
            {
                collidedWithTrap = true;
            }
            else
            {
                collidedWithTrap = false;
            }

            if (hasCollidedWithEnemieTeleport)
            {
                collidedWithEnemyTeleport = true;
            }
            else
            {
                collidedWithEnemyTeleport = false;
            }
            if (hasCollidedWithEnemieBasic)
            {
                collidedWithEnemyBasic = true;
            }
            else
            {
                collidedWithEnemyBasic = false;
            }

            if (invisible)
            {
                counterInv++;
                if (counterInv >= 100)
                {
                    counterInv = 0;
                    invisible = false;
                }
            }






            animatie.Update(gameTime);
            hitBox = new Rectangle((int)positieHero.X, (int)positieHero.Y, 10 * 5, 10 * 5);
        }



        public void Draw(SpriteBatch spriteBatch)
        {


            if (immunity <= 0 && collidedWithTrap)
            {
                invisible = true;
            }

            if (invisible)
            {
                spriteBatch.Draw(heroTexture, hitBox, animatie.CurrentFrame.SourceRectangle, Color.Red);

            }
            else
            {
                spriteBatch.Draw(heroTexture, hitBox, animatie.CurrentFrame.SourceRectangle, Color.White);

            }





        }
    }
}
