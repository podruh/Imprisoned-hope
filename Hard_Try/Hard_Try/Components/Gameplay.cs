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

    public class Gameplay : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private Game1 Hra;

        SpriteBatch spriteBatch;

        Sprite MenuButton;

        Texture2D iconMouse, MenuButtonTexture, temp, tempMenu, UI;

        List<Texture2D> MenuTextury;

        Menu GamePlayMenu;

        MapManager MapManager;

        MouseState mys, staraMys;

        KeyboardState keyboard, starKeyboard;

        bool oldEnabled, EnabledMove;

        SaveManager SaveM;

        Player player;

        Map CurrentMap;

        int PosunX, PosunY;

        Vector2 Posun;

        string SaveName;

        public Gameplay(Game1 game)
            : base(game)
        {
            Hra = game;
        }

        
        public override void Initialize()
        {
            EnabledMove = true;
            Hra.PrepniNoteMessage(false, "");
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            MenuTextury = new List<Texture2D>();

            iconMouse = Hra.Content.Load<Texture2D>(@"Textury\iconMouse");
            tempMenu = Hra.Content.Load<Texture2D>(@"Textury\Menu\Temporary");
            temp = Hra.Content.Load<Texture2D>(@"Textury\temp");
            UI = Hra.Content.Load<Texture2D>(@"Textury\UI");
            MenuButtonTexture = temp;

            MapManager = new MapManager(Hra);
            MapManager.Nahrat();
            CurrentMap = MapManager.GetMaps()[1];
            Posun = new Vector2(CurrentMap.GetPosunX(), CurrentMap.GetPosunY());
            PosunX = (int)Posun.X;
            PosunY = (int)Posun.Y;

            SaveM = new SaveManager(Hra);

            player = new Player(Hra, 300, 300, 100, "kokot");

            MenuButton = new Sprite(MenuButtonTexture, new Rectangle(0, 0, MenuButtonTexture.Width, MenuButtonTexture.Height), Color.White);

            MenuTextury.Add(Hra.Content.Load<Texture2D>(@"Textury/In-Game Menu/Save Game"));
            MenuTextury.Add(Hra.Content.Load<Texture2D>(@"Textury/In-Game Menu/Load Game"));
            MenuTextury.Add(Hra.Content.Load<Texture2D>(@"Textury/In-Game Menu/Main Menu"));
            MenuTextury.Add(Hra.Content.Load<Texture2D>(@"Textury/In-Game Menu/Back"));


            GamePlayMenu = new Menu(MenuTextury, new Rectangle((1280 / 2) - (tempMenu.Width / 2), -300, 0, 0), 1.5F, (1280 / 2) - tempMenu.Width / 2, (720 / 2) - tempMenu.Height / 2);
            GamePlayMenu.DockY = (720 / 2) - (GamePlayMenu.Rectangle.Height / 2);
            base.LoadContent();
        }
        
        public override void Update(GameTime gameTime)
        {
            //jestli se zmìní enabled na tru, tak naète znova mapList
            if (Enabled != oldEnabled && Enabled == true)
            {
                MapManager.Nahrat();

            }

            //update myši a klávesnice
            staraMys = mys;
            starKeyboard = keyboard;
            keyboard = Keyboard.GetState();
            mys = Mouse.GetState();
            float speed = 0.1999F;

            if (EnabledMove)
                player.PlayerUpdate(mys, staraMys, keyboard, starKeyboard, gameTime, CurrentMap);
            #region posun mapy
            if (player.Rectangle.Top + PosunY <= 64)
            {
                double elapsed = gameTime.ElapsedGameTime.Milliseconds;
                Posun.Y += (float)(speed * elapsed);
                PosunY = (int)Posun.Y;                             
            }
            if (player.Rectangle.Right + PosunX>= 1216)
            {
                double elapsed = gameTime.ElapsedGameTime.Milliseconds;
                Posun.X -= (float)(speed * elapsed);
                PosunX = (int)Posun.X;                             
            }
            if (player.Rectangle.Bottom + PosunY >= 656)
            {
                double elapsed = gameTime.ElapsedGameTime.Milliseconds;
                Posun.Y -= (float)(speed * elapsed);
                PosunY = (int)Posun.Y;                             
            } 
            if (player.Rectangle.Left + PosunX <= 64)
            {
                double elapsed = gameTime.ElapsedGameTime.Milliseconds;
                Posun.X += (float)(speed * elapsed);
                PosunX = (int)Posun.X;                             
            }
            CurrentMap.UpdatePosun(PosunX, PosunY);
            #endregion

            #region tlaèítka
            if (StisknutaKlavesa(Keys.Escape))
            {
                if (EnabledMove)
                {
                    EnabledMove = false;
                    GamePlayMenu.DockY = (720 / 2) - (GamePlayMenu.Rectangle.Height / 2);
                    GamePlayMenu.changeMovement("down");
                }
                else
                {
                    EnabledMove = true;
                    GamePlayMenu.DockY = -200;
                    GamePlayMenu.changeMovement("up");
                }
                
            }
            if (GamePlayMenu.MenuItems[0].isClicked(mys))
            {
                SaveGame();
            }
            if (GamePlayMenu.MenuItems[1].isClicked(mys))
            {
                LoadGame();
            }
            if (GamePlayMenu.MenuItems[2].isClicked(mys))
            {
                EnabledMove = false;
                Hra.PrepniObrazovku(Hra.displayMenu);
            }
            if (GamePlayMenu.MenuItems[3].isClicked(mys))
            {
                EnabledMove = true;
                GamePlayMenu.DockY = -200;
                GamePlayMenu.changeMovement("up");
            }

            #endregion           

            GamePlayMenu.moveMenu(gameTime);
            oldEnabled = Enabled;
            base.Update(gameTime);
        }

        public bool StisknutaKlavesa(Keys key)
        {
            if (keyboard.IsKeyDown(key)&& !starKeyboard.IsKeyDown(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool StisknuteTlacitko(Sprite tlacitko)
        {
            if (tlacitko.Rectangle.Contains(mys.X,mys.Y)&& staraMys != mys && mys.LeftButton == ButtonState.Pressed)
            {
                return true; 
            }
            else
            {
                return false;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            //prozatimní vyjkreslování mapy
            CurrentMap.Draw(spriteBatch);
            //vykreslování hráèe
            player.DrawPlayer(spriteBatch);
            //vykreslení UI
            spriteBatch.Draw(UI,new Rectangle(0,656,1280,64),Color.White);            
            //vykreslení healthbaru
            player.DrawHealtBar(spriteBatch);
            
            
            GamePlayMenu.DrawMenu(spriteBatch);
            spriteBatch.Draw(iconMouse, new Rectangle(mys.X - 15, mys.Y - 10, iconMouse.Width, iconMouse.Height), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void ZmenMapu(int index)
        {
            MapManager.UpdateMap(CurrentMap);
            CurrentMap = MapManager.GetMaps()[index];
            PosunX = CurrentMap.GetPosunX();
            PosunY = CurrentMap.GetPosunY();
            Posun = new Vector2(PosunX, PosunY);
        }

        public void NovaHra(string jmeno, string klasa)
        {
            MapManager.Nahrat();
            CurrentMap = MapManager.GetMaps()[0];
            PosunX = CurrentMap.GetPosunX();
            PosunY = CurrentMap.GetPosunY();
            Posun = new Vector2(PosunX, PosunY);
            player = new Player(Hra,200,200,100,klasa);
            SaveName = jmeno;
        }

        public void SaveGame()
        {
            SaveM.LoadSaves();
            Hra.PrepniNoteMessage(true, "ahoj");
            SaveM.AddSave(new Save(player, MapManager, SaveName));
            SaveM.SaveSaves();
        }

        public void LoadGame()
        {
            SaveM.LoadSaves();            
            LoadGameForm LGF = new LoadGameForm(SaveM, this);
            LGF.ShowDialog();
        }

        public void LoadGameByname(string name)
        {
            Save save = SaveM.GetSaveByName(name);
            MapManager = new MapManager(Hra, save.Maplist);
            MapManager.SetBlocksInAllMaps();
            Player p = save.Player;
            player = new Player(Hra,p.PosX,p.PosY,p.Health,p.Class,p.Inventory);
            CurrentMap = MapManager.GetMapByName(p.OnMap);
            PosunX = CurrentMap.GetPosunX();
            PosunY = CurrentMap.GetPosunY();
            Posun = new Vector2(PosunX, PosunY);

            EnabledMove = true;
            GamePlayMenu.DockY = -200;
            GamePlayMenu.changeMovement("up");
        }


    }
}
