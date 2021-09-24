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
    Rigidbody2D rb;

    private Animator Animation;
    public ParticleSystem Blood;

    [SerializeField] private AudioSource DeathSound;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Animation = GetComponentInChildren<Animator>();
    }

    // Checks health
    void Update()
    {
        if (EnemyHealth <= 0)
        {
            AudioSource Death = Instantiate(DeathSound);
            ParticleSystem Bled = Instantiate(Blood);
            Bled.transform.position = rb.position;
            Death.transform.position = rb.position;
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

    //Starts the animation for attack when player gets close
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Animation.SetTrigger("Attack");
        }
    }
}
