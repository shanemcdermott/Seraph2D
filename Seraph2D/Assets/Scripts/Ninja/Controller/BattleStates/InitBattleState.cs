using UnityEngine;
using System.Collections;


namespace Framework.Controller.BattleStates
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
            //Could Load here
            SelectTile(new Vector3Int(0, 0, 0));
            yield return null;
            owner.ChangeState<MoveTargetState>();
        }
    }
}