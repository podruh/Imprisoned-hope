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
        private string message = "Ticho, sv�tlo.U� dlouho usedl� prach se l�n� zvedl ve sk��ni, kdy� kolem prob�hl �v�b, jeden z m�la tvor�, co tu je�t� �ije. Marn� se sna�il otev��t pytl�k cer�li�, kter� u� odol�val hor��m v�cem a nehodlal se jen tak vzd�t.Zat�mco prach voln� usedal zp�t na sv� m�sto, �v�b se rozhodl ud�lat si malou poch�zku po komplexu. Slezl ze sk��n� a vydal se kolem stolu, rovn� pode dve�mi a skrz m��e na chodbu. Colby usly�el n�jak� �ramot. Nenam�hal se pohnout jedin�m svalem. V t�to pozici byl u� t�i roky a necht�lo se mu h�bat. Pomyslel si, jestli u� nenastal �as, ale hned to zavrhl. U� d�vno se p�estal o cokoliv pokou�et. Pro� taky? Je to zbyte�n�.Chab� sv�tlo na chodb� prot�nalo zvednut� prach a ozna�ovalo chaotickou trasu jednoho ze dvou �ij�c�ch tvor�. Tvor �p�nliv� hledaj�c� jakoukoli potravu se ocitl v cele, a co bylo je�t� p�ekvapiv�j��, s jin�m tvorem! Na chvilku se zastavil, ale pak za�al energicky �plhat po st�n� nahoru a bl�e k t� sv�tiv� v�ci na strop�.Druh� tvor v�d�l o p��tomnosti tvora prvn�ho, ale necht�lo se mu nic d�lat. Zhaslo sv�tlo.Druh� tvor nic neud�lal. U� d�vno se p�estal  o cokoliv pokou�et. Pro� taky? Je to zbyte�n�.Ticho, tma.";
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
        /// zaji�uje posun mapy
        /// </summary>
        public override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.Transparent);

            spriteBatch.Begin();

            spriteBatch.Draw(noteBck, new Rectangle(125, 0, noteBck.Width, noteBck.Height), Color.White);
            spriteBatch.Draw(iconBack64, back, Color.White);

            spriteBatch.DrawString(FontTimes, NahrajText(message), new Vector2(175, 50), Color.Black);

            spriteBatch.Draw(iconMouse, new Rectangle(mys.X - 15, mys.Y - 10, iconMouse.Width, iconMouse.Height), Color.White); //Vykreslen� my�i (mus� b�t posledn�)
            spriteBatch.End();
            base.Draw(gameTime);
        }
        public string NahrajText(string text)
        {
                 
        }
    }
}
