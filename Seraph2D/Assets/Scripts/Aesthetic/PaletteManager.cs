using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteManager : MonoBehaviour 
{
	public ColorPalette[] prefabs;
	public Color[] palette;

	// Use this for initialization
	void Start () 
	{
		ApplyColorPalette();
	}

	public void ApplyColorPalette()
	{
		foreach (ColorPalette p in prefabs) 
		{
			p.AssignColors(palette);
		}
	}
}
