using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueModifier 
{
	  public readonly float fromValue;
  	public readonly float toValue;
  	public float delta { get { return toValue - fromValue; }}
  	List<ValueChangeModifier> modifiers;

  	public ValueModifier (float fromValue, float toValue)
  	{
    	this.fromValue = fromValue;
    	this.toValue = toValue;
  	}

	public void AddModifier (ValueChangeModifier m)
  	{
    	if (modifiers == null)
      		modifiers = new List<ValueChangeModifier>();
    	
		modifiers.Add(m);
  	}
  	public float GetModifiedValue ()
  	{
    	float value = toValue;
    	if (modifiers == null)
      		return value;
    
    	modifiers.Sort(Compare);
    	for (int i = 0; i < modifiers.Count; ++i)
      		value = modifiers[i].Modify(value);
    
    	return value;
  	}


  int Compare (ValueChangeModifier x, ValueChangeModifier y)
  {
    return x.sortOrder.CompareTo(y.sortOrder);
  }
}
