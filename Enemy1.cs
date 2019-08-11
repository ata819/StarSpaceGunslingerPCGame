using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy1 : MonoBehaviour {

    Animator anim;

    public Transform Enemy1firePoint;
    public GameObject bulletPrefab;

    public float ReactionTime = 5;


    public int health = 1;

    public GameObject deathEffect;

    public void TakeDamage (int damage){
        health -= damage;
        if (health <= 0) {
            Die();
        }
    }

    void Die(){
        anim.Play("Enemy1Hit");
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        ReactionTime = 1000000;
        //Application.Quit();
        StartCoroutine(VictoryCoroutine());
        //Destroy(gameObject);
        //Destroy(deathEffect);
    }




    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, Enemy1firePoint.position, Enemy1firePoint.rotation);
        StartCoroutine(GameOverCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        ReactionTime -= Time.deltaTime;
        if (ReactionTime < 0)
        {
            anim.Play("Enemy1Draw");
            Shoot();
            ReactionTime = 100000;
            //anim.Play("Enemy1Victory");
            // anim.SetTrigger(FireHash);
        }

    }

    IEnumerator VictoryCoroutine(){
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator GameOverCoroutine(){
        //anim.Play("Enemy1Victory");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(6);
    }
}
