using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMaster : MonoBehaviour
{
    
    
    // Update is called once per frame
    void Update()
    {
        GameObject checkpoint = GameObject.Find("CheckpointMaster");
        Destroy(checkpoint);
        
    }
}
