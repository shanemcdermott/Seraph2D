using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Framework.Controller;
using Framework.Camera;

namespace Framework.Gameplay.Abilities
{
    /// <summary>
    /// Ability that impacts the world and has a tint
    /// </summary>
    public class WorldAbility : GameAbility
    {
        public Material overlayMat;

        public virtual bool CanUse()
        {
            return true;
        }

        public override float Use()
        {
            if (!CanUse()) return 0f;
            Debug.Log("Starting Ability");

            OverlayData overlay = new OverlayData(overlayMat, duration);
            return GameManager.Get().cameraController.BlendOverlay(ref overlay);
        }

    }
}