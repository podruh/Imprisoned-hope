using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imprisoned_Hope
{
    public class Menu : Sprite
    {
        public List<MenuItem> MenuItems;
        public float Speed;

        public Menu(List<MenuItem> list, Rectangle rect, float speed)
        {
            this.MenuItems.AddRange(list);
            this.Rectangle = rect;
            this.Position = new Vector2(rect.X, rect.Y);
            this.Speed = speed;
        }

        public void updateItemsPosition()//nastaví všem itemům pozici aby byli pod sebou a se stejným začátkem jako objekt menu
        {
            int x = this.Rectangle.X;
            int y = this.Rectangle.Y;
            for (int i = 0; i < MenuItems.Count; i++)
            {
                MenuItems[i].Rectangle = new Rectangle(x, y, MenuItems[i].Texture.Width, MenuItems[i].Texture.Height);                
                y += MenuItems[i].Texture.Width;
                
            }
        }

        public bool anyItemClicked(MouseState mys)//jestliže uživatel klikne na jakékoliv tlačítko/item
        {
            int i = 0;
            foreach (MenuItem item in MenuItems)
            {
                if (item.isClicked(mys))
                {
                    i++;
                }
            }
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void moveMenu(GameTime gameTime, string direction) //pohyby :D
        {
            if(offLimits() == false)
            { 
                if(direction == "up")
                { 
                    double elapsed = gameTime.ElapsedGameTime.TotalMilliseconds;
                    Position.Y -= (float)(Speed * elapsed);
                    Rectangle.Y = (int)Position.Y;
                    updateItemsPosition();
                }
                if (direction == "down")
                {
                    double elapsed = gameTime.ElapsedGameTime.TotalMilliseconds;
                    Position.Y += (float)(Speed * elapsed);
                    Rectangle.Y = (int)Position.Y;
                    updateItemsPosition();
                }
                if (direction == "left")
                {
                    double elapsed = gameTime.ElapsedGameTime.TotalMilliseconds;
                    Position.X -= (float)(Speed * elapsed);
                    Rectangle.X = (int)Position.X;
                    updateItemsPosition();               
                }
                if (direction == "right")
                {
                    double elapsed = gameTime.ElapsedGameTime.TotalMilliseconds;
                    Position.X += (float)(Speed * elapsed);
                    Rectangle.X = (int)Position.X;
                    updateItemsPosition();
                }
            }
        }
        public bool offLimits()//zjistění jestli není menu už mimo hranice okna
        {
            if (Position.X + Rectangle.Height < 0)
            {
                return true;
            }
            else
            {
                if (Position.X > 720)
                {
                    return true;
                }
                else
                {
                    if (Position.Y + Rectangle.Width < 0)
                    {
                        return true;
                    }
                    else
                    {
                        if(Position.Y > 1280)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            
        }
    }
}
