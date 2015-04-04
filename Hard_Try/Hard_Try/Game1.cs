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

        #region stringy popisu class
        private string mastermindNews = "Druh mutace ovlivòující mozkovou èinnost se poprvé objevil v období 30. let" + Environment.NewLine + " 21. století, pojmenovaném Nová Generace, jako modifikace ji veøejnì známého" + Environment.NewLine + " mutagenu, jeho obìti jsou nazıvány jako The Others. Jedinci ovlivnìni touto" + Environment.NewLine + " mutací byli nazıváni kódovım oznaèením Mastermind vzhledem k jejich" + Environment.NewLine + " schopnostem manipulovat s lidskou myslí. První pøípad vıskytu této mutace byl" + Environment.NewLine + "nalezen u eny jménem Eliza Green. Tato ena sídlící v New Hampshire se ji" + Environment.NewLine + " od útlého vìku ivila v cirkuse jako vìdma a byla tam tøikrát na hranici smrti" + Environment.NewLine + " z dùvodu útoku z publika." + Environment.NewLine + "Po objevení této mutace byla pøedána do rukou vìdcù, kteøí nyní zkoumají její" + Environment.NewLine + " mutaci. Tímto chci uklidnit všechny ètenáøe, aby nepanikaøili z dùvodu domnìní," + Environment.NewLine + " e tato mutace je nakalivá. Jedná se pouze o pøetvoøení DNA majitele a tudí nelze" + Environment.NewLine + " pøenášet ani vzduchem ani krví.";
        private string enforcerNews = "Rubrika Staò se novináøem:" + Environment.NewLine + Environment.NewLine + "Scott:" + Environment.NewLine + "A u dost! U mám po krk tìchhle pokøivenıch kreatur. Mì nezajímá, co si myslí" + Environment.NewLine + "vìdci. Tohle u je fakt moc! Vèera jsem vidìl jednoho chlápka rozmetat zeï" + Environment.NewLine + "budovy na padr. Normálnì bez problému si pøišel a bouchl do zdi. To byste" + Environment.NewLine + "nevìøili, jaká spouš po nìm zùstala. A navíc ta budova je teï odepsaná k demolici." + Environment.NewLine + "No co si o tom máme myslet? Já vám to øeknu! Kdy se nemùeme spolehnout" + Environment.NewLine + " na policii tak si musíme zøídit poøádek sami. Musíme se vydat do ulic a skoncovat" + Environment.NewLine + " to s nimi. Vyzıvám obyvatele Washingtonu, aby pozítøí 13. øíjna vyšli se mnou" + Environment.NewLine + " do ulic a jednou pro vdy ukázali, jak to tady chodí!" + Environment.NewLine + Environment.NewLine + "Komentáøe:" + Environment.NewLine + "Freebird246:Autor èlánku asi omylem zapomnìl zmínit, e ten dotyènı chlápek" + Environment.NewLine + " znièil èást hoøící budovy, aby zachránil její obyvatele!" + Environment.NewLine + "13:58";
        #endregion
        private Texture2D menuBackground, menuItem_Exit, menuItem_Loadgame, menuItem_Options,menuItem_Newgame,
            iconMouse, menuItem_Temporary, menuItem_Back, hero, classEnforcer, classMastermind, pozadiNG, iconTemp;
        private List<Texture2D> mainMenuTextury = new List<Texture2D>(); 
        private List<Texture2D> optMenuTextury = new List<Texture2D>();
        private List<Texture2D> newgameMenuTextury = new List<Texture2D>();
        Menu mainMenu, optMenu, newGameMenu;
        private float menuSpeed = 1.5f;
        private int menuX = 760;
        private int menuY = 450;
        private int ngmenuX = 15, ngmenuY = 140;
        public SpriteFont FontCourierNew, FontTimes;
        public Song music_menuTheme;
        public int sirka = 1280;
        public int vyska = 720;
        public MouseState mys;

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
            menuBackground = Content.Load<Texture2D>(@"Textury\Menu\back_menu");

            hero = Content.Load<Texture2D>(@"Textury\Hero");

            iconMouse = Content.Load<Texture2D>(@"Textury\iconMouse");

            //music_menuTheme = Content.Load<Song>(@"Music\music_menuTheme");

            FontCourierNew = Content.Load<SpriteFont>(@"Fonty\courier_new");
            FontTimes = Content.Load<SpriteFont>(@"Fonty\times");

            #region Naèítání textur patøících do listù

            mainMenuTextury.Add(menuItem_Newgame = Content.Load<Texture2D>(@"Textury\Menu\New Game"));
            mainMenuTextury.Add(menuItem_Loadgame = Content.Load<Texture2D>(@"Textury\Menu\Load Game"));
            mainMenuTextury.Add(menuItem_Options = Content.Load<Texture2D>(@"Textury\Menu\Options"));
            mainMenuTextury.Add(menuItem_Exit = Content.Load<Texture2D>(@"Textury\Menu\Exit"));

            optMenuTextury.Add(menuItem_Temporary = Content.Load<Texture2D>(@"Textury\Menu\Temporary"));
            optMenuTextury.Add(menuItem_Back = Content.Load<Texture2D>(@"Textury\Menu\Back"));
           
            pozadiNG = Content.Load<Texture2D>(@"Textury\pozadiNG");
            newgameMenuTextury.Add(classMastermind = Content.Load<Texture2D>(@"Textury\mastermind_class"));
            newgameMenuTextury.Add(classEnforcer = Content.Load<Texture2D>(@"Textury\enforcer_class"));
            newgameMenuTextury.Add(iconTemp = Content.Load<Texture2D>(@"Textury\temp"));
            newgameMenuTextury.Add(iconTemp = Content.Load<Texture2D>(@"Textury\temp"));

            #endregion   
         
            #region naplòování menu listama textur a urèování startovní pozice

            mainMenu = new Menu(mainMenuTextury, new Rectangle(menuX, menuY, 0, 0), menuSpeed, menuX, menuY);
            optMenu = new Menu(optMenuTextury, new Rectangle(menuX, vyska + 1, 0, 0), menuSpeed, menuX, menuY);
            newGameMenu = new Menu(pozadiNG, newgameMenuTextury, new Rectangle(ngmenuX, ngmenuY, pozadiNG.Width, pozadiNG.Height), menuSpeed, ngmenuX, ngmenuY, 45, 50, 100);           
            #endregion

            //MediaPlayer.Play(music_menuTheme);
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

            //naète myš
            mys = Mouse.GetState();
            
            if (mainMenu.MenuItems[3].isClicked(mys))
            {
                this.Exit();
            }

            if (mainMenu.MenuItems[2].isClicked(mys))
            {
                optMenu.DockY = menuY;//zmìní koneènou pozici pohybu na dockovací souøadnici
                optMenu.changeMovement("up");//changeMovement zkontroluje jestli mùe menu do smìru "left"
                mainMenu.DockX = sirka;
                mainMenu.changeMovement("right");
            }
            if (optMenu.MenuItems[1].isClicked(mys))
            {
                mainMenu.DockX = menuX;
                mainMenu.changeMovement("left");
                optMenu.DockY = vyska;
                optMenu.changeMovement("down");
            }
            optMenu.moveMenu(gameTime);
            mainMenu.moveMenu(gameTime);
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

            spriteBatch.Draw(hero, new Rectangle(0,50,hero.Width, hero.Height), Color.White);
            #region NewGame menu (Work in progress)
            /*spriteBatch.Draw(pozadiNG, new Rectangle(ngmenuX, ngmenuY, pozadiNG.Width, pozadiNG.Height), Color.White);
            spriteBatch.Draw(classMastermind, new Rectangle(ngmenuX + 45, ngmenuY + 50, classMastermind.Width, classMastermind.Height), Color.White);
            spriteBatch.Draw(classEnforcer, new Rectangle(ngmenuX + 145, ngmenuY + 50, classEnforcer.Width, classEnforcer.Height), Color.White);
            spriteBatch.Draw(iconTemp, new Rectangle(ngmenuX + 245, ngmenuY + 50, iconTemp.Width, iconTemp.Height), Color.White);
            spriteBatch.Draw(iconTemp, new Rectangle(ngmenuX + 345, ngmenuY + 50, iconTemp.Width, iconTemp.Height), Color.White);
            spriteBatch.DrawString(FontTimes, mastermindNews, new Vector2((float)ngmenuX + 15,(float)ngmenuY + 125), Color.Black);
            spriteBatch.DrawString(FontTimes, enforcerNews, new Vector2((float)ngmenuX + 15, (float)ngmenuY + 125), Color.Black);*/
            #endregion

            //foreach (MenuItem s in mainMenu.MenuItems)
            //{
            //    s.Draw(graphics, spriteBatch);
            //}
            //foreach (MenuItem s in optMenu.MenuItems)
            //{
            //    s.Draw(graphics, spriteBatch);
            //}
            //nová metoda v Menu Draw
            mainMenu.DrawMenu(graphics, spriteBatch);
            optMenu.DrawMenu(graphics, spriteBatch);
            newGameMenu.DrawMenu(graphics, spriteBatch);

            spriteBatch.DrawString(FontCourierNew, "Verze alpha 0.0026" + mainMenu.MenuDirection, new Vector2(0, 0), Color.White);
            
            
            spriteBatch.Draw(iconMouse, new Rectangle(mys.X-15, mys.Y-10, iconMouse.Width, iconMouse.Height), Color.White); //Vykreslení myši (musí bıt poslední)
            spriteBatch.End();

            base.Draw(gameTime);
        }       
    }
}
