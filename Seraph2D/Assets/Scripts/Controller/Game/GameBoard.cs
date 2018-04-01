using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;
using System.Collections.Generic;

public class GameBoard : MonoBehaviour 
{
	[SerializeField] GameObject tilePrefab;
	public Tilemap tilemap;

    public TileBase this[Vector3Int v3]
    {
        get { return tilemap.GetTile(v3); }
        set
        {
            tilemap.SetTile(v3,value);
        }
    }
	
	public bool ContainsTileAt(Vector3Int p)
	{
		return tilemap.HasTile(p);
	}

	public void Load (LevelData data)
	{
		for (int i = 0; i < data.tiles.Count; ++i)
		{
			GameObject instance = Instantiate(tilePrefab) as GameObject;
			Tile t = instance.GetComponent<Tile>();
			tilemap.SetTile(data.tiles[i],t);
		}
	}
}