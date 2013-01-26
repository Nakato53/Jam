using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NNS.Lib.Entities.Common;
using NNS.Lib.Managers;
using NNS.Lib.Utils;

namespace NNS.Lib.Main
{
    public class MyGame
    {
        public static Game Game;
        protected GraphicsDeviceManager _graphics;

        protected ScreensManager _ScreensManager;

        protected Config _config;
        protected Log _log;
        protected Texture2DManager _texturesManager;

        public static GraphicsDevice GraphicDevice;

        public MyGame(Game game, GraphicsDeviceManager graph)
        {
            Game = game;
            _graphics = graph;

            Main.MyGame.GraphicDevice = Game.GraphicsDevice;

            this._log = new Log();
            this._texturesManager = new Texture2DManager(Game.Content);

            _graphics.PreferredBackBufferHeight= Config.GAME_HEIGHT;
            _graphics.PreferredBackBufferWidth = Config.GAME_WIDTH;
            _graphics.ApplyChanges();

            Game.Window.Title = Config.GAME_NAME;
        }

        public void Initialize()
        {
            this._ScreensManager = new ScreensManager();
            this._ScreensManager.addScreen("gameScreen", new Entities.Screens.GameScreen());

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
            Game.GraphicsDevice.Clear(Color.CornflowerBlue);

            this._ScreensManager.Draw(spriteBatch, gameTime);


        }
    }
}
