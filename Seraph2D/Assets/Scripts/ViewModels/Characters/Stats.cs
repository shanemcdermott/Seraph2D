using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stats : MonoBehaviour 
{
	public int this[StatTypes s]
	{
		get { return _data[(int)s]; }
		set { SetValue(s, value, true); }
	}
int[] _data = new int[ (int)StatTypes.Count ];


public void SetValue (StatTypes type, int value, bool allowModifiers)
{
	int oldValue = this[type];
	if (oldValue == value)
		return;
	
	if (allowModifiers)
	{
		// Allow exceptions to the rule here
		ValueModifier exc = new ValueModifier( oldValue, value );
		
		// The notification is unique per stat type
	//	this.PostNotification(WillChangeNotification(type), exc);
		
		// Did anything modify the value?
		value = Mathf.FloorToInt(exc.GetModifiedValue());
		
		// Did something nullify the change?
		//if (exc.toggle == false || value == oldValue)
	//                                               		return;
	}
	
	_data[(int)type] = value;
	
}
}
