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
    /*The class that handles location data and collision
     * detection points for the character sprite*/
    public class CollisionWeb
    {
        //public variable that can get points.
        public Checkpoint[] points
        {
            get
            {
                return p;
            }
        }
        //keeps actual points, protected
        protected Checkpoint[] p;
        //location of dude
        public Rectangle area;

        //constructor
        public CollisionWeb(Rectangle r)
        {
            area = r;
            p = new Checkpoint[6];
            for (int i = 0; i<points.Length; i++)
            {
                p[i]=new Checkpoint(0,0);
            }
            pointsUpdate();
        }


        //updates points
        public void pointsUpdate()
        {
            if (area != null)
            {
                p[0].Update(area.X, area.Y);
                p[1].Update(area.X + area.Width, area.Y);
                p[2].Update(area.X + area.Width, area.Y + area.Height - 5);
                p[3].Update(area.X + area.Width - 5, area.Y + area.Height);
                p[4].Update(area.X + 5, area.Y + area.Height);
                p[5].Update(area.X, area.Y + area.Height - 5);
            }
        }
    }
}
