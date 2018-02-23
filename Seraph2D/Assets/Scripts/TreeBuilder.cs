using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBuilder : MonoBehaviour
{
	public float minRot = 15;
	public float maxRot = 60;
	public float minScale = 0.1f;
	public float maxScale = 0.75f;
    public Vector3[] offsetOptions;
	public GameObject branchPrefab;

	// Use this for initialization
	void Start ()
    {
		AddBranch();
		AddBranch();	
	}
	
	void AddBranch()
    {
        GameObject branch = GameObject.Instantiate(branchPrefab, gameObject.transform);
		float rot = Random.Range (minRot, maxRot);
		if (Random.value > 0.5f) {
			rot *= -1;
		}
		branch.transform.Rotate(new Vector3(0,0,1), rot);
		branch.transform.localPosition = chooseOffset();
		float sc = Random.Range (minScale, maxScale);
		branch.transform.localScale = new Vector3 (sc, sc, sc);
    }

	public Vector3 chooseOffset()
	{
		return offsetOptions[Random.Range (0, offsetOptions.Length)];
	}
}
