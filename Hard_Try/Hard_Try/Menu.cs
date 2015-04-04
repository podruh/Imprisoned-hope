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
		public int DockX, DockY;//pozice, kde se menu zastaví při pohybu
		public string MenuDirection = "none";//jaký pohyb menu koná
		/*
		 bere celý list objektů MenuItem, Rectangle který patří Menu a rychlost pohybu
		 */
		/// <summary>
		/// Vytvoří menu s připraveným listem
		/// </summary>
		/// <param name="list">Dynamické pole MenuItem</param>
		/// <param name="rect">Rectangle s pozicí a rozměry</param>
		/// <param name="speed">rychlost pohybu menu ve floatu</param>
		public Menu(List<MenuItem> list, Rectangle rect, float speed)
		{
			this.MenuItems.AddRange(list);
			this.Rectangle = rect;
			this.Position = new Vector2(rect.X, rect.Y);
			this.Speed = speed;
		}

		/// <summary>
		/// bere list textur, ze kterých si pak udělá obejkty MenuItems
		/// nastaví si podle položek šířku a výšku
		/// bere rovnou i dockovací pozici
		/// </summary>
		/// <param name="list"></param>
		/// <param name="rect"></param>
		/// <param name="speed"></param>
		/// <param name="dockX">Pozice X kde se menu zastaví</param>
		/// <param name="dockY">Pozice Y kde se menu zastaví</param>
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
				if (list[i].Width > width)//nastavení šířky menu
				{
					width = list[i].Width;
				}
				
			}
			this.Rectangle.Width = width;
			this.Rectangle.Height = height;                        
		}
		/// <summary>
		/// Přidá také texturu k menu - netestováno
		/// </summary>
		/// <param name="Texture">textura menu</param>
		/// <param name="list"></param>
		/// <param name="rect"></param>
		/// <param name="speed"></param>
		/// <param name="dockX">Pozice X kde se menu zastaví</param>
		/// <param name="dockY">Pozice Y kde se menu zastaví</param>
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
        /// <summary>
        /// Pro menu NewGame menu orientované po ose X
        /// </summary>
        /// <param name="Texture">textura pozadí</param>
        /// <param name="list">List s texturami</param>
        /// <param name="rect">Rect pozadí (asi)</param>
        /// <param name="speed">Rychlos posunu (float)</param>
        /// <param name="dockX">Pozice X kde se menu zastaví</param>
        /// <param name="dockY">Pozice Y kde se menu zastaví</param>
        /// <param name="odstupX">Odsazení od textury</param>
        /// <param name="odstupY">Odsazení od textury</param>
        /// <param name="mezera">Mezera mezi ikonami</param>
        public Menu(Texture2D Texture, List<Texture2D> list, Rectangle rect, float speed, int dockX, int dockY, int odstupX, int odstupY, int mezera)
        {
            this.Texture = Texture;
            this.Rectangle = rect;
            this.Position = new Vector2(rect.X, rect.Y);
            this.Speed = speed;
            this.DockX = dockX;
            this.DockY = dockY;
            int x = rect.X + odstupX;
            int y = rect.Y;
            int width = 0;
            int height = 0;
            for (int i = 0; i < list.Count; i++)
            {
                MenuItems.Add(new MenuItem(list[i], new Rectangle(x, y + odstupY, list[i].Width, list[i].Height), Color.White));
                x += list[i].Height + mezera;
                width += list[i].Width + mezera;
                if (list[i].Height > height)
                {
                    height = list[i].Height;
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
			if (MenuDirection == "up" &&  canMove(MenuDirection))//jestliže je validní hodnota Movement a jestli se může menu s daném směru pohybovat dál
			{
				double elapsed = gameTime.ElapsedGameTime.TotalMilliseconds;
				Position.Y -= (float)(Speed * elapsed);
				Rectangle.Y = (int)Position.Y;
				updateItemsPosition();//nastaví všem menuItems stejné souřadnice
			}
			if (MenuDirection == "down" && canMove(MenuDirection))
			{
				double elapsed = gameTime.ElapsedGameTime.TotalMilliseconds;
				Position.Y += (float)(Speed * elapsed);
				Rectangle.Y = (int)Position.Y;
				updateItemsPosition();
			}
			if (MenuDirection == "left" && canMove(MenuDirection))
			{
				double elapsed = gameTime.ElapsedGameTime.TotalMilliseconds;
				Position.X -= (float)(Speed * elapsed);
				Rectangle.X = (int)Position.X;
				updateItemsPosition();
			}
			if (MenuDirection == "right" && canMove(MenuDirection))
			{
				double elapsed = gameTime.ElapsedGameTime.TotalMilliseconds;
				Position.X += (float)(Speed * elapsed);
				Rectangle.X = (int)Position.X;
				updateItemsPosition();
			}          
				
		}
		public bool canMove(string dir)//zjistění jestli není menu už mimo hranice okna nebo pozice kde má být
		{
			if (dir == "left" && ((Position.X + Rectangle.Width < 0)|| Rectangle.X <= DockX)) //vrátí false když bude menu mimo okno nebo v pozici dockování
			{
				MenuDirection = "none";
				return false;
			}
			else
			{
				if (dir == "right" && ((Position.X > 1280) || Rectangle.X >= DockX))
				{
					MenuDirection = "none";
					return false;
				}
				else
				{
					if (dir == "up" && ((Position.Y + Rectangle.Height < 0) || Rectangle.Y <= DockY))
					{
						MenuDirection = "none";
						return false;
					}
					else
					{
						if (dir == "down" && ((Position.Y > 720) || Rectangle.Y >= DockY))
						{
							MenuDirection = "none";
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
		public void changeMovement(string requstedMove) // hlídá jestli může změnít směr pohybu
		{
			if (canMove(requstedMove))
			{
				MenuDirection = requstedMove;
			}
		}
		public void DrawMenu(GraphicsDeviceManager graphics, SpriteBatch spriteBatch)
		{
			//spriteBatch.Draw(Texture, Rectangle, Color);

			//vykreslení menu a jeho textury
			if (Texture != null)
			{
				spriteBatch.Draw(Texture, Rectangle, Color.White);    
			}
			
			//vykreslení položek
			foreach (MenuItem i in MenuItems)
			{
				i.Draw(graphics, spriteBatch);
			}
		}
	}
}
