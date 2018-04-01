using UnityEngine;
using System.Collections;

public class BattleController : StateMachine 
{
	public CameraRig cameraRig;
	public GameBoard board;
	public LevelData levelData;
	public Transform tileSelectionIndicator;
	public Vector3Int pos;

	void Start ()
	{
		ChangeState<InitBattleState>();
	}
}