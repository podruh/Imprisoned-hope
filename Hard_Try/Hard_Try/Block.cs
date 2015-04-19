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

        public Block() { }
        public Block(Texture2D texture, Texture2D shadowed, Rectangle rectangle, Color color)
        {
            this.Texture = texture;
            this.Shadowed = shadowed;
            this.Rectangle = rectangle;
            this.Color = color;
            Count = 1;
            Lighted = false;
        }

        public Block(Texture2D texture, Texture2D shadowed, Rectangle rectangle, Color color,string direction,int count)
        {
            this.Texture = texture;
            this.Shadowed = shadowed;
            this.Rectangle = rectangle;
            this.Color = color;
            this.Direction = direction;
            this.Count = count;
            Lighted = false;
        }

        public void DrawBlock( SpriteBatch spriteBatch)
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
