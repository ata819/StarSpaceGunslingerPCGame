using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour {


    Animator anim;

    public int health = 1;
    public GameObject deathEffect;
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
        anim.Play("BossHit");
        Instantiate(deathEffect, transform.position, Quaternion.identity);
    }


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
