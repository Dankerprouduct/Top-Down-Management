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
    class Camera
    {
        public Matrix transform;
        Viewport view;
        Vector2 center;
        float scale = 1f;
        public Camera(Viewport vPort)
        {
            view = vPort;
        }
        public void Update(GameTime gameTime, Game1 game)
        {
            center = new Vector2(game.camPosition.X - game.WIDTH / 2, game.camPosition.Y - game.WIDTH / 2);
            transform = Matrix.CreateScale(new Vector3(scale, scale, 1)) * Matrix.CreateTranslation(new Vector3(-center.X, -center.Y, 0));
        }
    }
}
