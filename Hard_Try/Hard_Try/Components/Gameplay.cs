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

        Texture2D iconMouse, MenuButtonTexture, temp, tempMenu;

        List<Texture2D> MenuTextury;

        Menu GamePlayMenu;

        MapManager MapManager;

        MouseState mys, staraMys;

        KeyboardState keyboard, starKeyboard;

        bool oldEnabled, Enabled;

        SaveManager SaveM;

        Player player;

        Map CurrentMap;

        public Gameplay(Game1 game)
            : base(game)
        {
            Hra = game;
        }

        
        public override void Initialize()
        {
            Enabled = true;
                       
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            MenuTextury = new List<Texture2D>();

            iconMouse = Hra.Content.Load<Texture2D>(@"Textury\iconMouse");
            tempMenu = Hra.Content.Load<Texture2D>(@"Textury\Menu\Temporary");
            temp = Hra.Content.Load<Texture2D>(@"Textury\temp");
            MenuButtonTexture = temp;

            MapManager = new MapManager(Hra);
            MapManager.Nahrat();
            CurrentMap = MapManager.GetMaps()[0];
            SaveM = new SaveManager(Hra);

            player = new Player(Hra, 300, 300, 100, "kokot");

            MenuButton = new Sprite(MenuButtonTexture, new Rectangle(0, 0, MenuButtonTexture.Width, MenuButtonTexture.Height), Color.White);

            MenuTextury.Add(tempMenu);
            MenuTextury.Add(tempMenu);
            MenuTextury.Add(tempMenu);


            GamePlayMenu = new Menu(MenuTextury, new Rectangle((1280 / 2) - (tempMenu.Width / 2), -200, 0, 0), 1.5F, (1280 / 2) - tempMenu.Width / 2, (720 / 2) - tempMenu.Height / 2);
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
            if(Enabled)
                player.PlayerUpdate(mys, staraMys, keyboard, starKeyboard, gameTime,CurrentMap);
            //vypnutá gameply pomocí ESC

            if (StisknutaKlavesa(Keys.Escape))
            {
                Hra.PrepniObrazovku(Hra.displayMenu);
            }

            if (StisknuteTlacitko(MenuButton))  
            {
                Enabled = false;
                GamePlayMenu.DockY = (720 / 2) - (GamePlayMenu.Rectangle.Height / 2);
                GamePlayMenu.changeMovement("down");

            }
            if (GamePlayMenu.MenuItems[2].isClicked(mys))
            {
                Enabled = true;
                GamePlayMenu.DockY = -200;
                GamePlayMenu.changeMovement("up");
            }
            if (GamePlayMenu.MenuItems[1].isClicked(mys))
            {
                Enabled = false;
                Hra.PrepniObrazovku(Hra.displayMenu);
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
            //vykreslení healthbaru
            player.DrawHealtBar(spriteBatch);


            MenuButton.Draw(spriteBatch);
            GamePlayMenu.DrawMenu(spriteBatch);
            spriteBatch.Draw(iconMouse, new Rectangle(mys.X - 15, mys.Y - 10, iconMouse.Width, iconMouse.Height), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void ZmenMapu(int index)
        {
            MapManager.UpdateMap(CurrentMap);
            CurrentMap = MapManager.GetMaps()[index];
        }
    }
}
