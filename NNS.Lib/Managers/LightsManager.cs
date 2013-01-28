using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NNS.Lib.Entities.Lights;

namespace NNS.Lib.Managers
{
    public class LightsManager
    {

        private RenderTarget2D _colorMapRenderTarget;
        private RenderTarget2D _shadowMapRenderTarget;
        private RenderTarget2D _normalMapRenderTarget;
        private Color _ambientLight = new Color(.3f, .3f, .3f, 1);

        private Effect _lightEffect;
        private Effect _lightCombinedEffect;

        private EffectTechnique _lightEffectTechniquePointLight;
        private EffectTechnique _lightEffectTechniqueSpotLight;
        private EffectParameter _lightEffectParameterStrength;
        private EffectParameter _lightEffectParameterPosition;
        private EffectParameter _lightEffectParameterLightColor;
        private EffectParameter _lightEffectParameterLightDecay;
        private EffectParameter _lightEffectParameterScreenWidth;
        private EffectParameter _lightEffectParameterScreenHeight;
        private EffectParameter _lightEffectParameterNormapMap;

        private EffectParameter _lightEffectParameterConeAngle;
        private EffectParameter _lightEffectParameterConeDecay;
        private EffectParameter _lightEffectParameterConeDirection;

        private EffectTechnique _lightCombinedEffectTechnique;
        private EffectParameter _lightCombinedEffectParamAmbient;
        private EffectParameter _lightCombinedEffectParamLightAmbient;
        private EffectParameter _lightCombinedEffectParamAmbientColor;
        private EffectParameter _lightCombinedEffectParamColorMap;
        private EffectParameter _lightCombinedEffectParamShadowMap;
        private EffectParameter _lightCombinedEffectParamNormalMap;

        public VertexPositionColorTexture[] Vertices;
        public VertexBuffer VertexBuffer;

        public LightsManager()
        {
            initializeLight();
        }


        public void SpriteBatchBegin(SpriteBatch spriteBatch)
        {
            Main.MyGame.GraphicDevice.Clear(Color.CornflowerBlue);
            Main.MyGame.GraphicDevice.SetRenderTarget(_colorMapRenderTarget);
            Main.MyGame.GraphicDevice.Clear(Color.Transparent);

            spriteBatch.Begin();
        }

        public void DrawLights(SpriteBatch spriteBatch, List<Light> lights)
        {
            // Clear all render targets
            Main.MyGame.GraphicDevice.SetRenderTarget(null);
            Main.MyGame.GraphicDevice.SetRenderTarget(_normalMapRenderTarget);

            DrawNormalMap(spriteBatch);


            Main.MyGame.GraphicDevice.SetRenderTarget(null);

            GenerateShadowMap(lights);

            Main.MyGame.GraphicDevice.Clear(Color.Black);

            DrawCombinedMaps(spriteBatch);

        }

        private void DrawNormalMap(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(
                Texture2DManager.Instance.get("normal"),
                new Rectangle(0, 0, Main.MyGame.GraphicDevice.Viewport.Width, Main.MyGame.GraphicDevice.Viewport.Height),
             //   Vector2.Zero,
                Color.White);

            spriteBatch.End();
        }

        private void initializeLight()
        {
            PresentationParameters pp = Main.MyGame.GraphicDevice.PresentationParameters;
            int width = pp.BackBufferWidth;
            int height = pp.BackBufferHeight;
            SurfaceFormat format = pp.BackBufferFormat;

            Vertices = new VertexPositionColorTexture[4];
            Vertices[0] = new VertexPositionColorTexture(new Vector3(-1, 1, 0), Color.White, new Vector2(0, 0));
            Vertices[1] = new VertexPositionColorTexture(new Vector3(1, 1, 0), Color.White, new Vector2(1, 0));
            Vertices[2] = new VertexPositionColorTexture(new Vector3(-1, -1, 0), Color.White, new Vector2(0, 1));
            Vertices[3] = new VertexPositionColorTexture(new Vector3(1, -1, 0), Color.White, new Vector2(1, 1));
            VertexBuffer = new VertexBuffer(Main.MyGame.GraphicDevice, typeof(VertexPositionColorTexture), Vertices.Length, BufferUsage.None);
            VertexBuffer.SetData(Vertices);

            _colorMapRenderTarget = new RenderTarget2D(Main.MyGame.GraphicDevice, width, height);
            _shadowMapRenderTarget = new RenderTarget2D(Main.MyGame.GraphicDevice, width, height, false, format, pp.DepthStencilFormat, pp.MultiSampleCount, RenderTargetUsage.DiscardContents);
            _normalMapRenderTarget = new RenderTarget2D(Main.MyGame.GraphicDevice, width, height, false, format, pp.DepthStencilFormat, pp.MultiSampleCount, RenderTargetUsage.DiscardContents);

            _lightEffect = Main.MyGame.Game.Content.Load<Effect>("Effects/MultiTarget");
            _lightCombinedEffect = Main.MyGame.Game.Content.Load<Effect>("Effects/DeferredCombined");

            // Point light technique
            _lightEffectTechniquePointLight = _lightEffect.Techniques["DeferredPointLight"];

            // Spot light technique
            _lightEffectTechniqueSpotLight = _lightEffect.Techniques["DeferredSpotLight"];

            // Shared light properties
            _lightEffectParameterLightColor = _lightEffect.Parameters["lightColor"];
            _lightEffectParameterLightDecay = _lightEffect.Parameters["lightDecay"];
            _lightEffectParameterNormapMap = _lightEffect.Parameters["NormalMap"];
            _lightEffectParameterPosition = _lightEffect.Parameters["lightPosition"];
            _lightEffectParameterScreenHeight = _lightEffect.Parameters["screenHeight"];
            _lightEffectParameterScreenWidth = _lightEffect.Parameters["screenWidth"];
            _lightEffectParameterStrength = _lightEffect.Parameters["lightStrength"];

            // Spot light parameters
            _lightEffectParameterConeDirection = _lightEffect.Parameters["coneDirection"];
            _lightEffectParameterConeAngle = _lightEffect.Parameters["coneAngle"];
            _lightEffectParameterConeDecay = _lightEffect.Parameters["coneDecay"];

            _lightCombinedEffectTechnique = _lightCombinedEffect.Techniques["DeferredCombined2"];
            _lightCombinedEffectParamAmbient = _lightCombinedEffect.Parameters["ambient"];
            _lightCombinedEffectParamLightAmbient = _lightCombinedEffect.Parameters["lightAmbient"];
            _lightCombinedEffectParamAmbientColor = _lightCombinedEffect.Parameters["ambientColor"];
            _lightCombinedEffectParamColorMap = _lightCombinedEffect.Parameters["ColorMap"];
            _lightCombinedEffectParamShadowMap = _lightCombinedEffect.Parameters["ShadingMap"];
            _lightCombinedEffectParamNormalMap = _lightCombinedEffect.Parameters["NormalMap"];

        }

