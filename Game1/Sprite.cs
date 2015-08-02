using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace Imprisoned_Hope
{
    public class Sprite
    {
        [XmlIgnore]
        public Texture2D Texture;
        [XmlIgnore]
        public Rectangle Rectangle;
        [XmlIgnore]
        public Vector2 Position;
        [XmlIgnore]
        public Color Color;

        public Sprite() { }

        public Sprite(Texture2D texture, Rectangle rectangle, Color color)
        {
            this.Texture = texture;
            this.Rectangle = rectangle;
            this.Position = new Vector2(rectangle.X, rectangle.Y);
            this.Color = color;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Rectangle, Color);
        }
    }
}
