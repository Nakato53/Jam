using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace NNS.Lib.Managers
{
	public class InputManager
	{
		private static KeyboardState _oldKeyboard;
		private static KeyboardState _currentKeyboard;

		private static MouseState _oldMouse;
		private static MouseState _currentMouse;

		public static void Update (GameTime gameTime)
		{
			if(_currentKeyboard != null)
				_oldKeyboard = _currentKeyboard;

			if(_currentMouse != null)
				_oldMouse = _currentMouse;

			_currentMouse = Microsoft.Xna.Framework.Input.Mouse.GetState();
			_currentKeyboard = Keyboard.GetState();
		}

		public static bool isKeyDown( Keys k )
		{
			return _currentKeyboard.IsKeyDown(k);
		}
		public static bool isKeyUp( Keys k )
		{
			return _currentKeyboard.IsKeyUp(k);
		}

		public static bool isKeyPressed( Keys k )
		{
			return _oldKeyboard.IsKeyUp(k) && _currentKeyboard.IsKeyDown(k);
		}
		public static bool isKeyReleased( Keys k )
		{
			return _oldKeyboard.IsKeyDown(k) && _currentKeyboard.IsKeyUp(k);
		}

		public static MouseState Mouse()
		{
			return _currentMouse;
		}

		public static bool isMouseLeftClicPressed()
		{
			return _oldMouse.LeftButton == ButtonState.Released && _currentMouse.LeftButton == ButtonState.Pressed;
		}

		public static bool isMouseLeftClicReleased()
		{
			return _oldMouse.LeftButton == ButtonState.Pressed && _currentMouse.LeftButton == ButtonState.Released;
		}

		public static bool isMouseRightClicPressed()
		{
			return _oldMouse.RightButton == ButtonState.Released && _currentMouse.RightButton == ButtonState.Pressed;
		}

		public static bool isMouseRightClicReleased()
		{
			return _oldMouse.RightButton == ButtonState.Pressed && _currentMouse.RightButton == ButtonState.Released;
		}

		public static bool isMouseMiddleClicPressed()
		{
			return _oldMouse.MiddleButton == ButtonState.Released && _currentMouse.MiddleButton == ButtonState.Pressed;
		}

		public static bool isMouseMiddleClicReleased()
		{
			return _oldMouse.MiddleButton == ButtonState.Pressed && _currentMouse.MiddleButton == ButtonState.Released;
		}


	}
}

