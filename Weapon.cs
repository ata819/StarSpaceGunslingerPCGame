using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {


    public Transform firePoint;
    public GameObject bulletPrefab;
    public bool Wait;
    float timeLeft = 4.0f;
    public bool Stop;
    private bool isCooling = false;
    public int FireOnce = 0;
	
	// Update is called once per frame
	void Update () {
        // if (Input.GetButtonDown("Fire1") && Wait == true) {

        timeLeft -= Time.deltaTime;
        if (timeLeft > 0 && Input.GetButtonDown("Fire1"))
        {
            Stop = true;
        }
        else

        if (Input.GetButtonDown("Fire1") && Wait == true && !isCooling && FireOnce < 1 && Stop == false){
                Shoot();
            //FireOnce++;
            StartCoroutine(CoolDown());
        }
		
	}

    private IEnumerator CoolDown(){
        isCooling = true;
        yield return new WaitForSeconds(100);
        isCooling = false;
    }

    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(7);
        Wait = true;
    }

    void Shoot(){
        //StartCoroutine(Shot());

            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    }

    void Start()
    {
        StartCoroutine(WaitTime());

    }



}
