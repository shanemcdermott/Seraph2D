using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRespondsToDamage
{
	void OnDamageTaken(DamageContext context);
}