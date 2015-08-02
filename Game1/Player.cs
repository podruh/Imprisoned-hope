using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Imprisoned_Hope
{
    [Serializable()]
    public class Player : Sprite
    {
        public string Class;

        public int Health;

        public int Stamina;

        public int PosX;

        public int PosY;

        public string OnMap;

        public List<int> Inventory_ID;

        public List<int> Toolbar_ID;

        [XmlIgnore]
        public List<Item> Inventory;
        [XmlIgnore]
        private Item[] Toolbar = new Item[6];

        [XmlIgnore]
        private List<Texture2D> textures;

        [XmlIgnore]
        float Speed;

        [XmlIgnore]
        private Texture2D HealthTexture, StaminaTexture;

        [XmlIgnore]
        private Sprite Selected;

        [XmlIgnore]
        private int PX,PY,ItemOnMove,SelectedItem;

        [XmlIgnore]
        private bool InventoryIsShown, itemDragged;

        public Player()
        { 
            
        }

        public Player(Game1 game,int posX,int posY, int health,string klasa)
        { 
            //doplnění listu textures
            textures = new List<Texture2D>();
            textures.Add(game.Content.Load<Texture2D>(@"Textury\Hero"));
            textures.Add(game.Content.Load<Texture2D>(@"Textury\Hero Up"));
            //nastavení ostatních hodnot
            this.PosX = posX;
            this.PosY = posY;
            this.Health = health;
            Speed = 0.2F;
            //SetPlayer(textures[0]);
            HealthTexture = game.Content.Load<Texture2D>(@"Textury\Health1");
            Class = klasa;
            Inventory = new List<Item>();
            SetItemTextures(game);
        }

        public Player(Game1 game, int health, int stamina, string klasa, List<int> items, List<int> tool, Map map)
        {
            //doplnění listu textures
            textures = new List<Texture2D>();
            textures.Add(game.Content.Load<Texture2D>(@"Textury\Hero"));
            textures.Add(game.Content.Load<Texture2D>(@"Textury\mainVelkyUp"));
            //nastavení ostatních hodnot
            this.Health = health;
            this.Stamina = stamina;
            Speed = 0.2F;            
            StaminaTexture = game.Content.Load<Texture2D>(@"Textury\Stamina1");
            HealthTexture = game.Content.Load<Texture2D>(@"Textury\Health1");
            Selected = new Sprite(game.Content.Load<Texture2D>(@"Textury\selected"),new Rectangle(5,651,64,64),Color.White);
            Class = klasa;
            Inventory_ID = items;
            Toolbar_ID = tool;
            SelectedItem = 0; 
            SetPlayer(textures[0], map);
            SetItems(game);
            SetToolbar(game);
        }

        public void SetItemTextures(Game1 game)
        {
            foreach (Item item in Inventory)
            {
                if (item != null)
                {
                    switch (item.Type)
                    {
                        case "Food":
                            item.Texture = game.Content.Load<Texture2D>(@"Textury\Items\food");
                            break;
                        case "Drink":
                            item.Texture = game.Content.Load<Texture2D>(@"Textury\Items\Drink");
                            break;
                        case "Key":
                            item.Texture = game.Content.Load<Texture2D>(@"Textury\Items\key");
                            break;
                        case "AidKit":
                            item.Texture = game.Content.Load<Texture2D>(@"Textury\Items\FirstAidKit");
                            break;
                        case "Tool":
                            item.Texture = game.Content.Load<Texture2D>(@"Textury\Items\shovel");
                            break;
                        case "Weapon":
                            item.Texture = game.Content.Load<Texture2D>(@"Textury\Items\weapon");
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public void SetItems(Game1 game)
        {
            Inventory = new List<Item>();
            foreach (int id in Inventory_ID)
            {
                Inventory.Add(GetItemByID(game, id));
            }
            for (int i = 0; i < Toolbar_ID.Count; i++)
            {
                if (i < 6)
                {
                    Toolbar[i] = GetItemByID(game, Toolbar_ID[i]);    
                }
                
            }
            
        }

        private Item GetItemByID(Game1 game,int id)
        {
            switch (id)
            {
                case 0:
                    return new Item(game.Content.Load<Texture2D>(@"Textury\Objects\spawn"), new Rectangle(0, 0, 32, 32), Color.White, false, "empty","empty");

                case 1:
                    return new Item(game.Content.Load<Texture2D>(@"Textury\Items\food"), new Rectangle(0, 0, 32, 32), Color.White, true, "Food", "food");

                case 2:
                    return new Item(game.Content.Load<Texture2D>(@"Textury\Items\food"), new Rectangle(0, 0, 32, 32), Color.White, false, "Food", "food");

                case 3:
                    return new Item(game.Content.Load<Texture2D>(@"Textury\Items\Drink"), new Rectangle(0, 0, 32, 32), Color.White, true, "Drink", "drink");

                case 4:
                    return new Item(game.Content.Load<Texture2D>(@"Textury\Items\Drink"), new Rectangle(0, 0, 32, 32), Color.White, false, "Drink","drink");

                case 5:
                    return new Item(game.Content.Load<Texture2D>(@"Textury\Items\weapon"), new Rectangle(0, 0, 32, 32), Color.White, true, "Weapon", "weapon");

                case 6:
                    return new Item(game.Content.Load<Texture2D>(@"Textury\Items\weapon"), new Rectangle(0, 0, 32, 32), Color.White, false, "Weapon", "weapon");

                default:
                    return new Item(game.Content.Load<Texture2D>(@"Textury\Objects\spawn"), new Rectangle(0, 0, 32, 32), Color.White, false, "empty", "empty");
            }                
        }

        public void SetPlayer(Texture2D texture,Map map)
        {
            this.Texture = texture;
            SetToSpawn(map);
            this.Position = new Vector2(PosX, PosY);
            this.Rectangle = new Rectangle(PosX, PosY, Texture.Width, Texture.Height);
            this.Color = Color.White;
        }

        public void PlayerUpdate(MouseState mys, MouseState staraMys, KeyboardState keyboard, KeyboardState staraKeyboard, GameTime gameTime, Map map, Game1 game)
        {
            OnMap = map.Name;
            this.PX = map.GetPosunX();
            this.PY = map.GetPosunY();
            PosX = Rectangle.X;
            PosY = Rectangle.Y;
            Movement(keyboard, gameTime, map);
            BlockUpdate(map, keyboard, game);
            ToolBarAndInventoryUpdate(staraMys,mys,game);
            SelectedItemUpdate(mys, staraMys, keyboard, staraKeyboard, game);

        }

        public void InventoryUpdate(MouseState mys, MouseState staraMys, Game1 game)
        {
            ToolBarAndInventoryUpdate(staraMys, mys, game);
        }

        public void DrawPlayer(SpriteBatch sb)
        {
            sb.Draw(Texture, new Rectangle(Rectangle.X + PX,Rectangle.Y + PY,Rectangle.Width,Rectangle.Height), Color);
        }

        public void Movement(KeyboardState keyboard,GameTime gameTime, Map map)
        {
            if ((keyboard.IsKeyDown(Keys.Up)||keyboard.IsKeyDown(Keys.W)) && !Collides(keyboard,map))
            {
                if (Texture != textures[1])
                {
                    this.Texture = textures[1];
                }
                double elapsed = gameTime.ElapsedGameTime.Milliseconds;
                Position.Y -= (float)(Speed * elapsed);
                Rectangle.Y = (int)Position.Y;
            }
             if ((keyboard.IsKeyDown(Keys.Down)||keyboard.IsKeyDown(Keys.S)) && !Collides(keyboard, map))
            {
                if (Texture != textures[0])
                {
                    this.Texture = textures[0];
                }
                double elapsed = gameTime.ElapsedGameTime.Milliseconds;
                Position.Y += (float)(Speed * elapsed);
                Rectangle.Y = (int)Position.Y;
            }
             if ((keyboard.IsKeyDown(Keys.Left) || keyboard.IsKeyDown(Keys.A))&& !Collides(keyboard, map))
            {
                //if (Texture != textures[2])
                //{
                //    this.Texture = textures[2];
                //}
                double elapsed = gameTime.ElapsedGameTime.Milliseconds;
                Position.X -= (float)(Speed * elapsed);
                Rectangle.X = (int)Position.X;
            }
             if ((keyboard.IsKeyDown(Keys.Right)||keyboard.IsKeyDown(Keys.D)) && !Collides(keyboard, map))
            {
                //if (Texture != textures[3])
                //{
                //    this.Texture = textures[3];
                //}
                double elapsed = gameTime.ElapsedGameTime.Milliseconds;
                Position.X += (float)(Speed * elapsed);
                Rectangle.X = (int)Position.X;
            }
        }

        public bool Collides(KeyboardState key, Map map)
        {
            List<Block> bloky = map.GetCollideBlocks();
            foreach (var item in bloky)
            {
                    if (
                        (key.IsKeyDown(Keys.Up) || key.IsKeyDown(Keys.W))
                        && ((this.Rectangle.Left >= item.Rectangle.Left && this.Rectangle.Left <= item.Rectangle.Right-2) || (this.Rectangle.Right >= item.Rectangle.Left+2 && this.Rectangle.Right <= item.Rectangle.Right))
                        && (this.Position.Y + this.Rectangle.Height >= item.Rectangle.Bottom && this.Position.Y + this.Rectangle.Height <= item.Rectangle.Bottom + 4)
                        )
                    {
                        return true;
                    }
                     if (
                        (key.IsKeyDown(Keys.Right) || key.IsKeyDown(Keys.D))
                        && (this.Rectangle.Right >= item.Rectangle.Left - 3 && this.Rectangle.Right <= item.Rectangle.Left)
                        && ((this.Rectangle.Bottom <= item.Rectangle.Bottom && this.Rectangle.Bottom >= item.Rectangle.Top) 
                        ))
                    {
                        return true;
                    }
                     if (
                        (key.IsKeyDown(Keys.Down) || key.IsKeyDown(Keys.S))
                        && ((this.Rectangle.Left >= item.Rectangle.Left && this.Rectangle.Left <= item.Rectangle.Right-2) || (this.Rectangle.Right >= item.Rectangle.Left+2 && this.Rectangle.Right <= item.Rectangle.Right))
                        && (this.Rectangle.Bottom >= item.Rectangle.Top - 3 && this.Rectangle.Bottom <= item.Rectangle.Top)
                        )
                    {
                        return true;
                    }
                     if (
                        (key.IsKeyDown(Keys.Left) || key.IsKeyDown(Keys.A))
                        && (this.Rectangle.Left <= item.Rectangle.Right + 3 && Rectangle.Left >= item.Rectangle.Right)
                        && ((this.Rectangle.Bottom <= item.Rectangle.Bottom && this.Rectangle.Bottom >= item.Rectangle.Top)
                        ))
                    {
                        return true;
                    }               
            } 
            
            return false;          
        }

        public void DrawHealtAndStamina(SpriteBatch spriteBatch)
        {
            int x = 1273;
            int y = 688;
            for (int i = 1; i <= Health; i++)
            {
                spriteBatch.Draw(HealthTexture, new Rectangle(x, y, HealthTexture.Width, HealthTexture.Height), Color.White);
                x -= 2;
            }

            x = 1273;
            y = 658;
            for (int i = 1; i <= Health; i++)
            {
                spriteBatch.Draw(StaminaTexture, new Rectangle(x, y, StaminaTexture.Width, StaminaTexture.Height), Color.White);
                x -= 2;
            }
        }

        public void SetToSpawn(Map map)
        {
            foreach (Block item in map.Blocks)
            {
                if (item.Type == "Spawn")
                {
                    PosX = item.Rectangle.X;
                    PosY = item.Rectangle.Y;
                    break;
                }
            }
        }

        private void BlockUpdate(Map map, KeyboardState key, Game1 hra)
        {
            foreach (Block item in map.Blocks)
            {
                if (((item.Type == "Note" || item.Type == "Newspapers") && item.Rectangle.Intersects(this.Rectangle)) && key.IsKeyDown(Keys.E))
                {
                    BlockNote note = (BlockNote)item;
                    hra.PrepniNoteMessage(true, note.message);
                }
            }
        }

        private void ToolBarAndInventoryUpdate(MouseState staraMys, MouseState mys, Game1 game)
        { 

            SetToolbar(game);
            //nastavenní inventáře
            int x = (1280 / 2) - (228 / 2) + 18;
            int y = 118;
            for (int i = 0; i < Inventory.Count; i++)
            {
                if (!Inventory[i].OnToolbar)
                {
                    Inventory[i].Rectangle = new Rectangle(x, y, Inventory[i].Texture.Width, Inventory[i].Texture.Height);
                    x += 40;

                }
                else if (Inventory[i].OnToolbar)
                {
                    Inventory[i].OnToolbar = false;
                    Inventory[i].Rectangle = new Rectangle(x, y, Inventory[i].Texture.Width, Inventory[i].Texture.Height);
                    x += 40;
                }
                if ((i + 1) % 5 == 0)
                {
                    y += 40;
                    x -= 200;
                }                
            }

            //drag and drop systém
            for (int i = 0; i < Inventory.Count; i++)
            {
                
                if (ItemClicked(Inventory[i], staraMys,mys) && i != ItemOnMove)
                {
                    ItemOnMove = i;
                    itemDragged = true; 
                }
                if (i == ItemOnMove && itemDragged)
                {
                    Inventory[i].Rectangle = new Rectangle(mys.X, mys.Y, Inventory[i].Texture.Width, Inventory[i].Texture.Height);
                }
                for (int j = 0; j < Toolbar.Length; j++)
                {
                    if ((i == ItemOnMove && itemDragged) && Toolbar[j].Rectangle.Contains(mys.X, mys.Y) && (mys.LeftButton == ButtonState.Pressed && staraMys.LeftButton == ButtonState.Released))
                    {
                        Item temp = Inventory[i];
                        Inventory[i] = Toolbar[j];
                        Toolbar[j] = temp;
                        itemDragged = false;
                    }
                }
                SetToolbar(game);
            }            

        }

        private void SetToolbar(Game1 game)
        {
            //nastavení toolbaru
            int x = 13;
            int y = 659;
            
            for (int i = 0; i < Toolbar.Length; i++)
            {                
                if (!Toolbar[i].OnToolbar)
                {
                    Toolbar[i].OnToolbar = true;
                }
                Toolbar[i].Rectangle = new Rectangle(x, y, 48, 48);
                x += 64;
            }

            
        }

        private bool ItemClicked(Item item,MouseState staraMys, MouseState mys )
        {
            return item.Rectangle.Contains(mys.X, mys.Y) && staraMys != mys && mys.LeftButton == ButtonState.Pressed;
        }

        public void DrawItems(SpriteBatch spriteBatch)
        {
            if (InventoryIsShown)
            {
                foreach (Item item in Inventory)
                {
                    item.Draw(spriteBatch);
                }
            }
            foreach (Item item in Toolbar)
            {
                item.Draw(spriteBatch);
            }
            Selected.Draw(spriteBatch);
        }

        public void ShowInventory(bool show)
        {
            InventoryIsShown = show;
        }

        private void SelectedItemUpdate(MouseState mys,MouseState staraMys, KeyboardState key, KeyboardState oldKey,Game1 game)
        {
            //nastavení zvoleného itemu v toolbaru, index zvoleného itemu se uloží do intu SelectedItem
            int x1 = 5;
            int y1 = 651;
            for (int i = 0; i < Toolbar.Length; i++)
            {
                if (ItemClicked(Toolbar[i], staraMys, mys))
                {
                    SelectedItem = i;
                    Selected.Rectangle.X = x1;
                    Selected.Rectangle.Y = y1;                    
                }
                if (SelectedItem == i)
                {
                    Toolbar[i].ItemUpdate(game, key, mys);
                }
                x1 += 64;
            }
        }
    }
}
