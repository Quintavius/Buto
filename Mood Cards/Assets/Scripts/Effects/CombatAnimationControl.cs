using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAnimationControl : MonoBehaviour {
    public Animator ani;

    public SoundManager sound;

    ParticleSystem healFX;
    ParticleSystem attackFX;
    ParticleSystem hitFX;
    public ParticleSystem stackFX;
    CameraRumble cam;

    // Use this for initialization
    void Start () {
        sound = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
        healFX = transform.Find("FX_Heal").GetComponent<ParticleSystem>();
        attackFX = transform.Find("FX_Attack").GetComponent<ParticleSystem>();
        hitFX = transform.Find("FX_Hit").GetComponent<ParticleSystem>();
        //stackFX = transform.Find("FX_Stack").GetComponent<ParticleSystem>();
        cam = Camera.main.GetComponent<CameraRumble>();
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void PlayOutOfEnergy()
    {
        sound.PlaySound("OutOfEnergy");
    }

    public void PlayHeal(){
        sound.PlaySound("Heal");
        ani.SetTrigger("isHealing");
        healFX.Play();
    }

    public void PlayAttack(){
        sound.PlaySound("Attack");
        ani.SetTrigger("isAttacking");
        attackFX.Play();
    }

    public void PlayDamage(){
        StartCoroutine(DelayHit());
    }

    public void PlayStangeChange() {
        sound.PlaySound("StanceChange");
    }

    public void PlayStack(){
        sound.PlaySound("Stack");
        stackFX.Play();
        stackFX.Emit(1);
        cam.CameraShake(0.05f, 0.2f, 7);
    }

    public void PlayReload(){

    }

    public void PlayDeath(){

    }

    public void PlayWin(){

    }

    IEnumerator DelayHit()
    {
        yield return new WaitForSeconds(0.3f);
        sound.PlaySound("Hit");
        hitFX.Play();
        cam.CameraShake(0.5f, 0.75f, 15);
        ani.SetTrigger("isHit");
    }
}
