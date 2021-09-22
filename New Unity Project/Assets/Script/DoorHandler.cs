using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{

    private int UnitCount;

    private Animator DoorOpen;

    private int TEST = 1;

    // At the start it gets its own animation component
    void Start()
    {
        DoorOpen = GetComponent<Animator>();
        
    }

    //Checks the number of Enemies every frame and then opens the doors
    void Update()
    {
        //Finding the objects with the tag enemy and checks how many they are
        UnitCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        //Opens the door when it gets to zero
        if(UnitCount <= 0)
        {
            if (TEST == 1) {
                TEST++;
               
                DoorOpen.SetBool("DoorCanOpen", true);
            }
        }
        if(UnitCount > 0)
        {
            TEST = 1;
            DoorOpen.SetBool("DoorCanOpen", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            DoorOpen.SetBool("DoorCanOpen", false);

        }
    }
}
