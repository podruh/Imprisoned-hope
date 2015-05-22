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
        public Game1 Hra;

        SpriteBatch spriteBatch;

        public Texture2D mrizka,iconMouse, brickWall, OK, prompt, spawn, input, floor1, floor2, floor3, floor4, supplies, grayBrick, grayBrick2, bedHead, bedFeet, jailDoors, jailDoors2, glass, ironBars, note, newspapers, map;
        public MouseState mys,staraMys;
        public KeyboardState keyboard, staraKeyboard;
        public SpriteFont FontCourierNew;

        private Map currentMap;       
        private MapManager manager;

        private List<Block> mrizkaBloky;
        private List<Block> mapBloky;

        private BuilderPromtp FormPrompt;
        private BuilderControler Controler;

        private bool promptShown, controlerShown, promptState;

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
            manager = new MapManager(Hra);
           
            controlerShown = true;
            promptState = false;

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
            #region Blocky
            brickWall = Hra.Content.Load<Texture2D>(@"Textury\Objects\Brick Wall");
            floor1 = Hra.Content.Load<Texture2D>(@"Textury\Objects\floor1");
            floor2 = Hra.Content.Load<Texture2D>(@"Textury\Objects\floor2");
            floor3 = Hra.Content.Load<Texture2D>(@"Textury\Objects\floor3");
            floor4 = Hra.Content.Load<Texture2D>(@"Textury\Objects\floor4");
            grayBrick = Hra.Content.Load<Texture2D>(@"Textury\Objects\grayBrick");
            grayBrick2 = Hra.Content.Load<Texture2D>(@"Textury\Objects\grayBrick2");
            bedHead = Hra.Content.Load<Texture2D>(@"Textury\Objects\bedHead");
            bedFeet = Hra.Content.Load<Texture2D>(@"Textury\Objects\bedFeet");
            jailDoors = Hra.Content.Load<Texture2D>(@"Textury\Objects\JailDoors");
            jailDoors2 = Hra.Content.Load<Texture2D>(@"Textury\Objects\JailDoors2");
            glass = Hra.Content.Load<Texture2D>(@"Textury\Objects\glass");
            ironBars = Hra.Content.Load<Texture2D>(@"Textury\Objects\ironBars");
            supplies = Hra.Content.Load<Texture2D>(@"Textury\Objects\supplies");
            map = Hra.Content.Load<Texture2D>(@"Textury\Objects\map");
            note = Hra.Content.Load<Texture2D>(@"Textury\Objects\note");
            newspapers = Hra.Content.Load<Texture2D>(@"Textury\Objects\newspapers");
            spawn = Hra.Content.Load<Texture2D>(@"Textury\Objects\spawn");
            #endregion
            OK = Hra.Content.Load<Texture2D>(@"Textury\OKbutton");
            input = Hra.Content.Load<Texture2D>(@"Textury\input");
            prompt = Hra.Content.Load<Texture2D>(@"Textury\prompt");
            manager.Nahrat();
            currentMap = manager.GetMapByName(manager.GetMapNameArray()[0]);
            mapBloky = currentMap.Blocks;
            for (int i = 0; i < Hra.vyska; i += mrizka.Height)
            {
                for (int j = 0; j < Hra.sirka; j += mrizka.Width)
                {
                    mrizkaBloky.Add(new Block(mrizka,"mrizka", new Rectangle(j, i, mrizka.Width, mrizka.Height), Color.White, false));
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
        /// zaji�uje posun mapy
        /// </summary>
        public void VstupUpdate()
        {
            if (keyboard.IsKeyDown(Keys.Up)&& !staraKeyboard.IsKeyDown(Keys.Up))
            {
                posunY += 32;
                currentMap.UpdatePosun(posunX, posunY);
            }
            if (keyboard.IsKeyDown(Keys.Down) && !staraKeyboard.IsKeyDown(Keys.Down))
            {
                posunY -= 32;
                currentMap.UpdatePosun(posunX, posunY);
            }
            if (keyboard.IsKeyDown(Keys.Left) && !staraKeyboard.IsKeyDown(Keys.Left))
            {
                posunX += 32;
                currentMap.UpdatePosun(posunX, posunY);
            }
            if (keyboard.IsKeyDown(Keys.Right) && !staraKeyboard.IsKeyDown(Keys.Right))
            {
                posunX -= 32;
                currentMap.UpdatePosun(posunX, posunY);
            }
            
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            if (controlerShown)
            {
                Controler = new BuilderControler(this, manager);
                Controler.Show();
                controlerShown = false;
            }
            
            //vykreslen� vod�c� m��ky
            foreach (Block item in mrizkaBloky)
            {
                item.DrawBlockLine(spriteBatch,0,0);
            }

            //vykreslen� pou�it�ch blok�
            currentMap.Draw(spriteBatch);

            spriteBatch.Draw(iconMouse, new Rectangle(mys.X - 15, mys.Y - 10, iconMouse.Width, iconMouse.Height), Color.White); //Vykreslen� my�i (mus� b�t posledn�)
            spriteBatch.DrawString(FontCourierNew, message, new Vector2(0, 0), Color.Black);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        /// <summary>
        /// vr�t� bool jestli�e je kliknute na dan� sprite
        /// </summary>
        /// <param name="sprite">zji��tovan� sprite</param>
        /// <returns>Bool hodnota kliknut� na sprite</returns>
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
        /// vytvo�� a otev�e nov� form p�i kliknut� na m��ku
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

                if (Kliknuto((Sprite)item) && !promptShown && promptState)
                {
                    PrepniPrompt();
                    FormPrompt = new BuilderPromtp(this, item.Rectangle.X, item.Rectangle.Y);
                    FormPrompt.Show();                    
                }
            }
        }
        /// <summary>
        /// vytvo�� blok, kter� se pot� dod� listu, kter� bude na�ten do mapy k ulo�en�
        /// </summary>
        /// <param name="textura">textura bloku</param>
        /// <param name="count">po�et blok� ve sm�ru</param>
        /// <param name="dir">sm�r vykreslov�n�</param>
        /// <param name="x">pozice x</param>
        /// <param name="y">pozice y</param>
        public void VytvorBlok(string typ, int count, string dir, int x, int y)
        {
            switch (typ)
            {
                case "Brick Wall":
                    mapBloky.Add((Block)new BlockWall(brickWall, "wall", "Ze�!", new Rectangle(x - posunX, y - posunY, 32, 32), Color.White, dir, count));
                    Hra.PrepniNoteMessage(true, "Bj� torickWall");
                    break;

                case "Floor 1":
                    mapBloky.Add((Block)new BlockFloor(floor1, "Floor 1", "Podlaha!", new Rectangle(x - posunX, y - posunY, 32, 32), Color.White, dir, count));
                    break;

                case "Floor 2":
                    mapBloky.Add((Block)new BlockFloor(floor2, "Floor 2", "Podlaha!", new Rectangle(x - posunX, y - posunY, 32, 32), Color.White, dir, count));
                    break;

                case "Floor 3":
                    mapBloky.Add((Block)new BlockFloor(floor3, "Floor 3", "Podlaha!", new Rectangle(x - posunX, y - posunY, 32, 32), Color.White, dir, count));
                    break;

                case "Floor 4":
                    mapBloky.Add((Block)new BlockFloor(floor4, "Floor 4", "Podlaha!", new Rectangle(x - posunX, y - posunY, 32, 32), Color.White, dir, count));
                    break;

                case "Gray Brick Wall":
                    mapBloky.Add((Block)new BlockWall(grayBrick, "Gray Brick Wall", "Ze�!", new Rectangle(x - posunX, y - posunY, 32, 32), Color.White, dir, count));
                    break;

                case "Gray Brick Wall 2":
                    mapBloky.Add((Block)new BlockWall(grayBrick2, "Gray Brick Wall", "Ze�!", new Rectangle(x - posunX, y - posunY, 32, 32), Color.White, dir, count));
                    break;

                case "Bed Head":
                    mapBloky.Add((Block)new BlockFloor(bedHead, "Bed Head", "Postel!", new Rectangle(x - posunX, y - posunY, 32, 32), Color.White, dir, count));
                    break;

                case "Bed Feet":
                    mapBloky.Add((Block)new BlockFloor(bedFeet, "Bed Feet", "Postel!", new Rectangle(x - posunX, y - posunY, 32, 32), Color.White, dir, count));
                    break;

                case "Jail Doors":
                    mapBloky.Add((Block)new BlockDoor(jailDoors, "Jail Doors", "Dve�e!", new Rectangle(x - posunX, y - posunY, 32, 32), Color.White, dir, count, "none"));
                    break;

                case "Jail Doors 2":
                    mapBloky.Add((Block)new BlockDoor(jailDoors2, "Jail Doors 2", "Dve�e!", new Rectangle(x - posunX, y - posunY, 32, 32), Color.White, dir, count, "none"));
                    break;

                case "Glass":
                    mapBloky.Add((Block)new BlockWall(glass, "Glass", "Sklo!", new Rectangle(x - posunX, y - posunY, 32, 32), Color.White, dir, count));
                    break;

                case "Iron Bars":
                    mapBloky.Add((Block)new BlockWall(ironBars, "Iron Bars", "M��e!", new Rectangle(x - posunX, y - posunY, 32, 32), Color.White, dir, count));
                    break;

                case "Spawn":
                    mapBloky.Add((Block)new BlockWall(spawn, "Spawn", " ", new Rectangle(x - posunX, y - posunY, 32, 32), Color.White, dir, 1, false));
                    break;

                default:
                    break;
            }
            currentMap.Blocks = mapBloky;
        }
        /// <summary>
        /// vytvo�� container, kter� se pot� dod� listu, kter� bude na�ten do mapy k ulo�en�
        /// </summary>
        /// <param name="typ">Typ objektu</param>
        /// <param name="itemy">List obsahu containeru</param>
        /// <param name="x">pozice x</param>
        /// <param name="y">pozice y</param>
        public void VytvorContainer(string typ,Item[,] itemy , int x, int y)
        {
            switch (typ)
            {
                //case "Supplies":
                  //  mapBloky.Add((Block)new BlockContainer(supplies, "Supplies", "Bedna!", itemy, new Rectangle(x - posunX, y - posunY, 32, 32),Color.White));
                    //break;
                default:
                    break;
            }
           
            currentMap.Blocks = mapBloky;
        }
        /// <summary>
        /// vytvo�� note, kter� se pot� dod� listu, kter� bude na�ten do mapy k ulo�en�
        /// </summary>
        /// <param name="typ">Typ objektu</param>
        /// <param name="itemy">Text Notu</param>
        /// <param name="x">pozice x</param>
        /// <param name="y">pozice y</param>
        public void VytvorNote(string typ, string text, int x, int y)
        {
            switch (typ)
            {
                case "Note":
                    mapBloky.Add((Block)new BlockNote(note, "Note", "�tr�ek pap�ru!", new Rectangle(x - posunX, y - posunY, 32, 32), Color.White, text));
                    break;

                case "Newspapers":
                    mapBloky.Add((Block)new BlockNote(newspapers, "Newspapers", "Noviny!", new Rectangle(x - posunX, y - posunY, 32, 32), Color.White, text));
                    break;

                case "Map":
                    mapBloky.Add((Block)new BlockNote(map, "Map", "Mapa!", new Rectangle(x - posunX, y - posunY, 32, 32), Color.White, text));
                    break;

                default:
                    break;
            }
        }
        /// <summary>
        /// p�epne jestli m� b�t prompt zapnut�/vypnut�
        /// </summary>
        public void PrepniPrompt()
        {
            bool b = promptShown;
            promptShown = !b;
            ChangePromptState(false);
        }
        /// <summary>
        /// slou�� k povolen� promtpu
        /// </summary>
        /// <param name="st"></param>
        public void ChangePromptState(bool st)
        {
            promptState = st;
        }

        /// <summary>
        /// n�co na zp�sob messageboxu
        /// </summary>
        /// <param name="text">zobrazovan� text vlevo naho�e</param>
        public void Message(string text)
        {
            this.message = text;
        }
        /// <summary>
        /// vym�n� mapu k vekreslen� a upravov�n� podle zadan�ho jm�na
        /// </summary>
        /// <param name="mapName">jm�no mapy k na�ten�</param>
        public void PrepniMapu(string mapName)
        {
            manager.UpdateMap(currentMap);
            currentMap = manager.GetMapByName(mapName);
            mapBloky = currentMap.Blocks;
        }
        /// <summary>
        /// ulo�� v�echny mapy a p�id� posledn� zm�ny
        /// </summary>
        public void UlozMapy()
        {
            manager.UpdateMap(currentMap);
            manager.Ulozit();
        }
        /// <summary>
        /// vytvo�� novou mapu a p�id� j� do seznamu map
        /// </summary>
        /// <param name="name">jm�no nov� mapy</param>
        public void NovaMapa(string name)
        {
            manager.UpdateMap(currentMap);
            currentMap = new Map(name);
            mapBloky = new List<Block>();
            manager.AddMap(currentMap);
        }
        /// <summary>
        /// p�epne zp�t do menu
        /// </summary>
        public void Zavri()
        {
            
            Hra.PrepniObrazovku(Hra.displayMenu);
            controlerShown = true;

        }
    }
}
