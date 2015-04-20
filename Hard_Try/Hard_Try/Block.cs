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

        public void DrawBlock(SpriteBatch spriteBatch, int x,int y)
        {
            if (Lighted)
            {
                spriteBatch.Draw(Texture, new Rectangle(x,y,Rectangle.Width,Rectangle.Height), Color);
            }
            else
            {
                spriteBatch.Draw(Shadowed, new Rectangle(x, y, Rectangle.Width, Rectangle.Height), Color);
            }
        
        }
        public void DrawBlockLine(SpriteBatch spriteBatch)
        {
            int x = this.Rectangle.X;
            int y = this.Rectangle.Y;
            for (int i = 1; i <= Count; i++)
            {
                DrawBlock(spriteBatch, x, y);
                switch (Direction)
                {
                    case "up":
                        y -= 32;
                        break;
                    case "down":
                        y += 32;
                        break;
                    case"left":
                        x -= 32;
                        break;
                    case "right":
                        x += 32;
                        break;
                    default:
                        break;
                } 
            }  
        }
        

    }
}
