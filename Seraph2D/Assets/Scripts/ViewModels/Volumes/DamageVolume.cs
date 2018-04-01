using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageVolume : MonoBehaviour 
{
	public int damageOnEnter;
	public DamageType damageType;

	void OnTriggerEnter2D(Collider2D other)
	{
		HealthComponent healthComp = other.gameObject.GetComponent<HealthComponent> ();
		if (healthComp) 
		{
			DamageContext context = new DamageContext (gameObject, damageOnEnter);
			context.type = damageType;
			healthComp.TakeDamage (context);
		}
	}
		
}
