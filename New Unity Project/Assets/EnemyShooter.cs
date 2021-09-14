using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public float EnemyHealth = 10;
    public float EnemyDamage;

    public GameObject Bullet;
    private float BulletSpeed = 50f;

    [SerializeField]
    private float DamageTaken;

    public Transform FirePoint;

    public Transform Target;

    public LayerMask WorldLayer;

    private bool canShoot;

    Rigidbody2D rb;
    Vector2 TargetPosition;

    [SerializeField]
    private int rotationSpeed;

    private void Start()
    {
        Debug.LogWarning("Working");

        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        // Checking health
        if (EnemyHealth <= 0)
        {
            Destroy(gameObject);
        }

        
        RaycastHit2D hit = Physics2D.Linecast(transform.position, Target.position, WorldLayer);
        Debug.DrawLine(transform.position, Target.position, Color.red);

        TargetPosition = Target.position;

        Vector2 AimAtPlayer = TargetPosition - rb.position;
        float angle = Mathf.Atan2(AimAtPlayer.y, AimAtPlayer.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        FirePoint.rotation = Quaternion.Euler(0, 0, angle);


        if (Physics2D.Linecast(transform.position, Target.position, WorldLayer))
        {
            
            if (hit.collider.gameObject.tag == "Walls")
            {
                canShoot = false;
              
            }
            if(hit.collider.gameObject.tag == "Player")
            {
                

            }
        }
        
    }

    void Shoot(bool can)
    {
        while(can == true)
        {
            
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
