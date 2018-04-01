using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityInfoEvent<T> : UnityEvent<InfoEventArgs<T>>
{

}

class Repeater
{
	const float threshold = 0.5f;
	const float rate = 0.25f;
	float _next;
	bool _hold;
	string _axis;

	public Repeater (string axisName)
	{
		_axis = axisName;
	}

	public int Update ()
	{
		int retValue = 0;
		int value = Mathf.RoundToInt( Input.GetAxisRaw(_axis) );

		if (value != 0)
		{
			if (Time.time > _next)
			{
				retValue = value;
				_next = Time.time + (_hold ? rate : threshold);
				_hold = true;
			}
		}
		else
		{
			_hold = false;
			_next = 0;
		}

		return retValue;
	}
}

public class InputController : MonoBehaviour 
{
	//Event for horizontal and vertical input
	public static UnityInfoEvent<Vector2Int> moveEvent = new UnityInfoEvent<Vector2Int>();

	//Event for Action button presses
	public static UnityInfoEvent<int> actionEvent = new UnityInfoEvent<int>();

	///Action names to check input for
	string[] _buttons = new string[]{"Action1", "Action2", "Action3"};
	Repeater _hor = new Repeater("Horizontal");
	Repeater _ver = new Repeater("Vertical");

	// Use this for initialization
	void Start () {
		
	}
	
	void Update() {
		UpdateMovement();
		UpdateActions();
	}

	// Update is called once per frame
	void UpdateMovement () 
	{
		int x = _hor.Update();
		int y = _ver.Update();

		if(x != 0 || y != 0)
		{
			if(moveEvent != null)
				moveEvent.Invoke(new InfoEventArgs<Vector2Int>(new Vector2Int(x,y)));
		}
	}

	void UpdateActions()
	{
		for (int i = 0; i < _buttons.Length; ++i)	
		{
			if (Input.GetButtonUp(_buttons[i]))
			{
				if (actionEvent != null)
					actionEvent.Invoke(new InfoEventArgs<int>(i));
			}
		}
	}
}
