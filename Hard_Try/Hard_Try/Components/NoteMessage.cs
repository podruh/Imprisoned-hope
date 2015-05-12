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
    public class NoteMessage : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private Game1 Hra;

        SpriteBatch spriteBatch;
        private string message = "Ticho, svìtlo.Už dlouho usedlý prach se línì zvedl ve skøíni, když kolem probìhl šváb, jeden z mála tvorù, co tu ještì žije. Marnì se snažil otevøít pytlík cerálií, který už odolával horším vìcem a nehodlal se jen tak vzdát.Zatímco prach volnì usedal zpìt na své místo, šváb se rozhodl udìlat si malou pochùzku po komplexu. Slezl ze skøínì a vydal se kolem stolu, rovnì pode dveømi a skrz møíže na chodbu. Colby uslyšel nìjaký šramot. Nenamáhal se pohnout jediným svalem. V této pozici byl už tøi roky a nechtìlo se mu hýbat. Pomyslel si, jestli už nenastal èas, ale hned to zavrhl. Už dávno se pøestal o cokoliv pokoušet. Proè taky? Je to zbyteèné.Chabé svìtlo na chodbì protínalo zvednutý prach a oznaèovalo chaotickou trasu jednoho ze dvou žijících tvorù. Tvor úpìnlivì hledající jakoukoli potravu se ocitl v cele, a co bylo ještì pøekvapivìjší, s jiným tvorem! Na chvilku se zastavil, ale pak zaèal energicky šplhat po stìnì nahoru a blíže k té svítivé vìci na stropì.Druhý tvor vìdìl o pøítomnosti tvora prvního, ale nechtìlo se mu nic dìlat. Zhaslo svìtlo.Druhý tvor nic neudìlal. Už dávno se pøestal  o cokoliv pokoušet. Proè taky? Je to zbyteèné.Ticho, tma.";
        private Texture2D iconBack64, iconMouse, okBtn, noteBck;
        public SpriteFont FontTimes;
        public MouseState mys, staraMys;
        public Rectangle back;

        public NoteMessage(Game1 game)
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

            noteBck = Hra.Content.Load<Texture2D>(@"Textury\noteBck");
            iconMouse = Hra.Content.Load<Texture2D>(@"Textury\iconMouse");
            okBtn = Hra.Content.Load<Texture2D>(@"Textury\OKbutton");
            iconBack64 = Hra.Content.Load<Texture2D>(@"Textury\Menu\back64");

            FontTimes = Hra.Content.Load<SpriteFont>(@"Fonty\times");

            back = new Rectangle((125 + noteBck.Width - iconBack64.Width) - 50, (noteBck.Height - iconBack64.Height) - 50, iconBack64.Width, iconBack64.Height);
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

            if (back.Contains(mys.X, mys.Y) && mys.LeftButton == ButtonState.Pressed)
            {
                Hra.message.Enabled = false;
                Hra.message.Visible = false;
            }

            base.Update(gameTime);
        }
        /// <summary>
        /// zajišuje posun mapy
        /// </summary>
        public override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.Transparent);

            spriteBatch.Begin();

            spriteBatch.Draw(noteBck, new Rectangle(125, 0, noteBck.Width, noteBck.Height), Color.White);
            spriteBatch.Draw(iconBack64, back, Color.White);

            spriteBatch.DrawString(FontTimes, NahrajText(message), new Vector2(175, 50), Color.Black);

            spriteBatch.Draw(iconMouse, new Rectangle(mys.X - 15, mys.Y - 10, iconMouse.Width, iconMouse.Height), Color.White); //Vykreslení myši (musí být poslední)
            spriteBatch.End();
            base.Draw(gameTime);
        }
        public string NahrajText(string text)
        {
                 
        }
    }
}
