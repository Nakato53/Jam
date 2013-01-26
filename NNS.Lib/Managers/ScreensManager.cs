using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using NNS.Lib.Entities.Screens;

namespace NNS.Lib.Managers
{
	public class ScreensManager
	{
		private static ScreensManager _instance;
		public static ScreensManager Instance ()
		{
			if(_instance == null)
				_instance = new ScreensManager();

			return _instance;
		}


		private Dictionary<String,Screen> _screens;
		private Screen _currentScreen;


		public ScreensManager ()
		{
			this._screens = new Dictionary<string, Screen>();
		}

		public void addScreen (String key, Screen screen)
		{
			this._screens.Add(key,screen);
            if (this._currentScreen == null)
            {
                SwitchScreen(key);
            }
		}

		public void SwitchScreen(String screen)
		{
            if (this._screens.ContainsKey(screen))
            {
                Utils.Events.fire("ScreenManager::changeScreen", new object[]{ "test",new Vector2(10,10) } );
                this._currentScreen = this._screens[screen];
            }
		}

		public void Update (GameTime gameTime)
		{
			if(this._currentScreen!=null)
				this._currentScreen.Update(gameTime);
		}

		public void Draw (SpriteBatch spriteBatch, GameTime gameTime)
		{
			if(this._currentScreen!=null)
				this._currentScreen.Draw(spriteBatch, gameTime);
		}

	}
}

