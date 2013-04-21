using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace spnmario
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Dude is our Character.  
        Dude dude;
        //Level as a class lets us keep all the yucky for-loops of our Main.
        Level samplelevel;
        //This switches between screens/levels  BFD.
        enum Display
        {
            Title,
            Play,
            End,
        }
        Display showing; //stores our current Display
        Texture2D title; //Slide visible on open
        Texture2D win; //Last Slide

        //Used to play music
        SoundEffect sound; 
        SoundEffectInstance song;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            showing = Display.Title;
            title = Content.Load<Texture2D>("Title Slide");
            win = Content.Load<Texture2D>("winscreen");
            samplelevel = new Level(Content.Load<Texture2D>("tile"), sampleload());
            dude = new Dude(new Rectangle(200, 500, 53, 70), Content.Load<Texture2D>("char"));
            sound = Content.Load<SoundEffect>("track");
            song = sound.CreateInstance();
            song.IsLooped = true;
        }

        //used to reset at death
        public void LoadLevel()
        {
            samplelevel = new Level(Content.Load<Texture2D>("tile"), sampleload());
            dude = new Dude(new Rectangle(200, 500, 53, 70), Content.Load<Texture2D>("char"));
        }
        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            // TODO: Add your update logic here
            switch (showing){
                case Display.Play: //runs the game proper
                    song.Play();
                    samplelevel.Update();
                    dude.Update(samplelevel, gameTime);
                    if (dude.web.area.X > 1000) //allows death
                    {
                        showing = Display.End;
                    }
                    if (dude.web.area.Y > 720) //Allows victory
                    {
                        LoadLevel();
                    }
                 break;
                case Display.Title: //start screen
                    if (Keyboard.GetState().IsKeyDown(Keys.Space)){
                        showing = Display.Play;
                    }
                    Console.Out.WriteLine(CSVRead.readCSV(@"C:\Users\Sarah\Documents\GitHub\spnmariopreprealpha\spnmario\spnmarioContent\samplelevel.txt")[0, 0]);                   
                break;
                default: //does nothing, used for end
                break;
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            switch (showing)
            {
                case Display.Play:
                    samplelevel.Draw(spriteBatch);
                    dude.Draw(spriteBatch);
                    break;
                case Display.Title:
                    spriteBatch.Draw(title, new Vector2(0, 0), Color.White);
                    break;
                case Display.End:
                    spriteBatch.Draw(win, new Vector2(0, 0), Color.White);
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
        /* This just reads in the solid/non-solid status for every tile in the sample level.
         * It needs to be replaced by a file I/O class to convert an appropriately formatted
         * csv.*/
        public bool[,] sampleload()
        {
            return new bool[,]{{false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false},
{false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false},
{false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false},
{false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false},
{false,false,false,false,false,false,false,false,false,false,false,false,true,true,true,true,true,false,false,false,false,false,false,true,true,true,false,false,false,false,false,false,false,false,false},
{false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false},
{false,false,false,false,false,false,false,false,false,false,true,true,true,false,false,false,false,true,false,false,false,true,false,false,false,false,false,false,false,false,false,false,false,false,false},
{true,true,true,true,true,true,true,true,true,true,true,true,true,false,false,false,false,true,true,true,true,true,true,true,true,true,true,true,false,true,true,true,true,true,true},
{true,true,true,true,true,true,true,true,true,true,true,true,true,false,false,false,false,true,true,true,true,true,true,true,true,true,true,true,false,true,true,true,true,true,true}};
        }
    }
}
