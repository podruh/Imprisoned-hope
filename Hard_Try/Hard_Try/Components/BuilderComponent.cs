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
    public class BuilderComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private Game1 Hra;

        SpriteBatch spriteBatch;

        public Texture2D mrizka,iconMouse, brickWall, OK, prompt, input;
        public MouseState mys,staraMys;
        public KeyboardState keyboard, staraKeyboard;
        public SpriteFont FontCourierNew;

        Map currentMap;

        List<Block> mrizkaBloky;
        List<Block> mapBloky;

        BuilderPromtp FormPrompt;

        private bool promptShown;

        private int posunX, posunY;

        public BuilderComponent(Game1 game)
            : base(game)
        {
            // TODO: Construct any child components here
            Hra = game;
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            mrizkaBloky = new List<Block>();
            mapBloky = new List<Block>();
            posunX = 0;
            posunY = 0;
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            mrizka = Hra.Content.Load<Texture2D>(@"Textury\mrizka");
            iconMouse = Hra.Content.Load<Texture2D>(@"Textury\iconMouse");
            brickWall = Hra.Content.Load<Texture2D>(@"Textury\Brick Wall");
            OK = Hra.Content.Load<Texture2D>(@"Textury\OKbutton");
            input = Hra.Content.Load<Texture2D>(@"Textury\input");
            prompt = Hra.Content.Load<Texture2D>(@"Textury\prompt");
            
            for (int i = 0; i < Hra.vyska; i += mrizka.Height)
            {
                for (int j = 0; j < Hra.sirka; j += mrizka.Width)
                {
                    mrizkaBloky.Add(new Block(mrizka, mrizka, new Rectangle(j, i, mrizka.Width, mrizka.Height), Color.White));
                }
            }
            FontCourierNew = Hra.Content.Load<SpriteFont>(@"Fonty\courier_new");            

            base.LoadContent();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            staraMys = mys;
            mys = Mouse.GetState();

            staraKeyboard = keyboard;
            keyboard = Keyboard.GetState();

            VstupUpdate();

            KliknutaMrizka();
            
            base.Update(gameTime);
        }

        public void VstupUpdate()
        {
            if (keyboard.IsKeyDown(Keys.Up)&& !staraKeyboard.IsKeyDown(Keys.Up))
            {
                posunY -= 32;
            }
            if (keyboard.IsKeyDown(Keys.Down) && !staraKeyboard.IsKeyDown(Keys.Down))
            {
                posunY += 32;
            }
            if (keyboard.IsKeyDown(Keys.Left) && !staraKeyboard.IsKeyDown(Keys.Left))
            {
                posunX -= 32;
            }
            if (keyboard.IsKeyDown(Keys.Right) && !staraKeyboard.IsKeyDown(Keys.Right))
            {
                posunX += 32;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            spriteBatch.Begin();

            //vykreslení vodící møížky
            foreach (Block item in mrizkaBloky)
            {
                item.DrawBlockLine(spriteBatch,0,0);
            }
            //vykreslení použitých blokù
            foreach (Block item in mapBloky)
            {
                item.DrawBlockLine(spriteBatch, posunX, posunY);
            }
            spriteBatch.Draw(iconMouse, new Rectangle(mys.X - 15, mys.Y - 10, iconMouse.Width, iconMouse.Height), Color.White); //Vykreslení myši (musí být poslední)
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void UlozMapu(Map map)
        { 
            
        }

        private bool Kliknuto(Sprite sprite)
        {
            if (sprite.Rectangle.Contains(mys.X, mys.Y)&& mys.LeftButton == ButtonState.Pressed && staraMys.LeftButton == ButtonState.Released)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void KliknutaMrizka()
        {
            foreach (Block item in mrizkaBloky)
            {
                if (item.Rectangle.Contains(mys.X, mys.Y))
                {
                    item.Color = Color.Orange;
                }
                else
                {
                    item.Color = Color.White;
                }

                if (Kliknuto((Sprite)item) && !promptShown)
                {
                    PrepniPrompt();
                    FormPrompt = new BuilderPromtp(this, item.Rectangle.X, item.Rectangle.Y);
                    FormPrompt.Show();                    
                }
            }
        }

        public void VytvorBlok(string textura, int count, string dir, int x, int y)
        {
            switch (textura)
            {
                case "Brick Wall": 
                    mapBloky.Add(new Block(brickWall, brickWall, new Rectangle(x-posunX, y-posunY, 32, 32), Color.White, dir, count));
                    break;
                default:
                    break;
            }
        }
        public void PrepniPrompt()
        {
            bool b = promptShown;
            promptShown = !b;
        }
    }
}
