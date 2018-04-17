using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ninja.Camera
{

    public class CameraController : MonoBehaviour
    {
        public CameraRig rig;

        /// <summary>
        /// Default camera overlay.
        /// </summary>
        public CameraOverlay overlay;

        public void Awake()
        {
            if(rig == null)
            {
                rig = GetComponentInChildren<CameraRig>();
            }
            if(overlay == null)
            {
                overlay = rig.gameObject.GetComponentInChildren<CameraOverlay>();
            }
        }
        
        public float BlendOverlay(ref OverlayData overlayData)
        {
            if(CanApplyOverlay())
            {
               return overlay.StartOverlay(ref overlayData);
            }

            return -1f;
        }

        public bool CanApplyOverlay()
        {
            return !overlay.IsBusy;
        }
    }
}