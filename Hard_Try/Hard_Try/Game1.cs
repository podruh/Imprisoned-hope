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

namespace Imprisoned_Hope
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public int sirka = 1280;
        public int vyska = 720;
        public MouseState mys;
        public Display displayMenu, displayLevelBuilder,displayGameplay;

        public KeyboardState klavesy, klavesyMinule;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = sirka;
            graphics.PreferredBackBufferHeight = vyska;
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
            IsMouseVisible = false;
            //pøidávání komponent
            MenuComponent menu = new MenuComponent(this);
            BuilderComponent builder = new BuilderComponent(this);
            Gameplay gameplay = new Gameplay(this);
            //pøidání displejù
            displayMenu = new Display(this, menu);
            displayLevelBuilder = new Display(this, builder);
            displayGameplay = new Display(this, gameplay);
            //vypnutí komponent
            foreach (GameComponent item in Components)
            {
                PrepniKomponentu(item, false);
            }

            base.Initialize();
        }

        /// <summary>
        /// Zapne/vypne komponentu v dané herní obrazovce
        /// </summary>
        /// <param name="komponenta">Komponenta</param>
        /// <param name="zapnout">True pokud se má komponenta zapnout, false pokud se má vypnout</param>
        private void PrepniKomponentu(GameComponent komponenta, bool zapnout)
        {
            komponenta.Enabled = zapnout;
            if (komponenta is DrawableGameComponent)
                ((DrawableGameComponent)komponenta).Visible = zapnout;
        }

        /// <summary>
        /// Pøepne herní obrazovku
        /// </summary>
        /// <param name="obrazovka"></param>
        public void PrepniObrazovku(Display obrazovka)
        {
            GameComponent[] povolene = obrazovka.VratKomponenty();
            foreach (GameComponent komponenta in Components)
            {
                bool povolena = povolene.Contains(komponenta);
                PrepniKomponentu(komponenta, povolena);
            }            
        }
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //MediaPlayer.Play(music_menuTheme);
            PrepniObrazovku(displayMenu);
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

            klavesyMinule = klavesy;
            klavesy = Keyboard.GetState();


            base.Update(gameTime);
        }

        public bool NovaKlavesa(Keys klavesa)
        {
            return klavesy.IsKeyDown(klavesa) && klavesyMinule.IsKeyUp(klavesa);
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
           
            spriteBatch.End();

            base.Draw(gameTime);
        } 
    }
}
