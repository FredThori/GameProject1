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
        checkpoint = GameObject.Find("CheckpointMaster").GetComponent<CheckPointMaster>();

        self = rb.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //checkpoint.SetTransform(self);
            checkpoint.SetLevel(NumberLevel);
        }
    }
}
