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
            mastermindNews = "Druh mutace ovliv�uj�c� mozkovou �innost se poprv� objevil v obdob� 30. let" + Environment.NewLine + "21. stolet�, pojmenovan�m Nov� Generace, jako modifikace ji� ve�ejn� zn�m�ho" + Environment.NewLine + "mutagenu, jeho� ob�ti jsou naz�v�ny jako The Others. Jedinci ovlivn�ni touto" + Environment.NewLine + "mutac� byli naz�v�ni k�dov�m ozna�en�m Mastermind vzhledem k jejich" + Environment.NewLine + "schopnostem manipulovat s lidskou mysl�. Prvn� p��pad v�skytu t�to mutace byl" + Environment.NewLine + "nalezen u �eny jm�nem Eliza Green. Tato �ena s�dl�c� v New Hampshire se ji�" + Environment.NewLine + "od �tl�ho v�ku �ivila v cirkuse jako v�dma a byla tam t�ikr�t na hranici smrti" + Environment.NewLine + "z d�vodu �toku z publika." + Environment.NewLine + "  Po objeven� t�to mutace byla p�ed�na do rukou v�dc�, kte�� nyn� zkoumaj� jej�" + Environment.NewLine + "mutaci. T�mto chci uklidnit v�echny �ten��e, aby nepanika�ili z d�vodu domn�n�," + Environment.NewLine + "�e tato mutace je naka�liv�. Jedn� se pouze o p�etvo�en� DNA majitele a tud� nelze" + Environment.NewLine + "p�en�et ani vzduchem ani krv�.";
            enforcerNews = "Rubrika Sta� se novin��em:" + Environment.NewLine + Environment.NewLine + "Scott:" + Environment.NewLine + "A u� dost! U� m�m po krk t�chhle pok�iven�ch kreatur. M� nezaj�m�, co si mysl�" + Environment.NewLine + "v�dci. Tohle u� je fakt moc! V�era jsem vid�l jednoho chl�pka rozmetat ze�" + Environment.NewLine + "budovy na padr�. Norm�ln� bez probl�mu si p�i�el a bouchl do zdi. To byste" + Environment.NewLine + "nev��ili, jak� spou�� po n�m z�stala. A nav�c ta budova je te� odepsan� k demolici." + Environment.NewLine + "No co si o tom m�me myslet? J� v�m to �eknu! Kdy� se nem��eme spolehnout" + Environment.NewLine + " na policii tak si mus�me z��dit po��dek sami. Mus�me se vydat do ulic a skoncovat" + Environment.NewLine + " to s nimi. Vyz�v�m obyvatele Washingtonu, aby poz�t�� 13. ��jna vy�li se mnou" + Environment.NewLine + " do ulic a jednou pro v�dy uk�zali, jak to tady chod�!" + Environment.NewLine + Environment.NewLine + "Koment��e:" + Environment.NewLine + "Freebird246:Autor �l�nku asi omylem zapomn�l zm�nit, �e ten doty�n� chl�pek" + Environment.NewLine + " zni�il ��st ho��c� budovy, aby zachr�nil jej� obyvatele!" + Environment.NewLine + "13:58";
            beasttamerNews = "�OK! Zv��ata ovlivn�na nezn�m�m mu�em zabila 19 lid�." + Environment.NewLine + Environment.NewLine + "Ve st�edu odpoledne 23. srpna se rozlehla panika, v Central Parksk� Zoo, rychle" + Environment.NewLine + "jako ohe�. Podle sv�dk� pr� zv��ata ovlivnil jak�si nezn�m� mu� v mlad��ch letech" + Environment.NewLine + "a rozk�zal jim rozn�et krut� teror po ulic�ch New Yorku. B�hem dvou minut chaosu" + Environment.NewLine + "byli u�lap�ni �ty�i lidi a zbyl�ch patn�ct lid� bylo krut� popraveno zv��aty." + Environment.NewLine + "Podle z�b�r� kamer se jatek z��astnilo sedm druh� zv��at. Zoologov� si nemohou" + Environment.NewLine + "tuto z�hadu vysv�tlit jinak, ne� �e zv��ata byla ovlivn�na mutantem nov�ho druhu." + Environment.NewLine + "  Varujeme �ten��em p�ed nebezpe��m �toku. Z�sta�te rad�i doma a nevzdalujte" + Environment.NewLine + "se z m�sta bez ��dn�ho dozoru lovc�. Kdybyste n�kde vid�li v��e zm�n�n�ho mu�e," + Environment.NewLine + "kter�ho policie popsala jako �ernovlas�ho vousat�ho �ty�ic�tn�ka, ihned kontaktujte" + Environment.NewLine + "policii.";
            phasewalkerNews = "Ozna�en� Phase Walker jste mohli sly�et posledn� dobou docela �asto a ne v�dy" + Environment.NewLine + "jako pozitivn� ozna�en�. Zd� se, �e lidstvo vstoupilo do nov� generace lid�, proto�e" + Environment.NewLine + "nov� mutace ji� existuj�c�ho genu The Others se objevuj� jak na b��c�m p�se." + Environment.NewLine + "Sice jde o zcela ojedin�l� p��pady, ale zpr�vy a dohady o znovuzrozen� lidstva" + Environment.NewLine + "u� nem��eme ignorovat dlouho." + Environment.NewLine + "  Abychom nezach�zely a� p��li� daleko od t�matu, �ekneme si n�co o nov� mutaci" + Environment.NewLine + "lid� naz�van�ch Phase Walkers. Tento n�zev vznikl z jejich schopnosti vstupovat" + Environment.NewLine + "do jin� reality, nebo jinak �e�eno do jin�ho rozhr�n� na�� reality. Podle tvrzen� rodi��" + Environment.NewLine + "dvan�ctilet�ho chlapce Ethana Mosse, kter�m se Ethan sv��il o jeho schopnosti," + Environment.NewLine + "m��e chlapec ur�it�m zp�sobem st�le zasahovat do na�� reality, ale krom� zraku" + Environment.NewLine + "nem��e na�� realitu smyslov� vn�mat.";
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

            #region Na��t�n� textur pat��c�ch do list�

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

            #region napl�ov�n� menu listama textur a ur�ov�n� startovn� pozice

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
            //na�te my�
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
                optMenu.DockY = menuY;//zm�n� kone�nou pozici pohybu na dockovac� sou�adnici
                optMenu.changeMovement("up");//changeMovement zkontroluje jestli m��e menu do sm�ru "left"
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

            spriteBatch.Draw(iconMouse, new Rectangle(mys.X - 15, mys.Y - 10, iconMouse.Width, iconMouse.Height), Color.White); //Vykreslen� my�i (mus� b�t posledn�)
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