        public void DrawCombinedMaps(SpriteBatch spriteBatch)
        {
            _lightCombinedEffect.CurrentTechnique = _lightCombinedEffectTechnique;
            _lightCombinedEffectParamAmbient.SetValue(1f);
            _lightCombinedEffectParamLightAmbient.SetValue(4);
            _lightCombinedEffectParamAmbientColor.SetValue(_ambientLight.ToVector4());
            _lightCombinedEffectParamColorMap.SetValue(_colorMapRenderTarget);
            _lightCombinedEffectParamShadowMap.SetValue(_shadowMapRenderTarget);
            _lightCombinedEffectParamNormalMap.SetValue(_normalMapRenderTarget);
            _lightCombinedEffect.CurrentTechnique.Passes[0].Apply();

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, _lightCombinedEffect);
            spriteBatch.Draw(_colorMapRenderTarget, Vector2.Zero, Color.White);
            spriteBatch.End();
        }



        public Texture2D GenerateShadowMap(List<Light> lights)
        {
            Main.MyGame.GraphicDevice.SetRenderTarget(_shadowMapRenderTarget);
            Main.MyGame.GraphicDevice.Clear(Color.Transparent);

            foreach (var light in lights)
            {

                if (!light.IsEnabled) continue;

                Main.MyGame.GraphicDevice.SetVertexBuffer(VertexBuffer);

                // Draw all the light sources
                _lightEffectParameterStrength.SetValue(light.ActualPower);
                _lightEffectParameterPosition.SetValue(light.Position);
                _lightEffectParameterLightColor.SetValue(light.Color);
                _lightEffectParameterLightDecay.SetValue(light.LightDecay); // Value between 0.00 and 2.00
                _lightEffect.Parameters["specularStrength"].SetValue(0);

                if (light.LightType == LightType.Point)
                {
                    _lightEffect.CurrentTechnique = _lightEffectTechniquePointLight;
                }
                else
                {
                    _lightEffect.CurrentTechnique = _lightEffectTechniqueSpotLight;
                    _lightEffectParameterConeAngle.SetValue(((SpotLight)light).SpotAngle);
                    _lightEffectParameterConeDecay.SetValue(((SpotLight)light).SpotDecayExponent);
                    _lightEffectParameterConeDirection.SetValue(((SpotLight)light).Direction);
                }

                _lightEffectParameterScreenWidth.SetValue(Main.MyGame.GraphicDevice.Viewport.Width);
                _lightEffectParameterScreenHeight.SetValue(Main.MyGame.GraphicDevice.Viewport.Height);
                _lightEffect.Parameters["ambientColor"].SetValue(_ambientLight.ToVector4());
                _lightEffectParameterNormapMap.SetValue(_normalMapRenderTarget);
                _lightEffect.Parameters["ColorMap"].SetValue(_colorMapRenderTarget);
                _lightEffect.CurrentTechnique.Passes[0].Apply();

                // Add Belding (Black background)
                Main.MyGame.GraphicDevice.BlendState = BlendBlack;

                // Draw some magic
                Main.MyGame.GraphicDevice.DrawUserPrimitives(PrimitiveType.TriangleStrip, Vertices, 0, 2);
            }

            // Deactive the rander targets to resolve them
            Main.MyGame.GraphicDevice.SetRenderTarget(null);

            return _shadowMapRenderTarget;
        }

     
        public static BlendState BlendBlack = new BlendState()
        {
            ColorBlendFunction = BlendFunction.Add,
            ColorSourceBlend = Blend.One,
            ColorDestinationBlend = Blend.One,

            AlphaBlendFunction = BlendFunction.Add,
            AlphaSourceBlend = Blend.SourceAlpha,
            AlphaDestinationBlend = Blend.One
        };
    }
}
