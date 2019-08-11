using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 50f;
    public Rigidbody2D rb;
    public int damage = 1;

	// Use this for initialization
	void Start () {
        rb.velocity = transform.right * speed;
        //rb.velocity = transform.Translate(Vector2.left * speed);
    }

    private void OnTriggerExit2D(Collider2D hitInfo)
    {
        Enemy1 enemy = hitInfo.GetComponent<Enemy1>();
        if(enemy != null){
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }


}
