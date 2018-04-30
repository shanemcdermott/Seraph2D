using System.Collections;
using UnityEngine;

using Framework.Camera;
using Framework.Controller.BattleStates;
using Framework.Gameplay.Abilities;
using Framework.Collections;

namespace Framework.Controller
{

    public class BattleController : StateMachine
    {

        public GameAbility[] abilities;

        public CameraRig cameraRig
        {
            get { return cameraController.rig; }
            set { cameraController.rig = value; }
        }

        [Header("Camera")]
        public CameraController cameraController;


        [Header("World")]
        public GameBoard board;
        public LevelData levelData;

        [Header("Controls")]
        public Transform tileSelectionIndicator;
        public Vector3Int pos;

        void Start()
        {
            ChangeState<InitBattleState>();
        }
    }
}