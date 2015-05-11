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

        public MapManager(Game1 game, List<Map> maps)
        {
            Hra = game;
            MapList = maps;
            BlockList = new List<Block>();
            TypeList = new List<string>();
            TextureList = new List<Texture2D>();
            SetTypesAndTextures();
        }

        public void SetTypesAndTextures()
        {
            TextureList.Add(Hra.Content.Load<Texture2D>(@"Textury\Objects\spawn"));
            TextureList.Add(Hra.Content.Load<Texture2D>(@"Textury\Objects\Brick Wall"));
            TextureList.Add(Hra.Content.Load<Texture2D>(@"Textury\Objects\floor1"));
            TextureList.Add(Hra.Content.Load<Texture2D>(@"Textury\Objects\floor2"));
            TextureList.Add(Hra.Content.Load<Texture2D>(@"Textury\Objects\floor3"));
            TextureList.Add(Hra.Content.Load<Texture2D>(@"Textury\Objects\floor4"));
            TextureList.Add(Hra.Content.Load<Texture2D>(@"Textury\Objects\grayBrick"));
            TextureList.Add(Hra.Content.Load<Texture2D>(@"Textury\Objects\grayBrick2"));
            TextureList.Add(Hra.Content.Load<Texture2D>(@"Textury\Objects\bedHead"));
            TextureList.Add(Hra.Content.Load<Texture2D>(@"Textury\Objects\bedFeet"));
            TextureList.Add(Hra.Content.Load<Texture2D>(@"Textury\Objects\JailDoors"));
            TextureList.Add(Hra.Content.Load<Texture2D>(@"Textury\Objects\JailDoors2"));
            TextureList.Add(Hra.Content.Load<Texture2D>(@"Textury\Objects\glass"));
            TextureList.Add(Hra.Content.Load<Texture2D>(@"Textury\Objects\ironBars"));
            TextureList.Add(Hra.Content.Load<Texture2D>(@"Textury\Objects\note"));
            TextureList.Add(Hra.Content.Load<Texture2D>(@"Textury\Objects\newspapers"));
            TextureList.Add(Hra.Content.Load<Texture2D>(@"Textury\Objects\map"));
            TypeList.Add("Spwan");
            TypeList.Add("wall");
            TypeList.Add("Floor 1");
            TypeList.Add("Floor 2");
            TypeList.Add("Floor 3");
            TypeList.Add("Floor 4");
            TypeList.Add("Gray Brick Wall");
            TypeList.Add("Gray Brick Wall 2");
            TypeList.Add("Bed Head");
            TypeList.Add("Bed Feet");
            TypeList.Add("Jail Doors");
            TypeList.Add("Jail Doors 2");
            TypeList.Add("Glass");
            TypeList.Add("Iron Bars");
            TypeList.Add("Note");
            TypeList.Add("Newspapers");
            TypeList.Add("Map");
        }

        public List<Map> GetMaps()
        {
            return MapList;
        }

        public void SetBlocksInAllMaps()
        {
            foreach (Map map in MapList)
            {
                foreach (Block item in map.Blocks)
            {
                item.SetTextures(GetTexture2DByType(item.Type));               
            }
            }
        }
    }
}
