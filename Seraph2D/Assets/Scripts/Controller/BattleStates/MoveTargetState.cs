using UnityEngine;
using System.Collections;

public class MoveTargetState : BattleState 
{
	protected override void OnMove (InfoEventArgs<Vector2Int> e)
	{
		SelectTile(new Vector3Int(e.info.x + pos.x, pos.y + e.info.y,pos.z));
	}
}