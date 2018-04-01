using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalVolume : MonoBehaviour {

    public string levelName;

    void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.tag=="Player")
        {
            SceneManager.LoadScene(levelName);
        }
    }
}
