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

        Texture2D iconMouse;

        MapManager MapManager;

        MouseState mys, staraMys;

        KeyboardState keyboard, starKeyboard;

        bool oldEnabled;

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

                       
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            iconMouse = Hra.Content.Load<Texture2D>(@"Textury\iconMouse");

            MapManager = new MapManager(Hra);
            MapManager.Nahrat();
            CurrentMap = MapManager.GetMaps()[0];
            SaveM = new SaveManager(Hra);

            player = new Player(Hra, 300, 300, 100, "kokot");

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
            player.PlayerUpdate(mys, staraMys, keyboard, starKeyboard, gameTime,CurrentMap);
            //vypnutá gameply pomocí ESC

            if (StisknutaKlavesa(Keys.Escape))
            {
                Hra.PrepniObrazovku(Hra.displayMenu);
            }

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
