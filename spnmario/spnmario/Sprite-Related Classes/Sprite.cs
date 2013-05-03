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
    public class Sprite
    {
        protected Texture2D AssetSheet;
        public CollisionWeb web //reads W
        {
            get
            {
                return W;
            }
        }
        protected Rectangle[] sourceRectangles; //Array of Rectangles to draw from.
        protected int activesource; //index of active source Rectangle.
        protected int frames; //frames per r/walk cycle
        protected int poses; //individual drawings -- frames plus jump animations, etc
        protected int animationSpeed;
        protected int secUntilNext;

        protected CollisionWeb W;//contains Draw rectangle and collision points

        public Sprite(Texture2D a, Rectangle r, int i)
        {
            AssetSheet = a;
            W = new CollisionWeb(r);
            poses = i;
            sourceRectangles = new Rectangle[i];
            for (int j =0; j<i; j++)
            {
                sourceRectangles[j] = new Rectangle(j, 0, r.Width, r.Height);
            }
            activesource = 0;
        }

        public Sprite()
        {
        }

        public virtual void Update(GameTime gameTime)
        {
            //Animation Fn
            secUntilNext -= gameTime.ElapsedGameTime.Milliseconds;
            if (secUntilNext <= 0)
            {
                ++activesource;
                secUntilNext = animationSpeed;
            }
            if (activesource >= frames)
            {
                activesource = 0;
            }
            //PointsUpdate
            W.pointsUpdate();
        }

        public virtual void Update(Dude d, GameTime gameTime)
        {
            Update(gameTime);
        }

        public virtual void Draw(SpriteBatch theSB, Rectangle source){
            theSB.Draw(AssetSheet, web.area, source, Color.White);
        }

        public virtual void Draw(SpriteBatch theSB){
            theSB.Draw(AssetSheet, web.area, Color.White);
        }

        public virtual void moveLeft(int i)
        {
            W.area.X -= i;
            Console.Out.WriteLine("Using Sprite");
        }

        public virtual void moveRight(int i)
        {
            W.area.X += i;
            Console.Out.WriteLine("Using Sprite");
        }
    }
}
