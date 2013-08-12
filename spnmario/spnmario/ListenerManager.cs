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
        protected static KeyboardState laststate;
        protected static KeyboardState currentstate;
        public static KeyboardState keyState
        {
            get
            {
                return currentstate;
            }
        }

        public ListenerManager(){
            currentstate = Keyboard.GetState();
        }

        public void Update(Dude d, Sprite[] s, Level l, GameTime gameTime){
            //Updates current and last states
            laststate = currentstate;
            currentstate = Keyboard.GetState();

            //left movement
            if (currentstate.IsKeyDown(d.control[0]) && !(Interaction.isColliding(l,d.web.points[0]) || Interaction.isColliding(l, d.web.points[5])))
            {
                d.animate(gameTime);
                    //move dude left dSpeed
                    d.moveLeft(Dude.speed);
               
            } 
            //right movement
            if (currentstate.IsKeyDown(d.control[1]) && !(Interaction.isColliding(l, d.web.points[1]) || Interaction.isColliding(l, d.web.points[2])))
            {
                d.animate(gameTime);
 
                    //move dude right dSpeed
                    d.moveRight(Dude.speed);
            }
            //jump management
            if (currentstate.IsKeyDown(d.control[2]))
            {
                if (!(Interaction.isColliding(l, d.web.points[6]) || Interaction.isColliding(l, d.web.points[7])))
                {
                    d.Jump(12);//dude up 12
                    d.animate(gameTime);
                }
            }
        }

    }
}
