using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AbilityController : MonoBehaviour
{
    public WorldAbility[] abilities;
    private UnityEvent mainAbility = new UnityEvent();

    // Use this for initialization
    void Start()
    {
        mainAbility.AddListener(abilities[0].Use);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("MainAbility"))
        { 
            mainAbility.Invoke();
        }
    }
}
