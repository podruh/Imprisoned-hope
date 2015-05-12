using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        public string Name;

        public Item()
        { 
            
        }

        public Item(Texture2D texture, Rectangle rectangle, Color color)
        {
            this.Texture = texture;
            this.Rectangle = rectangle;
            this.Position = new Vector2(rectangle.X, rectangle.Y);
            this.Color = color;
        }

        public void SetCoordinates(int x, int y)
        {
            this.Rectangle.X = x;
            this.Rectangle.Y = y;
        }
    }
}
