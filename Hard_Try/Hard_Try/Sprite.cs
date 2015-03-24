using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hard_Try
{
    public class Sprite
    {
        public Texture2D Texture;
        public Rectangle Rectangle;
        public Vector2 Position;
        public Color Color;

        public Sprite(Texture2D texture, Rectangle rectangle, Color color)
        {
            this.Texture = texture;
            this.Rectangle = rectangle;
            this.Position = new Vector2(rectangle.X, rectangle.Y);
            this.Color = color;
        }

        public void Draw(GraphicsDeviceManager graphics, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Rectangle, Color);
        }
    }
}
