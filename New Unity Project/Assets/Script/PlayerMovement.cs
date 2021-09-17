using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Player bullet stats
    public GameObject Bullet;
    public Transform FirePoint;
    private float BulletSpeed = 50f;

    //Player stats
    private float moveSpeed = 10f;
    private float rotationSpeed = 20f;

    public int maxHealth = 100;
    public int currentHealth;

    public int damage = 10;
    public int BulletDamage = 10;

    public int BulletCount;
    public int BulletMax = 6;
    public int BulletCoolDown = 1;
    public float TimeBetween;
    private float TimeDiffrence;

    private float maxTime;

    [SerializeField]
    private Rigidbody2D Player;

    Vector2 movement;

    public HealthBar healthBar;

    public BulletCount bulletCount;

    private void Start()
    {
        BulletCount = BulletMax;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        bulletCount = GameObject.Find("Bullet Count").GetComponent<BulletCount>();
    }


    //Move controls and shoot script
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        movement.y = Input.GetAxisRaw("Vertical");

        //Rotaion of player towards the mouse cursor.
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        //Bullet spawner rotaion following the rotation of the player
        FirePoint.rotation = Quaternion.Euler(0, 0, angle);

        if (Time.time <= TimeBetween)
        {
            
            maxTime = TimeBetween - Time.time;

            bulletCount.Loading(maxTime);
        }

        if (Time.time >= TimeBetween)
        {

            bulletCount.NumberCount(BulletCount);

            if (BulletCount >= 1)
            {
            //Creats the bullet and shoots it with predefined speed
            if (Input.GetMouseButtonDown(0))
            {
                
                BulletCount--;

                GameObject BulletClone = Instantiate(Bullet);
                BulletClone.transform.position = FirePoint.position;
                BulletClone.transform.rotation = Quaternion.Euler(0, 0, angle);

                BulletClone.GetComponent<Rigidbody2D>().velocity = FirePoint.right * BulletSpeed;
                bulletCount.NumberCount(BulletCount);

            }
               
            }
            if (BulletCount == 0)
            {
                BulletCount += BulletMax;
                TimeBetween = Time.time + BulletCoolDown;
                
                bulletCount.SetLoading(BulletCoolDown);
            }
        }

        
    }

    //Moves the character
    void FixedUpdate()
    {
        Player.MovePosition(Player.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            currentHealth -= damage;

            healthBar.SetHealth(currentHealth);
        }

        if (collision.gameObject.tag == "Bullet")
        {
            currentHealth -= BulletDamage;
            healthBar.SetHealth(currentHealth);
        }
    }
}
