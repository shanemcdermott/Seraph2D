using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used to assign appropriate colors to each of the sprites used by the object
public class ColorPalette : MonoBehaviour 
{
	public SpriteRenderer[] renderers;
	public int[] paletteIds;

	public void AssignColors(Color[] colors)
	{
		for (int i = 0; i < renderers.Length; i++) 
		{
			renderers [i].color = colors [paletteIds [i]];
		}
	}
}
