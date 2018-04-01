using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ValueChangeModifier
{

  public readonly int sortOrder;
  public ValueChangeModifier (int sortOrder)
  {
    this.sortOrder = sortOrder;
  }

  public abstract float Modify (float value);
}
