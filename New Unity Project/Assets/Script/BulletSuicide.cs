using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSuicide : MonoBehaviour
{
    //Kills the bullet if it hits anything with a box collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
