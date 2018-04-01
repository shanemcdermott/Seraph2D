using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager inst;

    public GameObject Player
    {
        get { return playerObject;}
        set
        {
            playerObject = value;
        }
    }

    public CameraManager cameraManager;


    private GameObject playerObject;
    


    private void Awake()
    {
        if(inst == null)
        {
            inst = this;
        }
        else if(inst != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    // Use this for initialization
    void Start ()
    {
        if(Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }
		if(cameraManager == null)
        {
            cameraManager = GetComponent<CameraManager>();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
