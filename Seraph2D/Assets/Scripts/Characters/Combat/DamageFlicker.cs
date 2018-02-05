using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlicker : MonoBehaviour, IRespondsToDamage 
{
	public Material damagedMat;
	public float flickerTime = 0.2f;

	private Material defaultMat;

	// Use this for initialization
	void Start () 
	{
		HealthComponent healthComp = GetComponent<HealthComponent> ();
		healthComp.RegisterDamageResponder (this);
	}

	public void OnDamageTaken(DamageContext context)
	{
		SpriteRenderer sprRender = GetComponent<SpriteRenderer> ();
		if (sprRender.material != damagedMat) 
		{
			defaultMat = sprRender.material;
		}
		sprRender.material = damagedMat;
		Invoke ("RestoreMat", flickerTime);
	}

	protected void RestoreMat()
	{
		GetComponent<SpriteRenderer> ().material = defaultMat;
	}
}
