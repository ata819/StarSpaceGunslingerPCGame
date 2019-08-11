using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour {

    public float speed = 50f;
    public Rigidbody2D rb;
    public int damage = 1;

    // Use this for initialization
    void Start()
    {
        transform.Rotate(new Vector3(0, 180, 0));
        rb.velocity = transform.right * speed;
        //rb.velocity = transform.Translate(Vector2.left * speed);
    }

    private void OnTriggerExit2D(Collider2D hitInfo)
    {
        Player1 enemy = hitInfo.GetComponent<Player1>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
