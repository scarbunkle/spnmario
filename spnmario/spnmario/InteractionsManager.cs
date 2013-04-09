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
    public class Interaction
    {
        public static Tile isColliding(Level l, Vector2 v){
            Point p = pointCast(v);
            foreach (Tile t in l.theLevel){
                    if (t.rect.Contains(p) && t.isSolid){
                     return t;
                    }   
            }
            return new Tile();
            
        }

        public static Point pointCast(Vector2 v)
        {
            return new Point((int)v.X, (int)v.Y);
        }

        
    }
}
