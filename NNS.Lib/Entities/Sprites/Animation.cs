using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace NNS.Lib.Entities.Sprites
{
	public enum AnimationType
	{
		Loop,
		Bounce
	}


	public class Animation
	{
		private double _timeElapsed;
		private double _frameTime;
		private int _currentFrame;
		private AnimationType _animationType;
		private int _frameWidth;
		private Rectangle _currentRectangle;
		private int _totalFrame;

		private int _step = 1;

		public Texture2D Texture {
			get;
		    private set;
		}

		public Animation (Texture2D texture, int frameTime, int frameWidth, AnimationType animationType  )
		{
			this._animationType = animationType;
			this.Texture = texture;
			this._frameTime = frameTime;
			this._frameWidth = frameWidth;
			this._totalFrame = this.Texture.Width / this._frameWidth;
			this.Reset();
		}

		public void Reset ()
		{
			this._currentFrame = 0;
			this._timeElapsed = 0;
		}

		public Rectangle getFrame ()
		{
			return _currentRectangle;
		}

		public void Update (GameTime gameTime)
		{
			_timeElapsed += gameTime.ElapsedGameTime.TotalMilliseconds;

			if (_timeElapsed >= _frameTime) {
				_timeElapsed=0;
				this._currentFrame+=this._step;

				switch (this._animationType) {
					case AnimationType.Loop:
						{
							if(this._currentFrame==this._totalFrame)
								this._currentFrame = 0;
						}
						break;
					case AnimationType.Bounce:
						{
							if(this._step == 1 && this._currentFrame==this._totalFrame){
								this._currentFrame = this._totalFrame-2;
								this._step = -1;
							}

							else if(this._step == -1 && this._currentFrame==-1){
								this._currentFrame = 1;
								this._step = 1;
							}
						}
						break;
					default:
						break;				
				}

				this._currentRectangle = new Rectangle(this._currentFrame * this._frameWidth,0,this._frameWidth,this.Texture.Height);
			}

		}
	}
}

