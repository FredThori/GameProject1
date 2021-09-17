using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    //Number of things in the array
    public static int NumberPoints;
    
    BoxCollider2D trigger;

    public int NumberUnits;

    //Array of the transform points for the spawn points
    [SerializeField]
    Transform[] Points = new Transform[NumberPoints];

    //Array of the unit type that psawns on the spawn points
    [SerializeField]
    GameObject[] UnitType = new GameObject[NumberPoints];

    //To define its own box collider
    private void Start()
    {
        trigger = GetComponent<BoxCollider2D>();
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks if its gets collided with the player
        if (collision.gameObject.tag == "Player")
        {
            //Disables its own box so the player cannot re activate it
            trigger.enabled = false;

            NumberUnits = NumberPoints;

            //For loop to spawn enemies at thier specific points
            for (int i = 0; i < Points.Length; i++)
            {
                GameObject Enemy = Instantiate(UnitType[i], Points[i]);
                Enemy.transform.rotation = Points[i].rotation;
            }

        }
        
    }
}
