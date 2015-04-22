using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imprisoned_Hope
{
    [Serializable()]
    public class Map
    {
        private int PosunX, PosunY;
        
        private List<Block> Blocks;

        public Map() 
        {
            Blocks = new List<Block>();
            PosunX = 0;
            PosunY = 0;
        }


        public void Draw(GraphicsDeviceManager graphics, SpriteBatch spriteBatch)
        {
            foreach (Block item in Blocks)
            {
                item.DrawBlockLine(spriteBatch, PosunX, PosunY);
            }
        }
    }
}
