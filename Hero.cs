using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project_Game_Dev_2022.Animation;
using Project_Game_Dev_2022.Input;
using Project_Game_Dev_2022.interfaces;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_Dev_2022
{


    public class Hero // IGameObject
    {
        private Vector2 snelheid;
        private Vector2 positieHero;
        //private Vector2 toekomstigePositieHero;
        Rectangle hitBox;
        Texture2D heroTexture;
        public IInputReader InputReader { get; set; }




        public Hero(Texture2D blokTexture, IInputReader inputReader)
        {
            heroTexture = blokTexture;

            snelheid = new Vector2(5,5);
            positieHero = new Vector2(5, 5);
            hitBox = new Rectangle((int)positieHero.X, (int)positieHero.Y, 10 * 5, 10 * 5);


        }

        public void Update()
        {
            //var direction = InputReader.ReadInput();



            //direction *= snelheid;
            positieHero = snelheid; 





            //movementmanager(direction);
            //collision

            positieHero += snelheid;
            hitBox = new Rectangle((int)positieHero.X, (int)positieHero.Y, 10 * 5, 10 * 5);
            
        }

        private void movementmanager(  )
        {


        }




        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture,hitBox,Color.Green );

        }
    }

}
