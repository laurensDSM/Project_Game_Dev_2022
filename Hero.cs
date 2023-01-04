using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project_Game_Dev_2022.Animation;
using Project_Game_Dev_2022.enemy_s;
using Project_Game_Dev_2022.Input;
using Project_Game_Dev_2022.interfaces;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_Dev_2022
{


    public class Hero : IGameObject
    {
        private Vector2 snelheid;
        private Vector2 positieHero;
        Rectangle hitBox;
        Texture2D heroTexture;
        internal bool canJump;
        internal bool isFalling;
        internal int counter;

        public IInputReader InputReader { get; set; }
        public MovementManager MovementManager { get; set; }
        public List<Enemy> Enemies;
        public List<EnemyTrap> Traps;



        public Hero(Texture2D blokTexture, IInputReader inputReader, MovementManager mm, List<Enemy> enemy, List<EnemyTrap> traps)
        {
            canJump = true;
            isFalling = true;
            heroTexture = blokTexture;
            MovementManager = mm;
            counter = 0;
            InputReader = inputReader;
            snelheid = new Vector2(5, 5);
            positieHero = new Vector2(5, 5);
            hitBox = new Rectangle((int)positieHero.X, (int)positieHero.Y, 10 * 5, 10 * 5);
            Enemies = enemy;
            Traps = traps;

        }

        public void Update()
        {
            Vector2 direction = InputReader.ReadInput();

            direction = MovementManager.Move(this, direction);


            var afstand = direction * snelheid;
            var toekomstPositie = positieHero + afstand;
            Rectangle toekomstRectangle = new Rectangle((int)toekomstPositie.X, (int)toekomstPositie.Y, 10 * 5, 10 * 5);

            bool hasCollided = MovementManager.HasCollided(this, toekomstRectangle);
            bool hasCollidedWithTrap = MovementManager.HasCollidedWithTrap(this, toekomstRectangle);
            bool hasCollidedWithEnemie= MovementManager.HasCollidedWithEnemie(this, toekomstRectangle);
            if (!hasCollided)
            {
                positieHero = toekomstPositie;

            }

            


            hitBox = new Rectangle((int)positieHero.X, (int)positieHero.Y, 10 * 5, 10 * 5);

        }



        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, hitBox, Color.Red);

        }
    }

}
