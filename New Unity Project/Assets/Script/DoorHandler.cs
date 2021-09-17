using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{

    private int UnitCount;

    private Animator DoorOpen;

    private GameObject Hitbox;

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
            DoorOpen.SetBool("DoorCanOpen", true);

        }
    }
}
