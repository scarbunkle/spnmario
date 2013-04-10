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
        public static Tile inTile(Level l, Checkpoint c){
            foreach (Tile t in l.theLevel){
                    if (t.rect.Contains(c.getPoint())){
                     return t;
                    }   
            }
            return new Tile();
            
        }

        public static bool isColliding(Level l, Checkpoint c){
            foreach (Tile t in l.theLevel)
            {
                if (t.rect.Contains(c.getPoint()) && t.isSolid)
                {
                    return true;
                }
            }
            return false;
        }

        public static Point pointCast(Vector2 v)
        {
            return new Point((int)v.X, (int)v.Y);
        }

        
    }
}
