using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NNS.Lib.Entities.Common;
using NNS.Lib.Managers;

namespace NNS.Lib.Main
{
    public class MyGame
    {
        protected Game _game;
        protected GraphicsDeviceManager _graphics;

        protected ScreensManager _ScreensManager;

        protected Config _config;

        public MyGame(Game game, GraphicsDeviceManager graph)
        {
            _game = game;
            _graphics = graph;

            this._config = new Config();

            _graphics.PreferredBackBufferHeight= _config.GAME_HEIGHT;
            _graphics.PreferredBackBufferWidth = _config.GAME_WIDTH;
            _graphics.ApplyChanges();

            _game.Window.Title = _config.GAME_NAME;
        }

        public void Initialize()
        {
            this._ScreensManager = new ScreensManager();
        }


        public void LoadContent()
        {

        }

        public void UnloadContent()
        {

        }

        public void Update(GameTime gameTime) 
        {
            InputManager.Update(gameTime);

            this._ScreensManager.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            _game.GraphicsDevice.Clear(Color.CornflowerBlue);

            this._ScreensManager.Draw(spriteBatch, gameTime);


        }
    }
}
