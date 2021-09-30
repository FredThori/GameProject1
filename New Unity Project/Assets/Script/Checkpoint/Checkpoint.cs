using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 self;

    [SerializeField] private int NumberLevel;

    private CheckPointMaster checkpoint;

    Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        self = rb.position;
    }

    private void Update()
    {
        checkpoint = GameObject.Find("CheckpointMaster").GetComponent<CheckPointMaster>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.LogError("Checkpoint reached with position:" + self + " on level " + NumberLevel);
           
            checkpoint.SetTransform(self);
            checkpoint.SetLevel(NumberLevel);

            Destroy(gameObject);
        }
    }
}
