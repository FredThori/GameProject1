using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject Bullet;
    public Transform FirePoint;
    public float BulletSpeed = 50f;

    public float moveSpeed = 5f;

    public float rotationSpeed = 10f;

    public Rigidbody2D rb;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        movement.y = Input.GetAxisRaw("Vertical");


        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        FirePoint.rotation = Quaternion.Euler(0, 0, angle);

        if (Input.GetMouseButtonDown(0))
        {
            GameObject BulletClone = Instantiate(Bullet);
            BulletClone.transform.position = FirePoint.position;
            BulletClone.transform.rotation = Quaternion.Euler(0, 0, angle);

            BulletClone.GetComponent<Rigidbody2D>().velocity = FirePoint.right * BulletSpeed;

        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
