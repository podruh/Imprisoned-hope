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

        private Texture2D menuBackground, menuExit, menuLoadgame, menuOptions,menuNewgame,iconMouse, menuTemporary, menuBack;
        private List<Texture2D> mainMenuTextury = new List<Texture2D>(); 
        private List<Texture2D> optMenuTextury = new List<Texture2D>();
        private List<Sprite> mainMenuItems = new List<Sprite>(); 
        private List<Sprite> optMenuItems = new List<Sprite>();
        public SpriteFont FontCourierNew;
        public Song music_menuTheme;
        private int sirka = 1280;
        private int vyska = 720;
        public MouseState mys;
        private bool dopravaPohyb, dolevaPohyb, doluPohyb, nahoruPohyb;
        float menuSpeed = 1.5f;
        int menuOdsazeni = 450;

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
            menuBackground = Content.Load<Texture2D>("back_menu");
            #region Naèítání textur patøících do listù

            mainMenuTextury.Add(menuNewgame = Content.Load<Texture2D>("New Game"));
            mainMenuTextury.Add(menuLoadgame = Content.Load<Texture2D>("Load Game"));
            mainMenuTextury.Add(menuOptions = Content.Load<Texture2D>("Options"));
            mainMenuTextury.Add(menuExit = Content.Load<Texture2D>("Exit"));
            optMenuTextury.Add(menuTemporary = Content.Load<Texture2D>("Temporary"));
            optMenuTextury.Add(menuBack = Content.Load<Texture2D>("Back"));

            #endregion

            iconMouse = Content.Load<Texture2D>("iconMouse");

            music_menuTheme = Content.Load<Song>(@"Music\music_menuTheme");

            FontCourierNew = Content.Load<SpriteFont>(@"Fonty\courier_new");

            #region øazení textur menu do ItemListù
            int yMain = menuOdsazeni, yOpt = vyska + 1; //základní vertikální pozice menu
            for (int i = 0; i < mainMenuTextury.Count; i++)// Naètení obsahu hlavního jmenu do listu hlavního jmenu. y = oddìlení položek vertikálnì.
            {
                mainMenuItems.Add(new Sprite(mainMenuTextury[i], new Rectangle(sirka - mainMenuTextury[i].Width - 20, yMain, mainMenuTextury[i].Width, mainMenuTextury[i].Height), Color.White));
                yMain += 60;
            }
            for (int i = 0; i < optMenuTextury.Count; i++)
            {
                optMenuItems.Add(new Sprite(optMenuTextury[i], new Rectangle(sirka - optMenuTextury[i].Width - 20, yOpt, optMenuTextury[i].Width, optMenuTextury[i].Height), Color.White));
                yOpt += 60;
            }
            #endregion

            MediaPlayer.Play(music_menuTheme);
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

            //naète myš
            mys = Mouse.GetState();
            PohybMenu(gameTime);
            if (mainMenuItems[3].Rectangle.Contains(new Point(mys.X, mys.Y)) && mys.LeftButton == ButtonState.Pressed)
            {
                this.Exit();
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
            spriteBatch.Draw(menuBackground, new Rectangle(0, 0, menuBackground.Width, menuBackground.Height), Color.White);
            
            
            foreach (Sprite s in mainMenuItems)
            {
                s.Draw(graphics, spriteBatch);
            }
            foreach (Sprite s in optMenuItems)
            {
                s.Draw(graphics, spriteBatch);
            }
            spriteBatch.DrawString(FontCourierNew, "Verze alpha 0.0021", new Vector2(0, 0), Color.White);
            
            
            spriteBatch.Draw(iconMouse, new Rectangle(mys.X-15, mys.Y-10, iconMouse.Width, iconMouse.Height), Color.White); //Vykreslení myši (musí být poslední)
            spriteBatch.End();

            base.Draw(gameTime);
        }
        private void PohybMenu(GameTime gameTime)
        {
            

            if (mainMenuItems[2].Rectangle.Contains(mys.X,mys.Y) && mys.LeftButton == ButtonState.Pressed)//pohyb hlavního menu a vynoøení optMenu se zapne po stisknutí na options
            {
                dopravaPohyb = true;
                nahoruPohyb = true;
            }
            if (mainMenuItems[1].Position.X > sirka)//pohyb mainMenu se po dosažení šíøky zastaví
            {
                dopravaPohyb = false;
            }
            if (optMenuItems[0].Position.Y <= menuOdsazeni)//zastavení pohybu optMenu nahoru
            {
                nahoruPohyb = false;
            }

            if (optMenuItems[1].Rectangle.Contains(mys.X, mys.Y) && mys.LeftButton == ButtonState.Pressed)//pohyb options menu zpet dolu
            {
                doluPohyb = true;
                dolevaPohyb = true;
            }
            if (optMenuItems[0].Position.Y > vyska)//zastaveni pohybu
            {
                doluPohyb = false;
            }

            if (mainMenuItems[1].Position.X < sirka - mainMenuItems[1].Rectangle.Width - 20)
            {
                dolevaPohyb = false;
            }

            //pohyb
            if (dopravaPohyb)
            {
                double elapsed = gameTime.ElapsedGameTime.TotalMilliseconds;
                foreach (Sprite s in mainMenuItems)
                {
                    s.Position.X += (float)(menuSpeed * elapsed);
                    s.Rectangle.X = (int)s.Position.X;
                }

            }
            if (dolevaPohyb)
            {
                double elapsed = gameTime.ElapsedGameTime.TotalMilliseconds;
                foreach (Sprite s in mainMenuItems)
                {
                    s.Position.X -= (float)(menuSpeed * elapsed);
                    s.Rectangle.X = (int)s.Position.X;
                }

            }
            if (nahoruPohyb)
            {
                double elapsed = gameTime.ElapsedGameTime.TotalMilliseconds;
                foreach (Sprite s in optMenuItems) //posunutí options menu nahoru
                {
                    s.Position.Y -= (float)(menuSpeed * elapsed);
                    s.Rectangle.Y = (int)s.Position.Y;
                } 
            }
            if (doluPohyb)
            {
                double elapsed = gameTime.ElapsedGameTime.TotalMilliseconds;
                foreach (Sprite s in optMenuItems)
                {
                    s.Position.Y += (float)(menuSpeed * elapsed);
                    s.Rectangle.Y = (int)s.Position.Y;
                } 
            }
        }
    }
}
