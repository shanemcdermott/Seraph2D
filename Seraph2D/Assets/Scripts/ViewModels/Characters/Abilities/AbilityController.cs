using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AbilityController : MonoBehaviour
{

    const int MAX_ABILITIES = 4;

    public WorldAbility[] abilities;

    public bool IsAbilityActive
    {
        get { return bIsAbilityActive; }
        set
        {
            bIsAbilityActive = value;
        }
    }

    protected bool bIsAbilityActive = false;

    // Use this for initialization
    void Start()
    {
    }

    public void BindAbility(int index, WorldAbility ability)
    {
        abilities[index] = ability;
    }

    public bool GetAbilityUse()
    {
        WorldAbility abilityToUse = GetAbilityInput();
        if(abilityToUse != null && abilityToUse.CanUse())
        {
            float waitTime = abilityToUse.Use();
            if(waitTime > 0)
            {
                StartCoroutine(ApplyCooldown(waitTime));
            }

            return waitTime > 0f;
        }
        return false;
    }

    public WorldAbility GetAbilityInput()
    {
        if (Input.GetButtonDown("Ability1"))
        {
            return abilities[0];
        }
        else if (Input.GetButtonDown("Ability2"))
        {
            return abilities[1];
        }
        else if (Input.GetButtonDown("Ability3"))
        {
            return abilities[2];
        }
        else if (Input.GetButtonDown("Ability4"))
        {
            return abilities[3];
        }

        return null;
    }


    protected virtual IEnumerator ApplyCooldown(float waitTime)
    {
        IsAbilityActive = true;

        yield return new WaitForSeconds(waitTime);

        IsAbilityActive = false;
    }
}
