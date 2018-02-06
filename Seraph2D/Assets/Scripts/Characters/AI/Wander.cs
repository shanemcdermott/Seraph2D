using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour 
{
	public float speed = 2;

	private Vector3 moveDir;

	private IEnumerator coroutine;

	void Start()
	{
		coroutine = ChooseDirection (Random.Range (3.0f, 8.0f));
		StartCoroutine (coroutine);
	}
	// Update is called once per frame
	void FixedUpdate () 
	{
		transform.position += moveDir * speed * Time.fixedDeltaTime;
		
	}

	private IEnumerator ChooseDirection(float wanderTime)
	{
		while (true) {
			yield return new WaitForSeconds(wanderTime);
			moveDir.x = Random.Range (-1, 1);
			moveDir.y = Random.Range(-1,1);
		}
	}
}
