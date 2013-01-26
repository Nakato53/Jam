using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NNS.Lib.Managers;
using NNS.Lib.Entities.Lights;
using NNS.Lib.Entities.Common;

namespace NNS.Lib.Entities.Screens
{
    public class GameScreen : Screen
    {
        Texture2D _text;

        private LightsManager _lightManager;
        private List<Light> _lights;
        private RenderTarget2D _colorMapRenderTarget;

        public GameScreen()
        {
            this._text = Texture2DManager.Instance.get("Chrysanthemum");

            this._lightManager = new LightsManager();
            this._lights = new List<Light>();
            _colorMapRenderTarget = new RenderTarget2D(Main.MyGame.GraphicDevice, Config.GAME_WIDTH, Config.GAME_HEIGHT);

            _lights.Add(new SpotLight()
            {
                IsEnabled = true,
                Color = new Vector4(1f, 1f, 1.0f, 1.0f),
                Power = 1f,
                LightDecay = 400,
                Position = new Vector3(400, 0, 30),
                SpotAngle =150,
                SpotDecayExponent = 40,
                Direction = new Vector3(0.244402379f, 0.969673932f, 0)
            });
        }


        
        public override void Update(GameTime gameTime)
        {
            this._lights[0].Position = new Vector3(InputManager.Mouse().X, InputManager.Mouse().Y, this._lights[0].Position.Z);

            if(InputManager.isKeyDown(Microsoft.Xna.Framework.Input.Keys.Space))
            {
                SpotLight light = (SpotLight)this._lights[0];
                light.SpotAngle += 0.1f;
                light.Direction = new Vector3((float)Math.Cos(light.SpotAngle), (float)Math.Sin(light.SpotAngle), 0);
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            this._lightManager.SpriteBatchBegin(spriteBatch);

            spriteBatch.Draw(this._text, new Vector2(50, 50), Color.White);

            spriteBatch.End();

            this._lightManager.DrawLights(spriteBatch, this._lights);
        }

      


    }
}
