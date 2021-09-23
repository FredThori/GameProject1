using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] private AudioSource Door;
    private int playOnce = 0;

    public void Update()
    {

        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            Debug.LogWarning("Door");
            if(playOnce <= 2)
            {
                playOnce++;
                Door.Play();
            }
        }
        
    }
     
    
}
