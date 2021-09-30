using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthKit : MonoBehaviour
{
    public Image HealthKit1;
    public Image HealthKit2;
    public Image HealthKit3;
    

    public void HealthKitCount(int Number)
    {
        if( Number == 2)
        {
            HealthKit3.enabled = false;
        }

        if (Number == 1)
        {
            HealthKit2.enabled = false;
        }

        if (Number == 0)
        {
            HealthKit1.enabled = false;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
