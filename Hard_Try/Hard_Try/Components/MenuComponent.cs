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
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class MenuComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private Game1 Hra;
        
        SpriteBatch spriteBatch;

        #region popisy class
        private string mastermindNews;
        private string enforcerNews;
        private string beasttamerNews;
        private string phasewalkerNews;
        private string classNews;
        #endregion

        private Texture2D menuBackground, menuItem_Exit, menuItem_Loadgame, menuItem_Options, menuItem_Newgame,
            iconMouse, menuItem_Temporary, menuItem_Back, menuItem_musicon, menuItem_musicoff, hero, class_Phasewalker, classEnforcer, classMastermind, pozadiNG, iconTemp, iconBack64;
        private List<Texture2D> mainMenuTextury;
        private List<Texture2D> optMenuTextury;
        private List<Texture2D> newgameMenuTextury;
        Menu mainMenu, optMenu, newGameMenu;
        private float mainmenuSpeed,optmenuSpeed;
        private int menuX,menuY,ngmenuX, ngmenuY;
        public SpriteFont FontCourierNew, FontTimes;
        public Song music_menuTheme;
        public int sirka;
        public int vyska;
        public MouseState mys;
        public static MediaState music;

        Rectangle heroRect;

        public MenuComponent(Game1 game) : base(game)
        {
            // TODO: Construct any child components here
            this.Hra = game;

        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            #region stringy popisu class
            mastermindNews = "Druh mutace ovlivòující mozkovou èinnost se poprvé objevil v období 30. let" + Environment.NewLine + "21. století, pojmenovaném Nová Generace, jako modifikace ji veøejnì známého" + Environment.NewLine + "mutagenu, jeho obìti jsou nazıvány jako The Others. Jedinci ovlivnìni touto" + Environment.NewLine + "mutací byli nazıváni kódovım oznaèením Mastermind vzhledem k jejich" + Environment.NewLine + "schopnostem manipulovat s lidskou myslí. První pøípad vıskytu této mutace byl" + Environment.NewLine + "nalezen u eny jménem Eliza Green. Tato ena sídlící v New Hampshire se ji" + Environment.NewLine + "od útlého vìku ivila v cirkuse jako vìdma a byla tam tøikrát na hranici smrti" + Environment.NewLine + "z dùvodu útoku z publika." + Environment.NewLine + "  Po objevení této mutace byla pøedána do rukou vìdcù, kteøí nyní zkoumají její" + Environment.NewLine + "mutaci. Tímto chci uklidnit všechny ètenáøe, aby nepanikaøili z dùvodu domnìní," + Environment.NewLine + "e tato mutace je nakalivá. Jedná se pouze o pøetvoøení DNA majitele a tudí nelze" + Environment.NewLine + "pøenášet ani vzduchem ani krví.";
            enforcerNews = "Rubrika Staò se novináøem:" + Environment.NewLine + Environment.NewLine + "Scott:" + Environment.NewLine + "A u dost! U mám po krk tìchhle pokøivenıch kreatur. Mì nezajímá, co si myslí" + Environment.NewLine + "vìdci. Tohle u je fakt moc! Vèera jsem vidìl jednoho chlápka rozmetat zeï" + Environment.NewLine + "budovy na padr. Normálnì bez problému si pøišel a bouchl do zdi. To byste" + Environment.NewLine + "nevìøili, jaká spouš po nìm zùstala. A navíc ta budova je teï odepsaná k demolici." + Environment.NewLine + "No co si o tom máme myslet? Já vám to øeknu! Kdy se nemùeme spolehnout" + Environment.NewLine + " na policii tak si musíme zøídit poøádek sami. Musíme se vydat do ulic a skoncovat" + Environment.NewLine + " to s nimi. Vyzıvám obyvatele Washingtonu, aby pozítøí 13. øíjna vyšli se mnou" + Environment.NewLine + " do ulic a jednou pro vdy ukázali, jak to tady chodí!" + Environment.NewLine + Environment.NewLine + "Komentáøe:" + Environment.NewLine + "Freebird246:Autor èlánku asi omylem zapomnìl zmínit, e ten dotyènı chlápek" + Environment.NewLine + " znièil èást hoøící budovy, aby zachránil její obyvatele!" + Environment.NewLine + "13:58";
            beasttamerNews = "ŠOK! Zvíøata ovlivnìna neznámım muem zabila 19 lidí." + Environment.NewLine + Environment.NewLine + "Ve støedu odpoledne 23. srpna se rozlehla panika, v Central Parkské Zoo, rychle" + Environment.NewLine + "jako oheò. Podle svìdkù prı zvíøata ovlivnil jakısi neznámı mu v mladších letech" + Environment.NewLine + "a rozkázal jim roznášet krutı teror po ulicích New Yorku. Bìhem dvou minut chaosu" + Environment.NewLine + "byli ušlapáni ètyøi lidi a zbylıch patnáct lidí bylo krutì popraveno zvíøaty." + Environment.NewLine + "Podle zábìrù kamer se jatek zúèastnilo sedm druhù zvíøat. Zoologové si nemohou" + Environment.NewLine + "tuto záhadu vysvìtlit jinak, ne e zvíøata byla ovlivnìna mutantem nového druhu." + Environment.NewLine + "  Varujeme ètenáøem pøed nebezpeèím útoku. Zùstaòte radši doma a nevzdalujte" + Environment.NewLine + "se z mìsta bez øádného dozoru lovcù. Kdybyste nìkde vidìli vıše zmínìného mue," + Environment.NewLine + "kterého policie popsala jako èernovlasého vousatého ètyøicátníka, ihned kontaktujte" + Environment.NewLine + "policii.";
            phasewalkerNews = "Oznaèení Phase Walker jste mohli slyšet poslední dobou docela èasto a ne vdy" + Environment.NewLine + "jako pozitivní oznaèení. Zdá se, e lidstvo vstoupilo do nové generace lidí, protoe" + Environment.NewLine + "nové mutace ji existujícího genu The Others se objevují jak na bìícím páse." + Environment.NewLine + "Sice jde o zcela ojedinìlé pøípady, ale zprávy a dohady o znovuzrození lidstva" + Environment.NewLine + "u nemùeme ignorovat dlouho." + Environment.NewLine + "  Abychom nezacházely a pøíliš daleko od tématu, øekneme si nìco o nové mutaci" + Environment.NewLine + "lidí nazıvanıch Phase Walkers. Tento název vznikl z jejich schopnosti vstupovat" + Environment.NewLine + "do jiné reality, nebo jinak øeèeno do jiného rozhrání naší reality. Podle tvrzení rodièù" + Environment.NewLine + "dvanáctiletého chlapce Ethana Mosse, kterım se Ethan svìøil o jeho schopnosti," + Environment.NewLine + "mùe chlapec urèitım zpùsobem stále zasahovat do naší reality, ale kromì zraku" + Environment.NewLine + "nemùe naší realitu smyslovì vnímat.";
            #endregion
            classNews = null;

            #region textury
            mainMenuTextury = new List<Texture2D>();
            optMenuTextury = new List<Texture2D>();
            newgameMenuTextury = new List<Texture2D>();
            #endregion
            sirka = 1280;
            vyska = 720;
            mainmenuSpeed = 3f;
            optmenuSpeed = 1.5f;
            menuX = 760;
            menuY = 450;
            ngmenuX = 15;   
            ngmenuY = 140;   
            Hra.Content.RootDirectory = "Content";
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            menuBackground = Hra.Content.Load<Texture2D>(@"Textury\Menu\back_menu");

            hero = Hra.Content.Load<Texture2D>(@"Textury\Hero");
            heroRect = new Rectangle(sirka / 2 - hero.Width / 2, 70, hero.Width, hero.Height);
            iconMouse = Hra.Content.Load<Texture2D>(@"Textury\iconMouse");

            music_menuTheme = Hra.Content.Load<Song>(@"Music\music_menuTheme");

            FontCourierNew = Hra.Content.Load<SpriteFont>(@"Fonty\courier_new");
            FontTimes = Hra.Content.Load<SpriteFont>(@"Fonty\times");

            #region Naèítání textur patøících do listù

            mainMenuTextury.Add(menuItem_Newgame = Hra.Content.Load<Texture2D>(@"Textury\Menu\New Game"));
            mainMenuTextury.Add(menuItem_Loadgame = Hra.Content.Load<Texture2D>(@"Textury\Menu\Load Game"));
            mainMenuTextury.Add(menuItem_Options = Hra.Content.Load<Texture2D>(@"Textury\Menu\Options"));
            mainMenuTextury.Add(menuItem_Exit = Hra.Content.Load<Texture2D>(@"Textury\Menu\Exit"));

            optMenuTextury.Add(menuItem_Temporary = Hra.Content.Load<Texture2D>(@"Textury\Menu\Temporary"));
            optMenuTextury.Add(menuItem_musicon = Hra.Content.Load<Texture2D>(@"Textury\Menu\musicon"));
            optMenuTextury.Add(menuItem_musicoff = Hra.Content.Load<Texture2D>(@"Textury\Menu\musicoff"));
            optMenuTextury.Add(menuItem_Back = Hra.Content.Load<Texture2D>(@"Textury\Menu\Back"));

            pozadiNG = Hra.Content.Load<Texture2D>(@"Textury\pozadiNG");
            newgameMenuTextury.Add(classMastermind = Hra.Content.Load<Texture2D>(@"Textury\mastermind_class"));
            newgameMenuTextury.Add(classEnforcer = Hra.Content.Load<Texture2D>(@"Textury\enforcer_class"));
            newgameMenuTextury.Add(iconTemp = Hra.Content.Load<Texture2D>(@"Textury\temp"));
            newgameMenuTextury.Add(class_Phasewalker = Hra.Content.Load<Texture2D>(@"Textury\phasewalker_class"));
            newgameMenuTextury.Add(iconBack64 = Hra.Content.Load<Texture2D>(@"Textury\Menu\back64"));

            #endregion

            #region naplòování menu listama textur a urèování startovní pozice

            mainMenu = new Menu(mainMenuTextury, new Rectangle(menuX, menuY, 0, 0), mainmenuSpeed, menuX, menuY);
            optMenu = new Menu(optMenuTextury, new Rectangle(menuX, vyska + 1, 0, 0), optmenuSpeed, menuX, menuY);
            newGameMenu = new Menu(pozadiNG, newgameMenuTextury, new Rectangle(0 - pozadiNG.Width, ngmenuY, pozadiNG.Width, pozadiNG.Height), mainmenuSpeed, 0 - pozadiNG.Width, ngmenuY, 45, 50, 60);
            #endregion

            MediaPlayer.Play(music_menuTheme);
            MediaPlayer.IsRepeating = true;
            music = MediaState.Playing;
            MediaPlayer.Stop();
            base.LoadContent();
        }
        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            //naète myš
            mys = Mouse.GetState();

            if(optMenu.MenuItems[0].isClicked(mys))
            {
                
            }

            if (mainMenu.MenuItems[3].isClicked(mys))
            {
                Hra.Exit();
            }

            if (mainMenu.MenuItems[0].isClicked(mys))
            {
                newGameMenu.DockX = ngmenuX;
                newGameMenu.changeMovement("right");
                mainMenu.DockX = sirka;
                mainMenu.changeMovement("right");
            }
            if (mainMenu.MenuItems[1].isClicked(mys))
            {
                Gameplay GP = (Gameplay)Hra.displayGameplay.VratKomponenty()[0];
                GP.LoadGame();
                Hra.displayGameplay = new Display(Hra, GP);
                Hra.PrepniObrazovku(Hra.displayGameplay);
            }
            if (mainMenu.MenuItems[2].isClicked(mys))
            {
                optMenu.DockY = menuY;//zmìní koneènou pozici pohybu na dockovací souøadnici
                optMenu.changeMovement("up");//changeMovement zkontroluje jestli mùe menu do smìru "left"
                mainMenu.DockX = sirka;
                mainMenu.changeMovement("right");
            }
            if (optMenu.MenuItems[3].isClicked(mys))
            {
                mainMenu.DockX = menuX;
                mainMenu.changeMovement("left");
                optMenu.DockY = vyska;
                optMenu.changeMovement("down");
            }
            if (newGameMenu.MenuItems[0].isClicked(mys))
            { classNews = "Mastermind"; NameForm(classNews); }
            if (newGameMenu.MenuItems[1].isClicked(mys))
            {classNews = "Enforcer"; NameForm(classNews);}
            if (newGameMenu.MenuItems[2].isClicked(mys))
            { classNews = "Beasttamer"; NameForm(classNews); }
            if (newGameMenu.MenuItems[3].isClicked(mys))
            { classNews = "Phasewalker"; NameForm(classNews); }
            if (newGameMenu.MenuItems[4].isClicked(mys))
            {
                newGameMenu.DockX = 0 - pozadiNG.Width;
                newGameMenu.changeMovement("left");
                mainMenu.DockX = menuX;
                mainMenu.changeMovement("left");
                classNews = null;
            }
            if(optMenu.MenuItems[1].isClicked(mys) && music == MediaState.Stopped)
            {
                 MediaPlayer.Play(music_menuTheme);
                 music = MediaState.Playing;
            }
            if (optMenu.MenuItems[2].isClicked(mys))
            {
                    MediaPlayer.Stop();
                    music = MediaState.Stopped;
            }
            if (heroRect.Contains(mys.X, mys.Y) && mys.LeftButton == ButtonState.Pressed)
            {
                Hra.PrepniObrazovku(Hra.displayLevelBuilder);                
            }
            optMenu.moveMenu(gameTime);
            mainMenu.moveMenu(gameTime);
            newGameMenu.moveMenu(gameTime);
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(menuBackground, new Rectangle(0, 0, menuBackground.Width, menuBackground.Height), Color.White);

            spriteBatch.Draw(hero,heroRect, Color.White);
            mainMenu.DrawMenu(spriteBatch);
            optMenu.DrawMenu(spriteBatch);
            newGameMenu.DrawMenu(spriteBatch);

            spriteBatch.DrawString(FontCourierNew, "Verze alpha 0.0043" + "  " + music, new Vector2(0, 0), Color.White);
            switch (classNews)
            {
                case "Mastermind":
                    spriteBatch.DrawString(FontTimes, mastermindNews, new Vector2(28, 275), Color.Black);
                    break;
                case "Enforcer":
                    spriteBatch.DrawString(FontTimes, enforcerNews, new Vector2(28, 275), Color.Black);
                    break;
                case "Beasttamer":
                    spriteBatch.DrawString(FontTimes, beasttamerNews, new Vector2(28, 275), Color.Black);
                    break;
                case "Phasewalker":
                    spriteBatch.DrawString(FontTimes, phasewalkerNews, new Vector2(28, 275), Color.Black);
                    break;
                default:
                    break;
            }

            spriteBatch.Draw(iconMouse, new Rectangle(mys.X - 15, mys.Y - 10, iconMouse.Width, iconMouse.Height), Color.White); //Vykreslení myši (musí bıt poslední)
            spriteBatch.End();
            base.Draw(gameTime);
        }
        public void NewGame(string name, string trida)
        {
            
            Gameplay GP = (Gameplay)Hra.displayGameplay.VratKomponenty()[0];
            GP.NovaHra(name,trida);
            Hra.displayGameplay = new Display(Hra, GP);
            newGameMenu.DockX = 0 - pozadiNG.Width;
            newGameMenu.changeMovement("left");
            mainMenu.DockX = menuX;
            mainMenu.changeMovement("left");
            classNews = null;
            Hra.PrepniObrazovku(Hra.displayGameplay);
        }
        public void NameForm(string trida)
        {
            NewGameForm NGF = new NewGameForm(this, trida);
            NGF.Show();
        }
    }
}
