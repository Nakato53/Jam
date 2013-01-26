using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NNS.Lib.Managers;

namespace NNS.Lib.Entities.Screens
{
    public class GameScreen : Screen
    {
        Texture2D _text;

        public GameScreen()
        {
            this._text = Texture2DManager.Instance.get("fireball");
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(_text, new Vector2(50, 50), Color.White);
            spriteBatch.End();
        }
    }
}
