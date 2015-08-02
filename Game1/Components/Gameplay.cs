using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Imprisoned_Hope
{

    public class Gameplay : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private Game1 Hra;

        SpriteBatch spriteBatch;

        Sprite MenuButton, InventoryButton;

        Texture2D iconMouse, MenuButtonTexture, temp, tempMenu, UI, InventoryMenu, Selected;

        SpriteFont FontTimes;

        List<Texture2D> MenuTextury;

        Menu GamePlayMenu;

        MapManager MapManager;

        MouseState mys, staraMys;

        KeyboardState keyboard, starKeyboard;

        bool oldEnabled, EnabledMove, itemsDraw;

        SaveManager SaveM;

        Player player;

        Map CurrentMap;

        int PosunX, PosunY;

        Vector2 Posun;

        string SaveName, message;


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

            iconMouse = Hra.Content.Load<Texture2D>(@"Textury\icon_mouse");
            tempMenu = Hra.Content.Load<Texture2D>(@"Textury\Menu\Temporary");
            temp = Hra.Content.Load<Texture2D>(@"Textury\temp");
            UI = Hra.Content.Load<Texture2D>(@"Textury\UI");
            InventoryButton = new Sprite(Hra.Content.Load<Texture2D>(@"Textury\Items\inventory"),new Rectangle(397,659,48,48),Color.White);
            MenuButtonTexture = temp;
            InventoryMenu = Hra.Content.Load<Texture2D>(@"Textury\Inventory");
            Selected = Hra.Content.Load<Texture2D>(@"Textury\selected");

            FontTimes = Hra.Content.Load<SpriteFont>(@"font_times");

            MapManager = new MapManager(Hra);
            MapManager.Nahrat();
            CurrentMap = MapManager.GetMaps()[0];
            Posun = new Vector2(CurrentMap.GetPosunX(), CurrentMap.GetPosunY());
            PosunX = (int)Posun.X;
            PosunY = (int)Posun.Y;

            SaveM = new SaveManager(Hra);                       

            MenuButton = new Sprite(MenuButtonTexture, new Rectangle(0, 0, MenuButtonTexture.Width, MenuButtonTexture.Height), Color.White);

            MenuTextury.Add(Hra.Content.Load<Texture2D>(@"Textury/In-Game Menu/Save Game"));
            MenuTextury.Add(Hra.Content.Load<Texture2D>(@"Textury/In-Game Menu/Load Game"));
            MenuTextury.Add(Hra.Content.Load<Texture2D>(@"Textury/In-Game Menu/Main Menu"));
            MenuTextury.Add(Hra.Content.Load<Texture2D>(@"Textury/In-Game Menu/Back"));

            GamePlayMenu = new Menu(MenuTextury, new Rectangle((1280 / 2) - (tempMenu.Width / 2), -300, 0, 0), 1.5F, (1280 / 2) - tempMenu.Width / 2, (720 / 2) - tempMenu.Height / 2);
            GamePlayMenu.DockY = (720 / 2) - (GamePlayMenu.Rectangle.Height / 2);
            message = "";
            base.LoadContent();
        }
        
        public override void Update(GameTime gameTime)
        {
            message = "";
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



            if (Hra.GetNoteMessage().Enabled)
            {
                EnabledMove = false;
            }

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
            if (player.Rectangle.Bottom + PosunY >= 640)
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
                if (EnabledMove&&!itemsDraw)
                {
                    EnabledMove = false;
                    GamePlayMenu.DockY = (720 / 2) - (GamePlayMenu.Rectangle.Height / 2);
                    GamePlayMenu.changeMovement("down");
                }
                else if(!EnabledMove)
                {
           
                    EnabledMove = true;
                    GamePlayMenu.DockY = -200;
                    GamePlayMenu.changeMovement("up");
                }
                if (itemsDraw)
                {
                    itemsDraw = false;
                    player.ShowInventory(false);
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

            if (StisknuteTlacitko(InventoryButton)||StisknutaKlavesa(Keys.I))
            {
                 if (itemsDraw)
                {
                    itemsDraw = false;
                    player.ShowInventory(false);
                    EnabledMove = true;
                }
                 else if (!itemsDraw)
                {
                    itemsDraw = true;
                    player.ShowInventory(true);
                    EnabledMove = false;
                }
                
                
                
            }
            #endregion     

            //pohyb hráèe
            if (EnabledMove)
                player.PlayerUpdate(mys, staraMys, keyboard, starKeyboard, gameTime, CurrentMap, Hra);

            //správa inventáøe
            if(itemsDraw)
            { player.InventoryUpdate(mys, staraMys, Hra); }

            foreach (Block item in CurrentMap.Blocks)
            {
                if (((item.Type == "Note" || item.Type == "Newspapers") && item.Rectangle.Intersects(player.Rectangle)))
                {
                    this.message = "Pro zobrazení poznámky stisknìnte E";
                }
            }

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
            spriteBatch.Draw(UI,new Rectangle(5,651,1280,64),Color.White);            
            //vykreslení healthbaru
            player.DrawHealtAndStamina(spriteBatch);

            if (itemsDraw)
                spriteBatch.Draw(InventoryMenu, new Rectangle((1280 / 2) - (InventoryMenu.Width / 2), 100, InventoryMenu.Width, InventoryMenu.Height), Color.White);

            //vykreslení inventory tlaèítka
            InventoryButton.Draw(spriteBatch);
            //vykreslí itemy v toolbaru a inventáø
            player.DrawItems(spriteBatch);
            

            
            
            
            GamePlayMenu.DrawMenu(spriteBatch);
            spriteBatch.DrawString(FontTimes, message, new Vector2(0, 0), Color.Yellow);
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
            List<int> invent = new List<int>() {1,1,1,1};
            List<int> tool = new List<int>() { 3, 1, 3, 1, 3, 1 };
            player = new Player(Hra, 100, 100, klasa, invent,tool, CurrentMap);            
            SaveName = jmeno;
        }

        public void SaveGame()
        {
            SaveM.LoadSaves();
            MapManager.UpdateMap(CurrentMap);
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
            CurrentMap = MapManager.GetMapByName(p.OnMap);
            player = new Player(Hra, p.Health, p.Stamina, p.Class, p.Inventory_ID,p.Toolbar_ID, CurrentMap);
            PosunX = CurrentMap.GetPosunX();
            PosunY = CurrentMap.GetPosunY();
            Posun = new Vector2(PosunX, PosunY);
            EnabledMove = true;
            GamePlayMenu.DockY = -200;
            GamePlayMenu.changeMovement("up");
        }

        //private void DrawItems()
        //{
        //    if (itemsDraw)
        //    {
        //        int x = (1280 / 2) - (InventoryMenu.Width / 2);
        //        int y = 100;
        //        spriteBatch.Draw(InventoryMenu, new Rectangle((1280 / 2) - (InventoryMenu.Width / 2), 100, InventoryMenu.Width, InventoryMenu.Height), Color.White);
        //        foreach (Item item in player.Inventory)
        //        {
        //            if(!item.OnToolbar)
        //                item.Draw(spriteBatch);
        //        }
        //    }
        //}

        //private void UpdateToolBar()
        //{
        //    int i = 0;
        //    foreach (Item item in player.Inventory)
        //    {
        //        if (item.OnToolbar && i < 6)
        //        {
        //            Toolbar[i] = item;
        //            i++;
        //        }
        //        else if (item.OnToolbar)
        //        {
        //            item.OnToolbar = false;
        //        }
        //    }
        //    int x = 13;
        //    int y = 659;
        //    foreach (Item item in Toolbar)
        //    {
        //        item.Rectangle = new Rectangle(x, y, 48, 48);
        //        x += 64;

        //    }
        //}

        //private void DrawToolBar()
        //{
        //    foreach (Item item in Toolbar)
        //    {
        //        item.Draw(spriteBatch);
        //    }
        //}

        //private void UpdateInventory()
        //{
        //    //List<Item> items = player.Inventory;
        //    //int x = (1280 / 2) - (InventoryMenu.Width / 2)+18;
        //    //int y = 118;                        
        //    //for (int i = 0; i < items.Count; i++)
        //    //{
        //    //    if (!items[i].OnToolbar)
        //    //    {
        //    //        items[i].Rectangle = new Rectangle(x, y, items[i].Texture.Width, items[i].Texture.Height);
        //    //        x += 40;
                    
        //    //    }
        //    //    else
        //    //    {
                       
        //    //    }
        //    //    if ((i + 1) % 5 == 0)
        //    //    {
        //    //        y += 40;
        //    //        x -= 200;
        //    //    }

                
        //    //}

        //    for (int j = 0; j < items.Count;j++)
        //    {
        //        if (StisknuteTlacitko((Sprite)items[j]) && j != ItemOnMove)
        //        {
        //            ItemOnMove = j;
        //            ItemDragged = true;
        //        }
        //        if (j == ItemOnMove && ItemDragged)
        //        {
        //            items[j].Rectangle = new Rectangle(mys.X, mys.Y, items[j].Texture.Width, items[j].Texture.Height);
        //        }
        //        UpdateToolBar();
        //        for (int i = 0; i < Toolbar.Length; i++)
        //        {
        //            if (Toolbar[i].Rectangle.Contains(mys.X, mys.Y) && ItemDragged && mys.LeftButton == ButtonState.Pressed && staraMys.LeftButton == ButtonState.Released)
        //            {
        //                Toolbar[i].OnToolbar = false;
        //                Item temp = Toolbar[i];
        //                items[j].OnToolbar = true;
        //                Toolbar[i] = items[j];
        //                items[j] = temp;
        //                ItemDragged = false;
        //                UpdateToolBar();
        //            }
        //        }
        //        UpdateToolBar();
        //        player.Inventory = items;
        //    }                
            
        //}
    }
}
