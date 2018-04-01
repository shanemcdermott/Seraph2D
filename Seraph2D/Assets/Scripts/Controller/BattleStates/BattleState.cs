using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;

public abstract class BattleState : State 
{
	protected BattleController owner;
	public CameraRig cameraRig { get { return owner.cameraRig; }}
	public GameBoard board { get { return owner.board; }}
	public LevelData levelData { get { return owner.levelData; }}
	public Transform tileSelectionIndicator { get { return owner.tileSelectionIndicator; }}
	public Vector3Int pos { get { return owner.pos; } set { owner.pos = value; }}

	protected virtual void Awake ()
	{
		owner = GetComponent<BattleController>();
	}

	protected override void AddListeners ()
	{
		InputController.moveEvent.AddListener(OnMove);
		InputController.actionEvent.AddListener(OnAction);
	}
	
	protected override void RemoveListeners ()
	{
		InputController.moveEvent.RemoveListener(OnMove);
		InputController.actionEvent.RemoveListener(OnAction);
	}

	protected virtual void OnMove (InfoEventArgs<Vector2Int> e)
	{
		
	}
	
	protected virtual void OnAction (InfoEventArgs<int> e)
	{
		
	}

	protected virtual void SelectTile (Vector3Int p)
	{
		if (pos == p || !board.ContainsTileAt(p))
			return;

		pos = p;

		tileSelectionIndicator.localPosition = p; 
	}
}