using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ninja.Camera
{

    [System.Serializable]
    public struct OverlayData
    {
        [SerializeField]
        public Material material;
        [SerializeField]
        public float duration;
        [SerializeField]
        public float blendTime;

        public OverlayData(Material inMat, float inDuration, float inBlendTime)
        {
            material = inMat;
            duration = inDuration;
            blendTime = inBlendTime;
        }

        public OverlayData(Material inMat, float totalDuration)
        {
            material = inMat;
            blendTime = 0.1f;
            duration = totalDuration - (2 * blendTime);
        }

        public float Length
        {
            get { return blendTime * 2 + duration; }
        }
    }

    public class CameraOverlay : MonoBehaviour
    {

  
        public Image image;
        public Material defaultOverlayMaterial;
        public float BookendPct = 0.01f;

        private Coroutine currentCoroutine;

        public bool IsBusy
        {
            get { return isBusy; }
        }

        private bool isBusy = false;

        public float StartOverlay(ref OverlayData overlayData)
        {
            if (currentCoroutine != null)
            {
                EndOverlay();
            }
            currentCoroutine = StartCoroutine(ApplyOverlay(overlayData));
            return overlayData.duration + overlayData.blendTime * 2;
        }

        public void EndOverlay()
        {
            if(currentCoroutine != null)
            {
                StopCoroutine(currentCoroutine);
               // image.material = defaultOverlayMaterial;
            }
        }

        IEnumerator ApplyOverlay(OverlayData data)
        {
            isBusy = true;
            float currentBlend = 0f;
            while (currentBlend < data.blendTime)
            {
                
                currentBlend = Mathf.Min(currentBlend + Time.deltaTime, data.blendTime);
                image.materialForRendering.Lerp(defaultOverlayMaterial, data.material, currentBlend / data.blendTime);
                yield return null;
            }

            yield return new WaitForSeconds(data.duration);

            while (currentBlend > 0f)
            {
                currentBlend = Mathf.Max(currentBlend - Time.deltaTime, 0f);
                image.materialForRendering.Lerp(defaultOverlayMaterial, data.material, currentBlend / data.blendTime);
                yield return null;
            }
            isBusy = false;
        }
    }
}