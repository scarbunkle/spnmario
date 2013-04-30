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

        protected CollisionWeb W;//contains Draw rectangle and collision points

        public Sprite(Texture2D a, Rectangle r)
        {
            AssetSheet = a;
            W = new CollisionWeb(r);
        }

        public Sprite()
        {
        }

        public virtual void Update()
        {
            W.pointsUpdate();
        }

        public virtual void Update(Dude d)
        {
            Update();
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
        }

        public virtual void moveRight(int i)
        {
            W.area.X += i;
            Console.Out.WriteLine("Using Sprite");
        }
    }
}
