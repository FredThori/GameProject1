using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    //Enemy settings
    public float EnemyHealth = 10;
    public float EnemyDamage;
    Rigidbody2D rb;
    public ParticleSystem Blood;

    //Bullet settings
    public GameObject Bullet;
    [SerializeField] private float BulletSpeed;
    [SerializeField]
    private float DamageTaken;
    public Transform FirePoint;
    private Transform Target;
    [SerializeField]
    private int rotationSpeed;

    //Bullet Time settings
    private bool canShoot;
    private float TimeBetweenBullet;
    [SerializeField]
    private float NSecondsBetweenBullet;

    [SerializeField] AudioSource Shoot;

    [SerializeField] AudioSource Death;

    //Targets position in vector 2 math
    Vector2 TargetPosition;

    //In layer mask for what layer the enemy can see on
    public LayerMask WorldLayer;

    private Animator Animation;


    private SpriteRenderer EnemySprite;
    private float CoolDownTimeHit;

    private void Start()
    {
        //Get the rigibody of the enemy
        rb = GetComponent<Rigidbody2D>();
        Animation = GetComponentInChildren<Animator>();

        EnemySprite = GetComponentInChildren<SpriteRenderer>();
    }


    void Update()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform; 

        // Checking health
        if (EnemyHealth <= 0)
        {
            ParticleSystem Bled = Instantiate(Blood);
            AudioSource Dead = Instantiate(Death);
            Dead.transform.position = rb.position;
            Bled.transform.position = rb.position;
            Destroy(gameObject);
            
        }

        //Creating a line towards the player that rotates the shooter towards him
        RaycastHit2D hit = Physics2D.Linecast(transform.position, Target.position, WorldLayer);
        Debug.DrawLine(transform.position, Target.position, Color.red);

        TargetPosition = Target.position;

        //Specific rotation part
        Vector2 AimAtPlayer = TargetPosition - rb.position;
        float angle = Mathf.Atan2(AimAtPlayer.y, AimAtPlayer.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        FirePoint.rotation = Quaternion.Euler(0, 0, angle);

        //Checking if it its anything
        if (Physics2D.Linecast(transform.position, Target.position, WorldLayer))
        {
            
           
            //Checking if it hits gameobject with the tag player
            if(hit.collider.gameObject.tag == "Player")
            {
                
                
                if (Time.time <= TimeBetweenBullet)
                {
                    Animation.SetTrigger("Waiting");
                }

                //Cooldown between bullets
                if (Time.time >= TimeBetweenBullet)
                {
                    Animation.ResetTrigger("Waiting");

                    //Sets the new time bettween buellts with the real time
                    TimeBetweenBullet = NSecondsBetweenBullet + Time.time;

                    Animation.SetTrigger("Shooting");

                    Shoot.Play();

                    //Creating bullet and shooting it away
                    GameObject BulletClone = Instantiate(Bullet);

                    BulletClone.transform.position = FirePoint.position;

                    BulletClone.transform.rotation = Quaternion.Euler(0, 0, angle);

                    BulletClone.GetComponent<Rigidbody2D>().velocity = FirePoint.right * BulletSpeed;

                }
            }
            if (hit.collider.gameObject.tag == "Walls")
            {
                Animation.SetTrigger("Waiting");
            }
            
        }

        if (Time.time <= CoolDownTimeHit)
        {
            EnemySprite.color = Color.red;
        }

        if (Time.time >= CoolDownTimeHit)
        {
            EnemySprite.color = Color.white;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Checks if its getting hit by a bullet and takes a bit of its health off.
        if (collision.gameObject.tag == "Bullet")
        {
            CoolDownTimeHit = Time.time + 0.2f;

            EnemyHealth -= DamageTaken;
        }
    }
}
