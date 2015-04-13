using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imprisoned_Hope
{
    class Block : Sprite
    {
        private Texture2D Shadowed;
        private string Direction;
        private int Count;
        private bool Lighted;
        public Block(Texture2D texture, Texture2D shadowed, Rectangle rectangle, Color color)
        {
            this.Texture = texture;
            this.Shadowed = shadowed;
            this.Rectangle = rectangle;
            this.Color = color;
        }
        public void DrawBlock(GraphicsDeviceManager graphics, SpriteBatch spriteBatch)
        {
            if (Lighted)
            {
                spriteBatch.Draw(Texture, Rectangle, Color);
            }
            else
            {
                spriteBatch.Draw(Shadowed, Rectangle, Color);
            }
        
        }
    }
}
