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
        public Vector2[] points;
        public Rectangle area;

        public CollisionWeb(Rectangle r)
        {
            area = r;
            points = new Vector2[6];
            pointsUpdate(r);
        }

        /*This doesn't work.  I need to make a class that stores this data 
         * & can retrieve it as a Point or Vector2.*/
        public static void vectorUpdate(float x, float y, Vector2 v)
        {
            v.X = x;
            v.Y = y;
        }

        public void pointsUpdate(Rectangle r)
        {
            vectorUpdate(r.X, r.Y, points[0]);
            vectorUpdate(r.X + r.Width, r.Y, points[1]);
            vectorUpdate(r.X + r.Width, r.Y + r.Height - 5, points[2]);
            vectorUpdate(r.X + r.Width - 5, r.Y + r.Height, points[3]);
            vectorUpdate(r.X + 5, r.Y + r.Height, points[4]);
            vectorUpdate(r.X, r.Y + r.Height - 5, points[5]);
        }
    }
}
