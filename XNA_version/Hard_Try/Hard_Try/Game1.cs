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

namespace Hard_Try
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D background, exit, loadGame, options,newGame;
        List<Texture2D> menuTextury = new List<Texture2D>();        
        List<Sprite> MenuItems = new List<Sprite>();

        float menuSpeed = 0.15f;       

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 796;
            graphics.PreferredBackBufferHeight = 562;
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
            background = Content.Load<Texture2D>("back");
            exit = Content.Load<Texture2D>("Exit");
            loadGame = Content.Load<Texture2D>("Load Game");
            newGame = Content.Load<Texture2D>("New Game");
            options = Content.Load<Texture2D>("Options");
           

            menuTextury.Add(newGame);
            menuTextury.Add(loadGame);
            menuTextury.Add(options);
            menuTextury.Add(exit);


            int y = 20;
            for (int i = 0; i < menuTextury.Count;i++ )
            {
                MenuItems.Add(new Sprite(menuTextury[i], new Rectangle(GraphicsDeviceManager.DefaultBackBufferWidth - menuTextury[i].Width - 20, y, menuTextury[i].Width, menuTextury[i].Height), Color.White));
                y = y + 60;
            }
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            //pohyb menu
            double elapsed = gameTime.ElapsedGameTime.TotalMilliseconds;
            foreach (Sprite s in MenuItems)
            {
                s.Position.X += (float)(menuSpeed * elapsed * Math.Cos(MathHelper.Pi));
                s.Rectangle.X = (int)s.Position.X;
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
            spriteBatch.Draw(background, new Rectangle(0, 0, background.Width, background.Height), Color.White);
            
            foreach (Sprite s in MenuItems)
            {
                s.Draw(graphics, spriteBatch);
            }
                              
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
