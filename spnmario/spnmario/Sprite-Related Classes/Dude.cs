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
    /*Dude's our character sprite.  It'll eventually get a bunch of
     * fun logic, handling animation, as well as who you're playing 
     * as.  It also handles some mechanics of collision logic, but 
     * some get passed off to InteractionsManager and CollisionWeb.*/
    public class Dude : Sprite
    {
        
        //This enum's for ater use--allows only one asset sheet overall.
        public enum PlayingAs
        {
            Sam,
            Dean,
            Cas,
            Bobby,
        }
        //variables for collision logic
        protected bool onGround;
        protected int airTime;//time in air
        //Speed of travel
        protected static int dSpeed = 5;
        public static int speed
        {
            get
            {
                return dSpeed;
            }
        }
        
        //constructor
        public Dude(Texture2D a, Rectangle r, int i):base(a, r, i)
        {
            onGround = false;
            frames = i;
            animationSpeed = 200;
        }

        //update loop
        public void Update(Level l, GameTime gameTime)
        {
            Console.Out.WriteLine(airTime);
            
            //Gravity: makes gravity happen
            if (!(onGround))
            {
                W.area.Y += (int)(.3* Math.Abs(airTime));
            }
            airTimeManagement(l, gameTime);
            W.pointsUpdate();
            
            
        }

        //draw
        public override void Draw(SpriteBatch theSB)
        {
            base.Draw(theSB, sourceRectangles[activesource]);
        }


        public void Jump(int i)
        {
            W.area.Y -= i;
        }

        //handles ground collisions, airtime, and landingfix
        public void airTimeManagement(Level l, GameTime gameTime)
        {
            
            
            if (onGround)
            {
                airTime = 0;
            }
            else if (Interaction.isColliding(l, W.points[4]) || Interaction.isColliding(l, W.points[3]))
            {
                    W.area.Y = Interaction.inTile(l, W.points[3]).rect.Y - W.area.Height;
            }

            onGround = Interaction.isColliding(l, W.points[3]) || Interaction.isColliding(l, W.points[4]);

            airTime++;
        }

        public void moveLeft(int i)
        {
            W.area.X -= i;
        }

        public void moveRight(int i)
        {
            W.area.X += i;
        }

        public void animate(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
