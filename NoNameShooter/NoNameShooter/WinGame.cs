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

namespace NoNameShooter
{
    
    public class WinGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        NNS.Lib.Main.MyGame myGame;

        public WinGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

      
        protected override void Initialize()
        {
            myGame = new NNS.Lib.Main.MyGame(this, graphics);
            myGame.Initialize();
            base.Initialize();
        }

      
        protected override void LoadContent()
        {
          
            spriteBatch = new SpriteBatch(GraphicsDevice);

            myGame.LoadContent();

        }

        protected override void UnloadContent()
        {
            myGame.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            myGame.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            

            myGame.Draw(spriteBatch, gameTime);

            base.Draw(gameTime);
        }
    }
}
