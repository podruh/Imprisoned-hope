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

        Texture2D mrizka,iconMouse, brickWall;
        public MouseState mys;

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

            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            mrizka = Hra.Content.Load<Texture2D>(@"Textury\mrizka");
            iconMouse = Hra.Content.Load<Texture2D>(@"Textury\iconMouse");
            brickWall = Hra.Content.Load<Texture2D>(@"Textury\Brick Wall");
            base.LoadContent();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            mys = Mouse.GetState();
           
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            spriteBatch.Begin();

            //vykreslení vodící møížky
            for (int i = 0; i < Hra.vyska; i += mrizka.Height-1)
            {
                for (int j = 0; j < Hra.sirka; j += mrizka.Width-1)
                {
                    if (new Rectangle(j, i, mrizka.Width, mrizka.Height).Contains(mys.X,mys.Y))
                    {
                        spriteBatch.Draw(brickWall, new Rectangle(j, i, mrizka.Width, mrizka.Height), Color.Orange);
                    }
                    else
                    {
                        spriteBatch.Draw(mrizka, new Rectangle(j, i, mrizka.Width, mrizka.Height), Color.White);     
                    }
                    
                }
            }
            spriteBatch.Draw(iconMouse, new Rectangle(mys.X - 15, mys.Y - 10, iconMouse.Width, iconMouse.Height), Color.White); //Vykreslení myši (musí být poslední)
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
