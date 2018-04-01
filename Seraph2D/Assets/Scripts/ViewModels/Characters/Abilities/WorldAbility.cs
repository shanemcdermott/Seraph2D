using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        return GameManager.inst.cameraManager.SetOverlayMaterial(overlayMat,duration);
    }
	
}
