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
    public class CollisionWeb
    {
        public Checkpoint[] points
        {
            get
            {
                return p;
            }
        }
        protected Checkpoint[] p;
        public Rectangle area;

        public CollisionWeb(Rectangle r)
        {
            area = r;
            p = new Checkpoint[6];
            for (int i = 0; i<points.Length; i++)
            {
                p[i]=new Checkpoint(0,0);
            }
            pointsUpdate(r);
        }



        public void pointsUpdate(Rectangle r)
        {
            if (r != null)
            {
                p[0].Update(r.X, r.Y);
                p[1].Update(r.X + r.Width, r.Y);
                p[2].Update(r.X + r.Width, r.Y + r.Height - 5);
                p[3].Update(r.X + r.Width - 5, r.Y + r.Height);
                p[4].Update(r.X + 5, r.Y + r.Height);
                p[5].Update(r.X, r.Y + r.Height - 5);
            }
        }
    }
}
