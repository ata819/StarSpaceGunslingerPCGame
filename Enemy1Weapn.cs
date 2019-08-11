using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Weapn : MonoBehaviour {

    Animator anim;

    public Transform Enemy1firePoint;
    public GameObject bulletPrefab;

    public float ReactionTime;
    private float shotCounter;


    // Update is called once per frame
    void Update()
    {
        shotCounter -= Time.deltaTime;

        if (shotCounter < 1)
        {
            Shoot();
        }

    }

    void Shoot()
    {
        anim.Play("Enemy1Draw");
        Instantiate(bulletPrefab, Enemy1firePoint.position, Enemy1firePoint.rotation);
        shotCounter = ReactionTime;
    }

    void Start()
    {

        anim = GetComponent<Animator>();

    }


}

