using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Ninja.Controller;

namespace Ninja.Gameplay.Abilities
{
public class GameAbility : MonoBehaviour 
{
	public float duration = 1f;

	public virtual bool CanUse()
	{
		return true;
	}
	
	
	public virtual float Use()
	{
		if(!CanUse()) return 0f;

		GameObject go = GameManager.Get().playerObject;
		MovementControls2D heroMovement=go.GetComponent<MovementControls2D>();
		Vector3Int cursorPos = GameManager.Get().battleController.pos;

		heroMovement.MoveToTarget(new	Vector2Int(cursorPos.x,cursorPos.y));

		return duration;
	}
}
}