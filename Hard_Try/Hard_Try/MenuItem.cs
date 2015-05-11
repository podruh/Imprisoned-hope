using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imprisoned_Hope
{
    public class MenuItem : Sprite
    {
        public MenuItem(Texture2D texture, Rectangle rectangle, Color color)
        {
            this.Texture = texture;
            this.Rectangle = rectangle;
            this.Position = new Vector2(rectangle.X, rectangle.Y);
            this.Color = color;
        }

        private MouseState staraMys;

        public bool isClicked(MouseState mys)//zjištění jestli uživatel klikne na item
        {
            if (this.Rectangle.Contains(mys.X, mys.Y) && mys.LeftButton == ButtonState.Pressed&& staraMys!=mys)
            {
                staraMys = mys;
                return true;
            }
            else
            {
                staraMys = mys;
                return false;
            }
        }

    }
}
