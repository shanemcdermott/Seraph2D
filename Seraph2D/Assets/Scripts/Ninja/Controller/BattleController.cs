using System.Collections;
using UnityEngine;

using Ninja.Camera;
using Ninja.Controller.BattleStates;
using Ninja.Gameplay.Abilities;

namespace Ninja.Controller
{

    public class BattleController : StateMachine
    {

        public WorldAbility testAbility;

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