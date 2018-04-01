using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerHealth : HealthComponent
{
    
    //public Slider healthSlider;
   // public Image damageImage;
    public AudioClip deathClip;

    Animator anim;
    AudioSource playerAudio;
    bool isDead;


    void Awake ()
    {
        base.ResetHealth();
        anim = GetComponent <Animator> ();
        playerAudio = GetComponent <AudioSource> ();

        //healthSlider.value = currentHealth;
    }
		
    public override void TakeDamage(DamageContext context)
    {
        if (!CanTakeDamage(context))
            return;
        base.TakeDamage(context);

        //healthSlider.value = currentHealth;
        playerAudio.Play();
    }

    public override void OnDeath(DamageContext context)
    {
        base.OnDeath(context);
        anim.SetTrigger("Die");
        playerAudio.clip = deathClip;
        playerAudio.Play();

    }

    public void RestartLevel ()
    {
        //SceneManager.LoadScene (0);
    }
}
