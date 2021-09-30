using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    [SerializeField] private int BossBulletDamage;

    public int BulletCount;
    public int BulletMax = 6;
    public int BulletCoolDown = 1;
    public float TimeBetween;

    private float maxTime;

    [SerializeField]
    private Rigidbody2D Player;

    Vector2 movement;

    public HealthBar healthBar;

    public BulletCount bulletCount;

    [SerializeField] private AudioSource Gun;

    [SerializeField] AudioClip Hit;

    private SpriteRenderer PlayerSprite;
    private float CoolDownTimeHit;

    private static int healthKitCount;
    private static int maxHealthKit = 3;

    [SerializeField] private int HealthGain;

    public HealthKit healthKits;

    [SerializeField] private Text checkpoint;
    private float checkpointTimer;

    [SerializeField] private Image Lights;

    [SerializeField] private AudioClip LightTurning;
    private static int sound;
    private static int sound2;

    [SerializeField] private GameObject Pause;

    private bool CanShoot;

    private void Start()
    {
        Pause.SetActive(false);

        PlayerSprite = GetComponent<SpriteRenderer>();

        CanShoot = true;

        healthKitCount = maxHealthKit;

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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CanShoot = false;
            Pause.SetActive(true);
            Time.timeScale = 0f;
        }

        if(currentHealth <= 0)
        {
            
            
            SceneManager.LoadScene(3);
            
            
        }

        if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
        {
            sound2 = 1;  
            Lights.enabled = true;

            if (sound == 1)
            {
                Gun.PlayOneShot(LightTurning);
                sound++;
            }
        }

        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            sound = 1;
            Lights.enabled = false;

            if (sound2 == 1)
            {
                Gun.PlayOneShot(LightTurning);
                sound2++;
            }
        }

        if (checkpointTimer < Time.time)
        {
            checkpoint.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
           if(healthKitCount > 0)
            {
                currentHealth += HealthGain;

                healthKitCount--;

                healthBar.SetHealth(currentHealth);

                healthKits.HealthKitCount(healthKitCount);
            }
        }

        //Sending over the time to the UI so it can set the slider of loading to be precise
        if (Time.time <= TimeBetween)
        {
            
            maxTime = TimeBetween - Time.time;

            bulletCount.Loading(maxTime);
        }

        if (Time.time >= TimeBetween)
        {

            bulletCount.NumberCount(BulletCount);

            if (BulletCount >= 1 && CanShoot == true)
            {
            //Creats the bullet and shoots it with predefined speed
            if (Input.GetMouseButtonDown(0))
            {
                
                BulletCount--;

                Gun.Play();

                GameObject BulletClone = Instantiate(Bullet);
                BulletClone.transform.position = FirePoint.position;
                BulletClone.transform.rotation = Quaternion.Euler(0, 0, angle);

                BulletClone.GetComponent<Rigidbody2D>().velocity = FirePoint.right * BulletSpeed;
                bulletCount.NumberCount(BulletCount);

            }

            //When pressing the r key it reloads and sends over the information to the UI
            if (Input.GetKeyDown("r"))
                {
                    BulletCount -= BulletCount;
                    bulletCount.NumberCount(BulletCount);
                }
               
            }

            //Checks if the player is out or not of bullets and then reloads it with cooldown and sending over the information to UI
            if (BulletCount == 0)
            {
                BulletCount += BulletMax;
                TimeBetween = Time.time + BulletCoolDown;
                
                bulletCount.SetLoading(BulletCoolDown);
            }

        }

        if (Time.time <= CoolDownTimeHit)
        {
            PlayerSprite.color = Color.red;
        }
        if (Time.time >= CoolDownTimeHit)
        {
            PlayerSprite.color = Color.white;
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
            Gun.PlayOneShot(Hit);
            currentHealth -= damage;

            CoolDownTimeHit = Time.time + 0.2f;

            healthBar.SetHealth(currentHealth);
        }

        if (collision.gameObject.tag == "Bullet")
        {
            CoolDownTimeHit = Time.time + 0.2f;

            Gun.PlayOneShot(Hit);
            currentHealth -= BulletDamage;
            healthBar.SetHealth(currentHealth);


        }
        if(collision.gameObject.tag == "BossBullet")
        {
            CoolDownTimeHit = Time.time + 0.2f;

            Gun.PlayOneShot(Hit);
            currentHealth -= BossBulletDamage;
            healthBar.SetHealth(currentHealth);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Checkpoint")
        {
            checkpointTimer = Time.time + 1f;
            checkpoint.enabled = true;
        }
    }



    public void UnpauseTime()
    {
        Pause.SetActive(false);
        Time.timeScale = 1f;
        CanShoot = true;
    }

    public void MainScreen()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
