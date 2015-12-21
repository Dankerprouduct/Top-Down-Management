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
using System.Threading;

namespace Top_Down_Management
{
    public class TileMap
    {
        private int[,] mapAttributes;
        private int[,] mapSize;
        private Random random;

        private List<int> tileTypes = new List<int>()
        {
            8,
            2,
            5,
        };
        // lists
        private List<Tile> tiles = new List<Tile>();
        KeyboardState keyboardState;
        KeyboardState oldKeyoardState;
        public TileMap(int[,] size)
        {
            mapSize = size;
            mapAttributes = mapSize;
            Console.WriteLine("Map Size: " + mapSize.Length);
            Console.WriteLine("Map Attribute Size: " + mapAttributes.Length);
            random = new Random();

            Console.WriteLine("map size" + mapSize.Length.ToString());

            int range = random.Next(5, 15);


            int mapCount = 0;

            for (int x = 0; x < mapSize.GetLength(0); x++)
            {
                for (int y = 0; y < mapSize.GetLength(1); y++)
                {
                    mapSize[x, y] = mapCount;
                    mapAttributes[x, y] = 0;
                    mapCount++;
                }
            }
            PreGeneration();

        }

        public void LoadContent(ContentManager content)
        {

            foreach (int i in mapSize)
            {
                tiles.Add(new Tile());
            }

            foreach (Tile ti in tiles)
            {
                ti.LoadContent(content);
            }
        }

        private void PreGeneration()
        {




            random = new Random();
            // was 80 - 120 
            int range = (mapSize.Length / 49) * 3;
            Console.WriteLine(range);
            for (int i = 0; i < range; i++)
            {
                float percentComplete = (i / range) * 100;
                Console.WriteLine(i + "/" + range + " Loaded");
                Thread.Sleep(100);
                random = new Random();
                int tileWidth = random.Next(0, mapAttributes.GetLength(0));

                int tileHeight = random.Next(0, mapAttributes.GetLength(1));

                int maxOffset = random.Next(3, 4);
                int index = random.Next(0, tileTypes.Count);
                int climax = tileTypes[index];

                // tileWidth = 4;
                //  tileHeight = 4; 

                mapAttributes[tileWidth, tileHeight] = climax - maxOffset + 1;
                ///////////////////////////

                while (maxOffset > 0)
                {
                    // horizontal & verticle
                    if ((tileHeight - maxOffset < mapAttributes.GetLength(1)) && ((tileHeight - maxOffset >= 0)))
                    {
                        mapAttributes[tileWidth, tileHeight - maxOffset] = climax;
                    }

                    if ((tileHeight + maxOffset < mapAttributes.GetLength(1)) && (tileHeight + maxOffset >= 0))
                    {
                        mapAttributes[tileWidth, tileHeight + maxOffset] = climax;
                    }

                    if ((tileWidth - maxOffset < mapAttributes.GetLength(0)) && ((tileWidth - maxOffset >= 0)))
                    {
                        mapAttributes[tileWidth - maxOffset, tileHeight] = climax;
                    }

                    if ((tileWidth + maxOffset < mapAttributes.GetLength(0)) && ((tileWidth + maxOffset >= 0)))
                    {
                        mapAttributes[tileWidth + maxOffset, tileHeight] = climax;
                    }


                    // diagnals
                    //  mapAttributes[tileWidth - maxOffset, tileHeight - maxOffset] = climax;s
                    //  mapAttributes[tileWidth + maxOffset, tileHeight - maxOffset] = climax;
                    //   mapAttributes[tileWidth - maxOffset, tileHeight + maxOffset] = climax;
                    //   mapAttributes[tileWidth + maxOffset, tileHeight + maxOffset] = climax;

                    if ((tileWidth - maxOffset < mapAttributes.GetLength(0) && (tileHeight - maxOffset < mapAttributes.GetLength(0) &&
                        (tileWidth - maxOffset >= 0) && (tileHeight - maxOffset >= 0))))
                    {
                        mapAttributes[tileWidth - maxOffset, tileHeight - maxOffset] = climax;
                    }

                    if ((tileWidth + maxOffset < mapAttributes.GetLength(0) && (tileHeight - maxOffset < mapAttributes.GetLength(0) &&
                        (tileWidth + maxOffset >= 0) && (tileHeight - maxOffset >= 0))))
                    {
                        mapAttributes[tileWidth + maxOffset, tileHeight - maxOffset] = climax;
                    }

                    if ((tileWidth - maxOffset < mapAttributes.GetLength(0) && (tileHeight + maxOffset < mapAttributes.GetLength(0) &&
                        (tileWidth - maxOffset >= 0) && (tileHeight + maxOffset >= 0))))
                    {
                        mapAttributes[tileWidth - maxOffset, tileHeight + maxOffset] = climax;
                    }

                    if ((tileWidth + maxOffset < mapAttributes.GetLength(0) && (tileHeight + maxOffset < mapAttributes.GetLength(0) &&
                        (tileWidth + maxOffset >= 0) && (tileHeight + maxOffset >= 0))))
                    {
                        mapAttributes[tileWidth + maxOffset, tileHeight + maxOffset] = climax;
                    }
                    //middle section


                    maxOffset--;
                    climax--;

                    if (climax <= 0)
                    {

                        // random between dirt min- dirt max
                        index = random.Next(0, tileTypes.Count);
                        climax = tileTypes[index];

                    }
                }

                ///////////////////
            }


        }


        public void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Space) && oldKeyoardState.IsKeyDown(Keys.Space))
            {
                PreGeneration();
            }
            oldKeyoardState = keyboardState;
            foreach (Tile ti in tiles)
            {
                if (ti.IsAlive())
                {
                    ti.Update(gameTime);
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            for (int x = 0; x < mapSize.GetLength(0); x++)
            {
                for (int y = 0; y < mapSize.GetLength(1); y++)
                {
                    // Console.WriteLine(tiles[mapSize[x,y]].ToString());
                    spriteBatch.Draw(tiles[mapSize[x, y]].textures[mapAttributes[x, y]], new Vector2(32 * x, 32 * y), Color.White);
                }
            }
        }

    }
}