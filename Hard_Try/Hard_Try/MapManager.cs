using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Xml.Serialization;
using System.IO;

namespace Imprisoned_Hope
{
    public class MapManager
    {
        private List<Map> MapList;

        private List<Block> BlockList;

        private List<string> TypeList;

        private List<Texture2D> TextureList;

        private Game1 Hra;

        private BuilderComponent BC;

        public MapManager(List<Map> maps, List<string> types, List<Texture2D> textures, Game1 game)
        {
            this.MapList = maps;
            this.TypeList = types;
            this.TextureList = textures;
            Hra = game;
        }

        public MapManager(List<Map> maps, List<string> types, List<Texture2D> textures, BuilderComponent bc)
        {
            this.MapList = maps;
            this.TypeList = types;
            this.TextureList = textures;
            this.BC = bc;
        }

        public void Ulozit()
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(MapList.GetType());
                StreamWriter sw = new StreamWriter("maps.xml");
                ser.Serialize(sw, MapList);
                sw.Close();
            }
            catch (Exception ex)
            {
                if (BC != null)
                {
                    BC.Message(ex.Message);
                }
                else
                {
                    throw;
                }
                
            }
        }
        public void Nahrat()
        {
            try
            {
                if (File.Exists("maps.xml"))
                {
                    XmlSerializer ser = new XmlSerializer(MapList.GetType());
                    StreamReader sr = new StreamReader("map.xml");
                    MapList = (List<Map>)ser.Deserialize(sr);


                    sr.Close();
                }
            }
            catch (Exception ex)
            {
                if (BC != null)
                {
                    BC.Message(ex.Message);
                }
                else
                {
                    throw;
                }
                
            }
        }

        public Map GetMapByName(string name)
        {
            foreach (Map map in MapList)
            {
                if (map.Name == name)
                {
                    return map;
                }
            }
            return null;
        }
        public List<string> GetMapNameList()
        {
            List<string> names = new List<string>();
            foreach (Map map in MapList)
            {
                names.Add(map.Name);
            }
            return names;
        }
        public string[] GetMapNameArray()
        {
            string[] names = new string[MapList.Count];
            int i = 0;
            foreach (Map map in MapList)
            {
                names[i] = map.Name;
                i++;
            }
            return names;
        }
    }
}
