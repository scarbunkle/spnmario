using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace spnmario
{
    public class SpIRIT: Sprite
    {
        private Checkpoint point;
        public Checkpoint triggerpoint
        {
            get
            {
                return point;
            }
        }
        private bool isActive;
        private int deltaX,
                    deltaY,
                    onScreenSpeed,
                    randomDelay;
        private double angle,
                       randomAngle;
        static Random extendedRanAngle = new Random();

        public SpIRIT(Texture2D a, Rectangle r, Checkpoint p)
        {
            AssetSheet = a;
            W = new CollisionWeb(r);
            point = p;
            isActive = false;
            onScreenSpeed = 7;
        }

        public void Activate()
        {
            isActive = true;
            Console.Out.WriteLine("Active");
        }

        /** Inactive Movement will be coded into the supermethod in the dude:sprite for now--An 
         * independent Listener class needs to exist to handle movements.*/
        public override void moveLeft(int i)
        {
            W.area.X -= i;
            point.x -= i;
            Console.Out.WriteLine(triggerpoint.x);
        }

        public override void moveRight(int i)
        {
            W.area.X += i;
            point.x += i;

            Console.Out.WriteLine(triggerpoint.x);
        }

        public override void Update(Dude d)
        {
            if (triggerpoint.x < d.web.area.X)
            {
                Activate();
            }
            if (isActive)
            {
                if (W.area.X < 0 - W.area.Width)
                {
                    W.area.X += 15;
                }
                else
                {        
                    deltaY = d.web.area.Y - W.area.Y;
                    deltaX = d.web.area.X - W.area.X;
                    angle = Math.Atan2(deltaY, deltaX);
                    ++randomDelay;
                    if (randomDelay > 40)
                    {
                        randomAngle = (extendedRanAngle.Next((int)((Math.PI / 2) * 1000)) / 1000.0 - (Math.PI / 4));
                        randomDelay = 0;
                    }
                    angle += randomAngle;
                    W.area.X += (int)(onScreenSpeed * (float)Math.Cos(angle));
                    W.area.Y += (int)(onScreenSpeed * (float)Math.Sin(angle));
                }
            }

            base.Update();
            
        }
        public override void Draw(SpriteBatch theSB)
        {
            if (isActive)
            {
                base.Draw(theSB);
            }
        }
    }

}
