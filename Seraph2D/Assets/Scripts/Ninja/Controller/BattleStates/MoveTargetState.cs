using UnityEngine;
using System.Collections;

namespace Ninja.Controller.BattleStates
{
    public class MoveTargetState : BattleState
    {
        public override void Enter()
        {
            base.Enter();
            cameraRig.follow = tileSelectionIndicator.transform;
        }

        protected override void OnMove(InfoEventArgs<Vector2Int> e)
        {
            SelectTile(new Vector3Int(e.info.x + pos.x, pos.y + e.info.y, pos.z));
        }
        
    }
}