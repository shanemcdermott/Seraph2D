using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBuilder : MonoBehaviour
{
    public Vector2 size;

	// Use this for initialization
	void Start ()
    {
        //AddBranch();	
	}
	
	void AddBranch()
    {
        GameObject branch = GameObject.Instantiate(gameObject, gameObject.transform);
        branch.transform.Rotate(Vector3.forward, 45);
    }
}
