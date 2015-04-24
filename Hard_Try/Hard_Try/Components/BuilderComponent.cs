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
using System.IO;
using System.Xml.Serialization;


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

        private Map currentMap;
        private List<Map> mapList;

        private List<Block> mrizkaBloky;
        private List<Block> mapBloky;

        private BuilderPromtp FormPrompt;

        private bool promptShown;

        private int posunX, posunY;

        private string message;

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
            message = "";
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
                    mrizkaBloky.Add(new Block(mrizka, mrizka,"mrizka", new Rectangle(j, i, mrizka.Width, mrizka.Height), Color.White));
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
        /// <summary>
        /// zajišuje posun mapy
        /// </summary>
        public void VstupUpdate()
        {
            if (keyboard.IsKeyDown(Keys.Up)&& !staraKeyboard.IsKeyDown(Keys.Up))
            {
                posunY += 32;
            }
            if (keyboard.IsKeyDown(Keys.Down) && !staraKeyboard.IsKeyDown(Keys.Down))
            {
                posunY -= 32;
            }
            if (keyboard.IsKeyDown(Keys.Left) && !staraKeyboard.IsKeyDown(Keys.Left))
            {
                posunX += 32;
            }
            if (keyboard.IsKeyDown(Keys.Right) && !staraKeyboard.IsKeyDown(Keys.Right))
            {
                posunX -= 32;
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
            spriteBatch.DrawString(FontCourierNew, message, new Vector2(0, 0), Color.Black);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        /// <summary>
        /// vrátí bool jestliže je kliknute na daný sprite
        /// </summary>
        /// <param name="sprite">zjiš´tovaný sprite</param>
        /// <returns>Bool hodnota kliknutí na sprite</returns>
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
        /// <summary>
        /// vytvoøí a otevøe nový fomr pøi kliknutí na møížku
        /// </summary>
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
        /// <summary>
        /// vytvoøí blok, který se poté dodá listu, který bude naèten do mapy k uložení
        /// </summary>
        /// <param name="textura">textura bloku</param>
        /// <param name="count">poèet blokù ve smìru</param>
        /// <param name="dir">smìr vykreslování</param>
        /// <param name="x">pozice x</param>
        /// <param name="y">pozice y</param>
        public void VytvorBlok(string textura, int count, string dir, int x, int y)
        {
            switch (textura)
            {
                case "Brick Wall": 
                    mapBloky.Add(new Block(brickWall, brickWall,"wall", new Rectangle(x-posunX, y-posunY, 32, 32), Color.White, dir, count));
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// pøepne jestli má být prompt zapnutý/vypnutý
        /// </summary>
        public void PrepniPrompt()
        {
            bool b = promptShown;
            promptShown = !b;
        }
        /// <summary>
        /// nìco na zpùsob messageboxu
        /// </summary>
        /// <param name="text">zobrazovaný text vlevo nahoøe</param>
        public void Message(string text)
        {
            this.message = text;
        }
    }
}
