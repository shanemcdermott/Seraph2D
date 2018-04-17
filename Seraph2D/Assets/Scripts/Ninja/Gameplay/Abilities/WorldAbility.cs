using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Ninja.Controller;
using Ninja.Camera;

namespace Ninja.Gameplay.Abilities
{
    /// <summary>
    /// Ability that impacts the world and has a tint
    /// </summary>
    public class WorldAbility : MonoBehaviour
    {
        public Material overlayMat;
        public float duration = 1.5f;

        public virtual bool CanUse()
        {
            return true;
        }

        public float Use()
        {
            if (!CanUse()) return 0f;
            Debug.Log("Starting Ability");

            OverlayData overlay = new OverlayData(overlayMat, duration);
            return GameManager.Get().cameraController.BlendOverlay(ref overlay);
        }

    }
}