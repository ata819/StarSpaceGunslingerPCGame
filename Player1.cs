using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1 : MonoBehaviour {

    Animator anim;
    // int FireHash = Animator.StringToHash("FireGun");

    public int health = 1;
    public GameObject deathEffect;
    public GameObject HatFall;

    //public GameObject victorSpin;
    public bool Wait = false;
    public int FireOnce = 0;


    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        anim.Play("PlayerHit");
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Instantiate(HatFall, transform.position, Quaternion.identity);

        FireOnce++;
        //Destroy(deathEffect);
    }


    // Use this for initialization
    void Start () {

        anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(WaitTime());
        //if(Input.GetKeyDown(KeyCode.Space) && Wait == true){
        if (Input.GetKeyDown(KeyCode.Space) && Wait == true && FireOnce < 1){
            anim.Play("PlayerFire");
            //anim.Play("PlayerVictory");
            //Instantiate(victorSpin, transform.position, Quaternion.identity);
     
            StartCoroutine(VictorySpin());

        }
        else if(Input.GetKeyDown(KeyCode.Space) && Wait == false)
        {
            anim.Play("PlayerMisfire");
            FireOnce++;
            Wait = false;
            //StartCoroutine(Shot());

        }


    }



    /* IEnumerator Shot()
     {
         Wait = false;
         yield return new WaitForSeconds(0);
     } */


    IEnumerator WaitTime(){
        yield return new WaitForSeconds(7);
        Wait = true;
    }

    IEnumerator VictorySpin(){
        yield return new WaitForSeconds(3);
        anim.Play("PlayerVictory");
        //Instantiate(victorSpin, transform.position, Quaternion.identity);

    }

   /* void Gunspin(){
        anim.Play("PlayerGunSpin");
    }*/

}
