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
    /**handles Listener Related movements*/
    public class ListenerManager
    {
        protected KeyboardState laststate;
        protected KeyboardState currentstate;
        public KeyboardState keyState
        {
            get
            {
                return currentstate;
            }
        }

        public ListenerManager(){
            currentstate = Keyboard.GetState();
        }

        public void Update(Dude d, Sprite[] s, Level l){
            //Updates current and last states
            laststate = currentstate;
            currentstate = Keyboard.GetState();

            //left movement
            if (currentstate.IsKeyDown(Keys.Left) && !(Interaction.isColliding(l,d.web.points[0]) || Interaction.isColliding(l, d.web.points[5])))
            {
                //simple move for range > gamewidth/4 and endpoint
                if (!(d.web.area.X < Game1.gameWidth / 4 && l.theLevel[0, 0].rect.X < 0))
                {
                    //move dude left dSpeed
                    d.moveLeft(Dude.speed);
                }
                else//move for range < gamewidth/4
                {
                    //move level right dSpeed
                    foreach (Tile t in l.theLevel)
                    {
                        t.rect.X += Dude.speed;
                    }
                    //move non-dude sprites right dSpeed
                    foreach (Sprite sp in s)
                    {
                        Console.Out.WriteLine("in loop");
                        sp.moveRight(Dude.speed);
                    }
                }
            } 
            //right movement
            if (currentstate.IsKeyDown(Keys.Right) && !(Interaction.isColliding(l, d.web.points[1]) || Interaction.isColliding(l, d.web.points[2])))
            {
                //Simple move for range < gamewidth/2 and endpoint
                if (!(d.web.area.X > Game1.gameWidth / 2 && l.theLevel[l.theLevel.GetLength(0) - 1, l.theLevel.GetLength(1) - 1].rect.X > Game1.gameWidth - Level.tileSide))
                {
                    //move dude right dSpeed
                    d.moveRight(Dude.speed);
                }
                else //move for complex conditions
                {
                    //move level left dspeed
                    foreach (Tile t in l.theLevel)
                    {
                        t.rect.X -= Dude.speed;
                    }
                    //move non-dude sprites left dspeed
                    foreach (Sprite sp in s)
                    {
                        sp.moveLeft(Dude.speed);
                        
                    }
                }
            }
            //jump management
            if (currentstate.IsKeyDown(Keys.Space))
            {
                if (!(Interaction.isColliding(l, d.web.points[0]) || Interaction.isColliding(l, d.web.points[1])))
                {
                    d.Jump(12);//dude up 12
                }
            }
        }

    }
}
