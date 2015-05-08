using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imprisoned_Hope
{
    public partial class MapManager
    {

        public MapManager(Game1 game)
        {
            Hra = game;
            MapList = new List<Map>();
            BlockList = new List<Block>();
            TypeList = new List<string>();
            TextureList = new List<Texture2D>();
            SetTypesAndTextures();
            
        }

        public void SetTypesAndTextures()
        {
            TextureList.Add(Hra.Content.Load<Texture2D>(@"Textury\Brick Wall"));
            TypeList.Add("wall");
        }

        public List<Map> GetMaps()
        {
            return MapList;
        }

    }
}
