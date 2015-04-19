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
        private List<Block> Blocks;

        public Map() 
        {
            Blocks = new List<Block>();
        }

        public Map(params Block[] bloky)
        {
            Blocks = new List<Block>();
            Blocks.AddRange(bloky);
        }

        public void Draw(GraphicsDeviceManager graphics, SpriteBatch spriteBatch)
        {
            foreach (Block item in Blocks)
            {
                item.DrawBlock(spriteBatch);
            }
        }
        public void PridejBLock(Block block)
        {
            Blocks.Add(block);
        }
    }
}
