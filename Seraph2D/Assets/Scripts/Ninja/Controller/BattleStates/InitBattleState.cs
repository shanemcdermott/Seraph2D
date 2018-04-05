using UnityEngine;
using System.Collections;


namespace Ninja.Controller.BattleStates
{
    public class InitBattleState : BattleState
    {
        public override void Enter()
        {
            base.Enter();
            StartCoroutine(Init());
        }

        IEnumerator Init()
        {
            if (levelData != null)
            {
                board.Load(levelData);
                Vector3Int p = levelData.tiles[0];
                SelectTile(p);
            }
            else
            {
                SelectTile(new Vector3Int(0, 0, 0));
            }
            yield return null;
            owner.ChangeState<MoveTargetState>();
        }
    }
}