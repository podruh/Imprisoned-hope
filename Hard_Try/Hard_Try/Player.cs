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

        public int PosX;

        public int PosY;

        public string OnMap;

        //doplnit místo Object typ itemů v inventáři
        public List<Object> Inventory;

        [XmlIgnore]
        List<Texture2D> textures;

        [XmlIgnore]
        float Speed;

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
            SetPlayer(textures[0]);
        }


        

        public void SetPlayer(Texture2D texture)
        {
            this.Texture = texture;
            this.Position = new Microsoft.Xna.Framework.Vector2(PosX, PosX);
            this.Rectangle = new Microsoft.Xna.Framework.Rectangle(PosX, PosY, Texture.Width, Texture.Height);
            this.Color = Color.White;
        }

        public void PlayerUpdate(MouseState mys, MouseState staraMys, KeyboardState keyboard, KeyboardState staraKeyboard, GameTime gameTime, Map map)
        {
            
            Movement(keyboard,gameTime,map);
        }

        public void DrawPlayer(SpriteBatch sb)
        {
            sb.Draw(Texture, Rectangle, Color);
        }

        public void Movement(KeyboardState keyboard,GameTime gameTime, Map map)
        {
            if (keyboard.IsKeyDown(Keys.Up) && !Collides(keyboard,map))
            {
                if (Texture != textures[1])
                {
                    this.Texture = textures[1];
                }
                double elapsed = gameTime.ElapsedGameTime.Milliseconds;
                Position.Y -= (float)(Speed * elapsed);
                Rectangle.Y = (int)Position.Y;
            }
             if (keyboard.IsKeyDown(Keys.Down) && !Collides(keyboard, map))
            {
                if (Texture != textures[0])
                {
                    this.Texture = textures[0];
                }
                double elapsed = gameTime.ElapsedGameTime.Milliseconds;
                Position.Y += (float)(Speed * elapsed);
                Rectangle.Y = (int)Position.Y;
            }
             if (keyboard.IsKeyDown(Keys.Left) && !Collides(keyboard, map))
            {
                //if (Texture != textures[2])
                //{
                //    this.Texture = textures[2];
                //}
                double elapsed = gameTime.ElapsedGameTime.Milliseconds;
                Position.X -= (float)(Speed * elapsed);
                Rectangle.X = (int)Position.X;
            }
             if (keyboard.IsKeyDown(Keys.Right) && !Collides(keyboard, map))
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
            List<Block> bloky = map.GetBlocks();
            foreach (var item in bloky)
            {
                if (item.collide)
                {
                    if (
                        key.IsKeyDown(Keys.Up)
                        && ((this.Rectangle.Left >= item.Rectangle.Left && this.Rectangle.Left <= item.Rectangle.Right) || (this.Rectangle.Right >= item.Rectangle.Left && this.Rectangle.Right <= item.Rectangle.Right))
                        && (this.Position.Y >= item.Rectangle.Bottom && this.Position.Y <= item.Rectangle.Bottom + 3)
                        )
                    {
                        return true;
                    }
                     if (
                        key.IsKeyDown(Keys.Right) 
                        && (this.Position.X+this.Texture.Width >= item.Rectangle.Left - 3 && this.Position.X+this.Texture.Width <= item.Rectangle.Left)
                        && ((this.Rectangle.Top <= item.Rectangle.Bottom && this.Rectangle.Bottom >= item.Rectangle.Top) 
                        //|| (this.Rectangle.Bottom >= item.Rectangle.Top && this.Rectangle.Bottom <= item.Rectangle.Bottom)
                        )
                        )
                    {
                        return true;
                    }
                     if (
                        key.IsKeyDown(Keys.Down) 
                        && ((this.Rectangle.Left >= item.Rectangle.Left && this.Rectangle.Left <= item.Rectangle.Right) || (this.Rectangle.Right >= item.Rectangle.Left && this.Rectangle.Right <= item.Rectangle.Right))
                        && (this.Position.Y + this.Texture.Height >= item.Rectangle.Top - 3 && this.Position.Y + this.Texture.Height <= item.Rectangle.Top)
                        )
                    {
                        return true;
                    }
                     if (
                        key.IsKeyDown(Keys.Left)
                        && (this.Position.X <= item.Rectangle.Right + 3 && this.Position.X >= item.Rectangle.Right)
                        && ((this.Rectangle.Top <= item.Rectangle.Bottom && this.Rectangle.Bottom >= item.Rectangle.Top)
                        //|| (this.Rectangle.Bottom >= item.Rectangle.Top && this.Rectangle.Bottom <= item.Rectangle.Bottom)
                        )
                        )
                    {
                        return true;
                    }

                }
                else
                {
                    return false;
                }
            } 
            
            return false;          
        }
    }
}
