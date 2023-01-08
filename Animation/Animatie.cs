using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Project_Game_Dev_2022.Animation
{
    public class Animation
    {
        public AnimationFrame CurrentFrame { get; set; }
        private List<AnimationFrame> frames;
        private int counter;
        private double secondCounter = 0;

        public Animation()
        {
            frames = new List<AnimationFrame>();
        }
        public void AddFrame(AnimationFrame animationFrame)
        {
            frames.Add(animationFrame);
            CurrentFrame = frames[0];
        }
        public void Update(GameTime gameTime)
        {
            CurrentFrame = frames[counter];
            secondCounter += gameTime.ElapsedGameTime.TotalSeconds;
            int fps = 15;
            if (secondCounter >= 1d / fps)
            {
                counter++;
                secondCounter = 0;
            }
            if (counter >= frames.Count)
            {
                counter = 0;
            }
        }
    }
}
