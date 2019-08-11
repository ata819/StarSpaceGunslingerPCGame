using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2bulletscript : MonoBehaviour
{

    public float speed2 = 50f;
    public Rigidbody2D rb2;
    public int damage = 1;

    // Use this for initialization
    void Start()
    {
        transform.Rotate(new Vector3(0, 180, 0));
        rb2.velocity = transform.right * speed2;
        //rb.velocity = transform.Translate(Vector2.left * speed);
        transform.Rotate(new Vector3(0, 180, 0));
        rb2.velocity = transform.right * speed2;
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
