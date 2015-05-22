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
    [XmlInclude(typeof(Item))]
    [XmlInclude(typeof(FoodItem))]
    [XmlInclude(typeof(DrinkItem))]
    [XmlInclude(typeof(KeyItem))]
    [XmlInclude(typeof(AidKitItem))]
    [XmlInclude(typeof(ToolItem))]
    [XmlInclude(typeof(WeaponItem))]
    public class Item : Sprite
    {
        public string Type;

        public int ID;

        public string Name;

        public bool OnToolbar;

        public Item()
        { 
            
        }
        public Item(Texture2D texture, Rectangle rectangle, Color color, bool toolbar,string type, string name)
        {
            this.Texture = texture;
            this.Rectangle = rectangle;
            this.Position = new Vector2(rectangle.X, rectangle.Y);
            this.Color = color;
            OnToolbar = toolbar;
            this.Type = type;
            this.Name = name;
        }

        public void SetCoordinates(int x, int y)
        {
            this.Rectangle.X = x;
            this.Rectangle.Y = y;
        }

        public virtual void ItemUpdate(Game1 game, KeyboardState key, MouseState mys)
        { 
        
        }
    }
}
