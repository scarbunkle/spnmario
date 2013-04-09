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
    public class Checkpoint
    {
        public int x;
        public int y;

        public Checkpoint(int xx, int yy)
        {
            x = xx;
            y = yy;
        }

        public void Update(int xx, int yy)
        {
            x = xx;
            y = yy;
        }

        public Vector2 getVector()
        {
            return new Vector2(x, y);
        }

        public Point getPoint()
        {
            return new Point(x, y);
        }
    }
}
