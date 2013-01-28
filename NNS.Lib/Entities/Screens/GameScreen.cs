using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NNS.Lib.Managers;
using NNS.Lib.Entities.Lights;
using NNS.Lib.Entities.Common;
using NNS.Lib.Utils;
using NNS.Lib.Entities.GameObjects;

namespace NNS.Lib.Entities.Screens
{
    public class GameScreen : Screen
    {
        Player _player;
        private LightsManager _lightManager;
        private List<Light> _lights;
        private RenderTarget2D _colorMapRenderTarget;

        public GameScreen()
        {
            _player = new Player(new Vector2(200, 200), Color.White);
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
                SpotRotation = 2,
                SpotDecayExponent = 40,
              //  Direction = new Vector3(0.244402379f, 0.969673932f, 0)
            });
        }


        
        public override void Update(GameTime gameTime)
        {

            _player.Update(gameTime);
            this._lights[0].Position = new Vector3(InputManager.Mouse().X, InputManager.Mouse().Y, this._lights[0].Position.Z);

            if(InputManager.isKeyDown(Microsoft.Xna.Framework.Input.Keys.Space))
            {
                SpotLight light = (SpotLight)this._lights[0];
                light.SpotRotation += 0.1f;
            }

            if (InputManager.isKeyPressed(Microsoft.Xna.Framework.Input.Keys.R))
            {
                Random rnd = new Random();
                _lights.Add(new PointLight()
                {
                    IsEnabled = true,
                    Color = new Vector4( (float)rnd.NextDouble(), (float)rnd.NextDouble(), (float)rnd.NextDouble(), 1.0f),
                    Power = (float)rnd.Next(1, 10) * .1f,
                    LightDecay = rnd.Next(100, 400),
                    Position = new Vector3(
                        rnd.Next(0, Config.GAME_WIDTH),
                        rnd.Next(0, Config.GAME_HEIGHT),
                        80)
                });
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            this._lightManager.SpriteBatchBegin(spriteBatch);

            _player.Draw(spriteBatch, gameTime);
           // spriteBatch.Draw(this._text, new Vector2(0, 0), Color.White);
            spriteBatch.End();

            this._lightManager.DrawLights(spriteBatch, this._lights);
        }

      


    }
}
