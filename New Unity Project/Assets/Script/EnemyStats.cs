using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    //Ememy stats
    public float EnemyHealth = 10;
    public float EnemyDamage;
    [SerializeField]
    private float DamageTaken;

    private Animator Animation;

    private void Start()
    {
        Animation = GetComponentInChildren<Animator>();
    }

    // Checks health
    void Update()
    {
        if (EnemyHealth <= 0)
        {
            Destroy(gameObject);
        }

        
    }

    //Checks if it collides with the bullet and takes damage
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Animation.SetTrigger("Hit");
            EnemyHealth -= DamageTaken;
            
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Animation.SetTrigger("Attack");
        }
    }
}
