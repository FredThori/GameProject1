using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public GameObject Bullet;
    public Transform FirePoint;
    private float BulletSpeed = 50f;

    private float moveSpeed = 10f;
    private float rotationSpeed = 20f;

    [SerializeField]
    private Rigidbody2D Player;

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
        Player.MovePosition(Player.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
