using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public float EnemyHealth = 10;
    public float EnemyDamage;

    [SerializeField]
    private float DamageTaken;

    public GameObject Enemy;

    public Transform Target;

    void Update()
    {
        // Checking health
        if (EnemyHealth <= 0)
        {
            Destroy(gameObject);
        }

    
        RaycastHit2D hit = Physics2D.Linecast(transform.position, Target.position);
        Debug.DrawLine(transform.position, Target.position, Color.red);

        if (Physics2D.Linecast(transform.position, Target.position))
        {
            if(hit.collider.gameObject.tag == "Walls")
            {
                Debug.Log("Blocked");
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            EnemyHealth -= DamageTaken;
        }
    }
}
