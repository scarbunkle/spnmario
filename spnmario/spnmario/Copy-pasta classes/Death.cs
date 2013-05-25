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


namespace BaitAndSwitch
{
    class Death
        :Drawables
    {
        static Random extendedRanAngle = new Random();

        float       speedOfDeath,
                    angle,
                    degreeAngle,
                    randomAngle;

        double      deltaY,
                    deltaX;

        int secUntilNextSprite,
            currentSprite,
            numberOfSprites,
            animationSpeed,
            randomDelay,
            extendedRange;

        Rectangle mDeathRect;
        Rectangle[] mDeathslides = {    new Rectangle(0,0,128,128), 
                                        new Rectangle(128,0,128,128), 
                                        new Rectangle(0,128,128,128), 
                                        new Rectangle(128,128,128,128)};

        public Death(Vector2 pPos, Texture2D pTexture, Rectangle pRect)
            : base(pPos, pTexture, pRect)
        {
            mDeathRect = pRect;
            mPos = pPos;
            mTexture = pTexture;
            speedOfDeath = 3.0f;

            numberOfSprites = 2;
            animationSpeed = 500;
        }

        public Vector2 DeathMove( Vector2 playerPos)
        {
            //changes the position of death based on the player
            deltaY = playerPos.Y - mPos.Y;
            deltaX = playerPos.X - mPos.X;
            angle = (float)Math.Atan2(deltaY, deltaX);

            ++randomDelay;

            if (randomDelay > 100)
            {
                extendedRange = (int)((Math.PI / 2) * 1000);
                randomAngle = (float)(extendedRanAngle.Next(extendedRange) / 1000.0 - (Math.PI / 4));
                randomDelay = 0;
            }

            angle += randomAngle;

            mPos.X += speedOfDeath * (float)Math.Cos(angle);
            mPos.Y += speedOfDeath * (float)Math.Sin(angle);

            return mPos;
        }
        public override Rectangle BoundingRectangles()
        {
            boundingBox = new Rectangle((int)mPos.X, (int)mPos.Y, mRect.Width, mRect.Height);

            return boundingBox;
        }

        public virtual void Update(GameTime gameTime)
        {
            secUntilNextSprite -= gameTime.ElapsedGameTime.Milliseconds;
            if (secUntilNextSprite <= 0)
            {
                ++currentSprite;
                secUntilNextSprite = animationSpeed;
            }
            if (currentSprite >= numberOfSprites)
            {
                currentSprite = 0;
            }

            mDeathRect = mDeathslides[currentSprite];
        }

        public override void Draw(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.Draw(  mTexture,
                                mPos,
                                mDeathRect,
                                Color.White);
        }

        public float getAngle()
        {
            degreeAngle = (angle * 180) / (float)Math.PI; //***calculating an angle in Degrees***
            return degreeAngle;
        }
    }
}
