using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NNS.Lib.Entities.Lights
{
    public class SpotLight : Light
    {
        private float _spotRotation;

        /// <summary>
        /// Gets or sets the spot angle. Specified how large the cone is.
        /// </summary>
        /// <value>The spot angle.</value>
        public float SpotAngle { get; set; }

        /// <summary>
        /// Gets or sets the spot decay exponent. Measures how the light intensity
        /// decreases from the center of the cone, towards the walls.
        /// </summary>
        /// <value>The spot decay exponent.</value>
        public float SpotDecayExponent { get; set; }

        public float SpotRotation
        {
            get { return _spotRotation; }
            set
            {
                _spotRotation = value;
                Direction = new Vector3(
                    (float)Math.Cos(_spotRotation),
                    (float)Math.Sin(_spotRotation),
                    Direction.Z);
            }
        }

        public SpotLight()
            : base(LightType.Spot)
        {
            SpotAngle = 0;
        }

        public override void Update(GameTime gameTime)
        {
            if (!IsEnabled) return;

            // Process the modifiers
            //for (int i = 0; i < ModifierCollection.Count; i++)
            //{
            //    ModifierCollection[i].Process(deltaTime, this);
            //}

            // Update the position of the light based on the scaling factor
            //ShaderLightPosition.X = ((ActualPosition.X - CameraManager.ActiveCamera.CameraPosition.X) / GameRenderCore.LightMapRenderTargetScalingFactor) * CameraManager.ActiveCamera.Zoom;
            //ShaderLightPosition.Y = ((ActualPosition.Y - CameraManager.ActiveCamera.CameraPosition.Y) / GameRenderCore.LightMapRenderTargetScalingFactor) * CameraManager.ActiveCamera.Zoom;
            //ShaderLightPosition.Z = ActualPosition.Z / GameRenderCore.LightMapRenderTargetScalingFactor;
            //ShaderLightRadius = LightDecay / (float)GameRenderCore.LightMapRenderTargetScalingFactor;

            // Check if this light is even visible
            //IsLightVisible = BoundingBox.Intersects(CameraManager.ActiveCamera.ViewRectangle);
        }

        //public override void UpdateLightParameters(EffectParameter lightParameter)
        //{
        //    lightParameter.StructureMembers["power"].SetValue(ActualPower);
        //    lightParameter.StructureMembers["falloff"].SetValue(this.SpotDecayExponent);
        //    lightParameter.StructureMembers["specPower"].SetValue(ActualSpecularPower);
        //    lightParameter.StructureMembers["normalPower"].SetValue(ActualNormalPower);
        //    lightParameter.StructureMembers["range"].SetValue(ShaderLightRadius);
        //    lightParameter.StructureMembers["position"].SetValue(ShaderLightPosition);
        //    lightParameter.StructureMembers["color"].SetValue(this.Color);
        //    lightParameter.StructureMembers["specularColor"].SetValue(Vector4.One);
        //    lightParameter.StructureMembers["coneAngle"].SetValue(SpotAngle);
        //    lightParameter.StructureMembers["coneDecay"].SetValue(SpotDecayExponent);
        //    lightParameter.StructureMembers["coneDirection"].SetValue(Direction);
        //    lightParameter.StructureMembers["lighttype"].SetValue(1);
        //}

        public override Light DeepCopy()
        {
            throw new NotImplementedException();
        }
    }
}