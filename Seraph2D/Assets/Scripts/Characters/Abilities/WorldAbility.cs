using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ability that impacts the world and has a tint
/// </summary>
public class WorldAbility : MonoBehaviour
{
    public Material overlayMat;


    public void Use()
    {
        GameManager.inst.cameraManager.SetOverlayMaterial(overlayMat);
    }
	

}
