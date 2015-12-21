using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Top_Down_Management
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;


        KeyboardState keyboardState;
        KeyboardState oldKeyboardState;
        TileMap tileMap;
        int[,] size = new int[15, 15];
        public int WIDTH = 1080;
        public int HEIGHT;
        Camera camera;
        public Vector2 camPosition;
        public Game1()
        {
            //  GraphicsDevice.SamplerStates[0] = SamplerState.PointWrap;

            HEIGHT = (WIDTH / 16) * 9;
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = HEIGHT;
            graphics.PreferredBackBufferWidth = WIDTH;
            Content.RootDirectory = "Content";

        }


        protected override void Initialize()
        {
            IsMouseVisible = true;
            GraphicsDevice.SamplerStates[0] = SamplerState.PointWrap;
            base.Initialize();
        }

        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);
            tileMap = new TileMap(size);
            tileMap.LoadContent(Content);

            camera = new Camera(GraphicsDevice.Viewport);
            camPosition = new Vector2(WIDTH / 2, HEIGHT / 2);

        }


        protected override void UnloadContent()
        {

        }


        protected override void Update(GameTime gameTime)
        {

            keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            tileMap.Update(gameTime);

            CameraMovement();
            camera.Update(gameTime, this);

            oldKeyboardState = keyboardState;
            base.Update(gameTime);
        }


        float cameraSpeed = 5;
        void CameraMovement()
        {

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                camPosition.Y -= cameraSpeed;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                camPosition.Y += cameraSpeed;
            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                camPosition.X -= cameraSpeed;
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                camPosition.X += cameraSpeed;
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend,
                SamplerState.PointWrap, null, null, null,
                camera.transform);
            tileMap.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}