using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenClose : MonoBehaviour
{
    private int UnitCount;

    private Animator DoorOpen;

    // At the start it gets its own animation component
    void Start()
    {
        DoorOpen = GetComponent<Animator>();

    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.LogError("Working");
            DoorOpen.SetTrigger("DoorCanClose");

        }
    }
}
