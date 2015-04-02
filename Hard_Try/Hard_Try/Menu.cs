using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imprisoned_Hope
{
    public class Menu : Sprite
    {
        public List<MenuItem> MenuItems= new List<MenuItem>();
        public float Speed; // rychlost pohybu menu
        public int DockX, DockY;
        public string Movement = "none";

        public Menu(List<MenuItem> list, Rectangle rect, float speed)
        {
            this.MenuItems.AddRange(list);
            this.Rectangle = rect;
            this.Position = new Vector2(rect.X, rect.Y);
            this.Speed = speed;
        }
        
        public Menu(List<Texture2D> list, Rectangle rect, float speed, int dockX, int dockY)
        {
            this.Rectangle = rect;
            this.Position = new Vector2(rect.X, rect.Y);
            this.Speed = speed;
            this.DockX = dockX;
            this.DockY = dockY;
            int x = rect.X;
            int y = rect.Y;
            int width = 0;
            int height = 0;
            for (int i = 0; i < list.Count; i++)
            {
                MenuItems.Add(new MenuItem(list[i], new Rectangle(x, y, list[i].Width, list[i].Height), Color.White));
                y += list[i].Height;
                height += list[i].Height;
                if (list[i].Width > width)
                {
                    width = list[i].Width;
                }
                
            }
            this.Rectangle.Width = width;
            this.Rectangle.Height = height;                        
        }

        public Menu(Texture2D Texture, List<Texture2D> list, Rectangle rect, float speed, int dockX, int dockY)
        {
            this.Texture = Texture;
            this.Rectangle = rect;
            this.Position = new Vector2(rect.X, rect.Y);
            this.Speed = speed;
            this.DockX = dockX;
            this.DockY = dockY;
            int x = rect.X;
            int y = rect.Y;
            int width = 0;
            int height = 0;
            for (int i = 0; i < list.Count; i++)
            {
                MenuItems.Add(new MenuItem(list[i], new Rectangle(x, y, list[i].Width, list[i].Height), Color.White));
                y += list[i].Height;
                height += list[i].Height;
                if (list[i].Width > width)
                {
                    width = list[i].Width;
                }

            }
            this.Rectangle.Width = width;
            this.Rectangle.Height = height;
        }


        public void updateItemsPosition()//nastaví všem itemům pozici aby byli pod sebou a se stejným začátkem jako objekt menu
        {
            int x = this.Rectangle.X;
            int y = this.Rectangle.Y;
            
            for (int i = 0; i < MenuItems.Count; i++)
            {
                MenuItems[i].Rectangle.X = x;
                MenuItems[i].Rectangle.Y = y;
                y += MenuItems[i].Texture.Height;                                
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
        public void moveMenu(GameTime gameTime) //kontrola směru pohybu a možnosti dalšího pohybu ve směru movement
        {
            if (Movement == "up" &&  canMove(Movement))
            {
                double elapsed = gameTime.ElapsedGameTime.TotalMilliseconds;
                Position.Y -= (float)(Speed * elapsed);
                Rectangle.Y = (int)Position.Y;
                updateItemsPosition();//nastaví všem menuItems stejné souřadnice
            }
            if (Movement == "down" && canMove(Movement))
            {
                double elapsed = gameTime.ElapsedGameTime.TotalMilliseconds;
                Position.Y += (float)(Speed * elapsed);
                Rectangle.Y = (int)Position.Y;
                updateItemsPosition();
            }
            if (Movement == "left" && canMove(Movement))
            {
                double elapsed = gameTime.ElapsedGameTime.TotalMilliseconds;
                Position.X -= (float)(Speed * elapsed);
                Rectangle.X = (int)Position.X;
                updateItemsPosition();
            }
            if (Movement == "right" && canMove(Movement))
            {
                double elapsed = gameTime.ElapsedGameTime.TotalMilliseconds;
                Position.X += (float)(Speed * elapsed);
                Rectangle.X = (int)Position.X;
                updateItemsPosition();
            }          
                
        }
        public bool canMove(string dir)//zjistění jestli není menu už mimo hranice okna nebo pozice kde má být
        {
            if (dir == "left" && ((Position.X + Rectangle.Width < 0)|| Rectangle.X <= DockX)) // 
            {
                Movement = "none";
                return false;
            }
            else
            {
                if (dir == "right" && ((Position.X > 1280) || Rectangle.X >= DockX))
                {
                    Movement = "none";
                    return false;
                }
                else
                {
                    if (dir == "up" && ((Position.Y + Rectangle.Height < 0) || Rectangle.Y <= DockY))
                    {
                        Movement = "none";
                        return false;
                    }
                    else
	                {
                        if (dir == "down" && ((Position.Y > 720) || Rectangle.Y >= DockY))
                        {
                            Movement = "none";
                            return false;
                        }
                        else
                        {
                            return true;
                        }  
	                }
                }
            }
                                 
            
        }
        public void changeMovement(string move)
        {
            if (canMove(move))
            {
                Movement = move;
            }
        }
    }
}
