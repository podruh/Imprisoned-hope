using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imprisoned_Hope
{
    public partial class Map
    {
        public List<Block> GetBlocks()
        {
            List<Block> bloky = new List<Block>();
            int x, y;
            foreach (Block item in Blocks)
            {
                x = item.Rectangle.X;
                y = item.Rectangle.Y;
                for (int i = 1; i <= item.Count; i++)
                {
                    bloky.Add(new Block(item.Texture, item.Type, new Rectangle(x, y, item.Texture.Width, item.Texture.Height), item.Color, item.collide));
                    switch(item.Direction)
                    {
                    case "up":                            
                        y -= 32;
                        continue;
                    case "down":
                        y += 32;
                        continue;
                    case"left":
                        x -= 32;
                        continue;
                    case "right":
                        x += 32;
                        continue;
                    default:
                        continue;
                    } 
                }
            }
            return bloky;
        }
    }
}
