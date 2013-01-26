using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NNS.Lib.Entities.Screens
{
	public abstract class Screen : Common.UniqueID
	{
		public bool Visible {
			get;
			set;
		}

		public Screen ()
		 : base()
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

