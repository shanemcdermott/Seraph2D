using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public SpriteRenderer overlaySpriteRender;
    public Material defaultOverlayMaterial;


    private Coroutine currentCoroutine;

    // Use this for initialization
    void Start ()
    {
	}

    public void SetOverlayMaterial(Material mat)
    {
        SetOverlayMaterial(mat, 3f, 0.5f);
    }

    public void SetOverlayMaterial(Material mat, float Duration, float BlendTime)
    {
        if(currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }
        currentCoroutine = StartCoroutine(ApplyOverlay(mat, Duration, BlendTime));
    }
	
    IEnumerator ApplyOverlay(Material mat, float duration, float blendTime)
    {
        float currentBlend = 0f;
        while(currentBlend < blendTime)
        {
            currentBlend = Mathf.Min(currentBlend + Time.deltaTime, blendTime);
            overlaySpriteRender.material.Lerp(defaultOverlayMaterial, mat, currentBlend/blendTime);
            yield return null;
        }

        yield return new WaitForSeconds(duration);

        while (currentBlend > 0f)
        {
            currentBlend = Mathf.Max(currentBlend - Time.deltaTime, 0f);
            overlaySpriteRender.material.Lerp(defaultOverlayMaterial, mat, currentBlend / blendTime);
            yield return null;
        }
    }
}
