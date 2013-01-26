using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NNS.Lib.Entities.Screens
{
	public abstract class Screen
	{
		public bool Visible {
			get;
			set;
		}

		public Screen ()
		{
			this.Visible = true;
		}

		public virtual void Update (GameTime gameTime)
		{

		}

		public virtual void Draw (SpriteBatch spriteBatch, GameTime gameTime)
		{

		}
	}
}

