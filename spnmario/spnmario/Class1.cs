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
    public class Collision
    {
        public static bool isColliding(Level l, Vector2 v){
            Point p = new Point((int)v.X, (int)v.Y);
            foreach (Tile t in l.theLevel){
                    if (t.rect.Contains(p) && t.isSolid){
                     return true;
                    }   
            }
            return false;
            
        }

    }
}
