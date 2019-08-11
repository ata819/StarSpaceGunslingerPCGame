using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy2 : MonoBehaviour {

    Animator anim;

    public Transform Enemy2firePoint;
    public GameObject bulletPrefab;

    public float currCountdownValue;
    public IEnumerator StartCountdown(float countdownValue = 10){
        currCountdownValue = countdownValue;
        while(currCountdownValue >0)
        {
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }
    }


    public int health = 1;

    public GameObject deathEffect;

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
        anim.Play("Enemy1Hit");
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        //ReactionTime = 1000000;
        //Application.Quit();
        StartCoroutine(VictoryCoroutine());
        //Destroy(gameObject);
        //Destroy(deathEffect);
    }




    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, Enemy2firePoint.position, Enemy2firePoint.rotation);
        StartCoroutine(GameOverCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (currCountdownValue < 0 )
        {
            anim.Play("Enemy1Draw");
            Shoot();
            //ReactionTime = 100000;
            // anim.SetTrigger(FireHash);
        }

    }

    IEnumerator VictoryCoroutine()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(3);
    }

    IEnumerator GameOverCoroutine()
    {
        yield return new WaitForSeconds(10);
        //SceneManager.LoadScene(0);
    }
}

