using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Top_Down_Management
{
    public class Tile
    {
        public enum TileType
        {
            Grass,
            Dirt,
            Rock,
            Water
        }
        public TileType tileType = new TileType();
        public List<Texture2D> textures = new List<Texture2D>();
        private int durability;
        private bool alive;

        public Tile()
        {
            alive = true;

            durability = 10;
        }

        public void LoadContent(ContentManager content)
        {
            textures.Add(content.Load<Texture2D>("Tiles/DryTile1")); // 0
            textures.Add(content.Load<Texture2D>("Tiles/DryTile2")); // 1
            textures.Add(content.Load<Texture2D>("Tiles/DryTile3")); // 2 
            textures.Add(content.Load<Texture2D>("Tiles/Granite1")); // 3
            textures.Add(content.Load<Texture2D>("Tiles/Granite2")); // 4
            textures.Add(content.Load<Texture2D>("Tiles/Granite3")); // 5
            textures.Add(content.Load<Texture2D>("Tiles/Grass1"));   // 6
            textures.Add(content.Load<Texture2D>("Tiles/Grass2"));   // 7
            textures.Add(content.Load<Texture2D>("Tiles/Grass3"));   // 8
            textures.Add(content.Load<Texture2D>("Tiles/Water1"));   // 9
        }
        public bool IsAlive()
        {
            return alive;
        }

        public void Update(GameTime gameTime)
        {
            if (durability > 0)
            {

                if (durability == 0)
                {
                    alive = false;
                }
            }

        }

    }
}