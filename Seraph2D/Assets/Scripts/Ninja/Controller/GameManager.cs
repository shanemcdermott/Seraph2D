using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Ninja.Camera;

namespace Ninja.Controller
{

    public class GameManager : MonoBehaviour
    {


        protected static GameManager inst;
        public static GameManager Get()
        {
            return inst;
        }


        public CameraController cameraController
        {
            get { return battleController.cameraController; }
        }


        private GameObject playerObject;
        public BattleController battleController;


        private void Awake()
        {
            if (inst == null)
            {
                inst = this;
            }
            else if (inst != this)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }
        // Use this for initialization
        void Start()
        {
            if(battleController == null)
            {
                battleController = GetComponent<BattleController>();
            }
        }
    }
}