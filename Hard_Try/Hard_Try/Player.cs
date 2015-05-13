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

        [XmlIgnore]
        public List<Item> Inventory;

        [XmlIgnore]
        List<Texture2D> textures;

        [XmlIgnore]
        float Speed;

        [XmlIgnore]
        Texture2D HealthTexture;
        [XmlIgnore]
        Texture2D StaminaTexture;

        private int PX,PY;

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

        public Player(Game1 game, int health,int stamina, string klasa, List<int> items, Map map)
        {
            //doplnění listu textures
            textures = new List<Texture2D>();
            textures.Add(game.Content.Load<Texture2D>(@"Textury\Hero"));
            textures.Add(game.Content.Load<Texture2D>(@"Textury\Hero Up"));
            //nastavení ostatních hodnot
            this.Health = health;
            this.Stamina = stamina;
            Speed = 0.2F;            
            StaminaTexture = game.Content.Load<Texture2D>(@"Textury\Stamina1");
            HealthTexture = game.Content.Load<Texture2D>(@"Textury\Health1");
            Class = klasa;
            Inventory_ID = items;
            SetPlayer(textures[0], map);
            SetItems(game);
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
                switch (id)
                {
                    case 0:
                        Inventory.Add(new Item(game.Content.Load<Texture2D>(@"Textury\Objects\spawn"), new Rectangle(0, 0, 32, 32), Color.White,false));
                        break;
                    case 1:
                        Inventory.Add(new Item(game.Content.Load<Texture2D>(@"Textury\Items\food"), new Rectangle(0, 0, 32, 32), Color.White,true));
                        break;
                    case 2:
                        Inventory.Add(new Item(game.Content.Load<Texture2D>(@"Textury\Items\food"), new Rectangle(0, 0, 32, 32), Color.White, false));
                        break;
                    case 3:
                        Inventory.Add(new Item(game.Content.Load<Texture2D>(@"Textury\Items\Drink"), new Rectangle(0, 0, 32, 32), Color.White, true));
                        break;
                    case 4:
                        Inventory.Add(new Item(game.Content.Load<Texture2D>(@"Textury\Items\Drink"), new Rectangle(0, 0, 32, 32), Color.White, false));
                        break;
                    default:
                        break;
                }
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

        public void PlayerUpdate(MouseState mys, MouseState staraMys, KeyboardState keyboard, KeyboardState staraKeyboard, GameTime gameTime, Map map)
        {
            OnMap = map.Name;
            this.PX = map.GetPosunX();
            this.PY = map.GetPosunY();
            PosX = Rectangle.X;
            PosY = Rectangle.Y;
            Movement(keyboard, gameTime, map);
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
            int x = 1268;
            int y = 693;
            for (int i = 1; i <= Health; i++)
            {
                spriteBatch.Draw(HealthTexture, new Rectangle(x, y, HealthTexture.Width, HealthTexture.Height), Color.White);
                x -= 2;
            }

            x = 1268;
            y = 663;
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
    }
}
