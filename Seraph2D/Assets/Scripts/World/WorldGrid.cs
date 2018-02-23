using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGrid : MonoBehaviour 
{
	public  Random rand;
	public GameObject[] chunkOptions;

	public static Vector2 chunkSize = new Vector2 (20, 20);
	public const int CHUNKS_PER_SIDE = 4; //+1 - This is radial.


	public static WorldGrid _inst;

	[SerializeField]
	private Dictionary<IntPoint, GameObject> activeChunks; 

	[SerializeField]
	private IntPoint centerPoint;

	[SerializeField]
	private IntPoint halfSize = new IntPoint(CHUNKS_PER_SIDE, CHUNKS_PER_SIDE);
	// Use this for initialization
	void Start () 
	{
		if (_inst == null) {
			_inst = this;
		} else if (_inst != this) {
			DestroyObject (this);
		} 

		InitWorld ();
	}

	private void InitWorld()
	{
		activeChunks = new Dictionary<IntPoint, GameObject> ();
		GenerateChunks ();
		centerPoint = new IntPoint (CHUNKS_PER_SIDE / 2, CHUNKS_PER_SIDE / 2);
	}

	private void GenerateChunks()
	{
		IntPoint min = IntPoint.Sub(centerPoint,halfSize);
		IntPoint max = IntPoint.Add(centerPoint,halfSize);
		IntPoint p = new IntPoint (min.x, min.y);
		for (p.x = min.x; p.x <= max.x; p.x++) 
		{
			for (p.y = min.y; p.y <= max.y; p.y++) 
			{
				if(!activeChunks.ContainsKey(p) || activeChunks[p] == null)
					activeChunks.Add(p, GenerateChunk (chunkToWorld(p)));
			}
		}
	}

	private void CullChunks()
	{
		List<IntPoint> keys = new List<IntPoint>( activeChunks.Keys);
		foreach (IntPoint key in keys) {
			if (!IsInBounds (key)) 
			{
				DestroyObject (activeChunks [key]);
				activeChunks.Remove (key);
			}	
		}
	}

	public void UpdateChunks(ChunkBounds newCenterChunk)
	{
		centerPoint = worldToChunk (newCenterChunk.transform.position);
		CullChunks ();
		GenerateChunks ();
		Debug.Log ("New Center: " + centerPoint.ToString ());
	}

	public Vector3 chunkToWorld(IntPoint chunkCoord)
	{
		float x = chunkSize.x * chunkCoord.x;
		float y = chunkSize.y * chunkCoord.y;
		return new Vector3 (x, y, y);
	}

	public IntPoint worldToChunk(Vector3 worldPosition)
	{
		int x = (int) Mathf.Round (worldPosition.x / chunkSize.x);
		int y = (int)Mathf.Round (worldPosition.y / chunkSize.y);
		return new IntPoint (x, y);
	}

	public bool IsInBounds(IntPoint p)
	{
		return p.x >= centerPoint.x - halfSize.x && p.y >= centerPoint.y - halfSize.y && p.x <= centerPoint.x + halfSize.x && p.y <= centerPoint.y + halfSize.y;
	}

	// Update is called once per frame
	void Update () {
		
	}

	GameObject GenerateChunk(Vector3 worldPosition)
	{

		int i = Random.Range (0, chunkOptions.Length);
		GameObject go = GameObject.Instantiate<GameObject> (chunkOptions[i], transform);
		go.transform.position = worldPosition;

		return go;
	}
}
