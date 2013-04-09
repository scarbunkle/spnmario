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
        public Checkpoint[] points;
        public Rectangle area;

        public CollisionWeb(Rectangle r)
        {
            area = r;
            points = new Checkpoint[6];
            for (int i = 0; i<points.Length; i++)
            {
                points[i]=new Checkpoint(0,0);
            }
            pointsUpdate(r);
        }



        public void pointsUpdate(Rectangle r)
        {
            if (r != null)
            {
                points[0].Update(r.X, r.Y);
                points[1].Update(r.X + r.Width, r.Y);
                points[2].Update(r.X + r.Width, r.Y + r.Height - 5);
                points[3].Update(r.X + r.Width - 5, r.Y + r.Height);
                points[4].Update(r.X + 5, r.Y + r.Height);
                points[5].Update(r.X, r.Y + r.Height - 5);
            }
        }
    }
}
