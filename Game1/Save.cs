using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Xml.Serialization;

namespace Imprisoned_Hope
{
    [Serializable()]
    public class Save
    {
        public Player Player;

        public List<int> Toolbar;

        public List<Map> Maplist;

        public string Name;

        [XmlIgnore]
        private MapManager manager;

        public Save()
        {
            manager = new MapManager();
        }

        public Save(Player player, MapManager MP, string name)
        {
            this.Player = player;
            this.Maplist = MP.GetMaps();
            this.Name = name;
            this.manager = MP;
        }

        public void SetPlayer(Texture2D texture)
        {
            //Player.SetPlayer(texture);
        }
        public void SetMapManager(MapManager manager)
        {
            this.manager = manager;
        }
    }
}
