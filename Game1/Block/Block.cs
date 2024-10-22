﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace Imprisoned_Hope
{
    [Serializable()]
    [XmlInclude(typeof(BlockWall))]
    [XmlInclude(typeof(BlockFloor))]
    [XmlInclude(typeof(BlockContainer))]
    [XmlInclude(typeof(BlockNote))]
    [XmlInclude(typeof(BlockDoor))]
    public partial class Block : Sprite
    {
        public string Type;
        public int X;
        public int Y;
        public int Count;
        public string Direction;
        public bool collide = true;
        [XmlIgnore]
        public bool Lighted;
        
        public Block(){}
        public Block(Texture2D texture,string type, Rectangle rectangle, Color color, bool col)
        {
            this.Texture = texture;
            this.Type = type;
            this.Rectangle = rectangle;
            this.X = rectangle.X;
            this.Y = rectangle.Y;
            this.Color = color;
            Count = 1;
            Lighted = false;
            collide = col;
        }

        public Block(Texture2D texture,string type, Rectangle rectangle, Color color,string direction,int count)
        {
            this.Texture = texture;;
            this.Type = type;
            this.Rectangle = rectangle;
            this.X = rectangle.X;
            this.Y = rectangle.Y;
            this.Color = color;
            this.Direction = direction;
            this.Count = count;
            Lighted = false;
        }

        public void DrawBlock(SpriteBatch spriteBatch, int x,int y)
        {
                spriteBatch.Draw(Texture, new Rectangle(x, y, Rectangle.Width, Rectangle.Height), Color);
        }
        
        public void DrawBlockLine(SpriteBatch spriteBatch, int posunX,int posunY)
        {
            int x = this.Rectangle.X + posunX;
            int y = this.Rectangle.Y + posunY;
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
        /// <summary>
        /// nastaví hodnoty po načtení z xml souboru
        /// </summary>
        /// <param name="normal"></param>
        /// <param name="shadowed"></param>
        public void SetTextures(Texture2D normal)
        {
            this.Texture = normal;
            this.Position = new Vector2(X, Y);
            this.Rectangle = new Rectangle(X, Y, 32, 32);
            this.Color = Color.White;
            
            Lighted = false;
        }
        

    }
}
