using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project_Game_Dev_2022.Animation;
using Project_Game_Dev_2022.Input;
using Project_Game_Dev_2022.interfaces;

namespace Project_Game_Dev_2022
{


    public class Hero : IGameObject
    {
        Texture2D heroTexture;
        Animation.Animation animation;
        Animation.Animation animation2;
        private Vector2 speed;
        private Vector2 positionHero;
        Rectangle hitBox;
        internal bool canJump;
        internal bool isFalling;
        internal int counter;
        internal bool collidedWithTrap;
        internal bool collidedWithEnemyTeleport;
        internal bool collidedWithEnemyBasic;
        internal bool left;
        internal bool invisible;
        internal int money;
        internal int immunity = 0;
        internal int levels = 3;
        internal int counterInv;
        internal int counterPinky;
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
            speed = new Vector2(5, 5);
            positionHero = new Vector2(70, 70);
            animation = new Animation.Animation();
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 32, 34)));
            animation.AddFrame(new AnimationFrame(new Rectangle(32, 0, 32, 34)));
            animation.AddFrame(new AnimationFrame(new Rectangle(64, 0, 32, 34)));
            animation.AddFrame(new AnimationFrame(new Rectangle(96, 0, 32, 34)));
            animation2 = new Animation.Animation();
            animation2.AddFrame(new AnimationFrame(new Rectangle(0, 34, 32, 34)));
            animation2.AddFrame(new AnimationFrame(new Rectangle(32, 34, 32, 34)));
            animation2.AddFrame(new AnimationFrame(new Rectangle(64, 34, 32, 34)));
            animation2.AddFrame(new AnimationFrame(new Rectangle(96, 34, 32, 34)));
            hitBox = new Rectangle((int)positionHero.X, (int)positionHero.Y, 10 * 5, 10 * 5);
        }

        public void Update(GameTime gameTime)
        {
            counterPinky++;
            Vector2 direction = InputReader.ReadInput();
            direction = MovementManager.Move(this, direction);
            var afstand = direction * speed;
            var toekomstPositie = positionHero + afstand;
            Rectangle toekomstRectangle = new Rectangle((int)toekomstPositie.X, (int)toekomstPositie.Y, 10 * 5, 10 * 5);
            bool hasCollided = MovementManager.HasCollided(this, toekomstRectangle);
            if (!hasCollided)
            {
                positionHero = toekomstPositie;
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
            animation2.Update(gameTime);
            animation.Update(gameTime);
            hitBox = new Rectangle((int)positionHero.X, (int)positionHero.Y, 10 * 5, 10 * 5);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (immunity <= 0 && collidedWithTrap)
            {
                invisible = true;
            }
            if (invisible)
            {
                if (left)
                {
                    //ANIMATION TO LEFT
                    spriteBatch.Draw(heroTexture, hitBox, animation.CurrentFrame.SourceRectangle, Color.Red);
                }
                else
                {
                    spriteBatch.Draw(heroTexture, hitBox, animation.CurrentFrame.SourceRectangle, Color.Red);
                }
            }
            else
            {
                if (left)
                {
                    //ANIMATION TO LEFT
                    spriteBatch.Draw(heroTexture, hitBox, animation.CurrentFrame.SourceRectangle, Color.White);
                }
                else
                {
                    spriteBatch.Draw(heroTexture, hitBox, animation.CurrentFrame.SourceRectangle, Color.White);
                }
            }
        }
    }
}
