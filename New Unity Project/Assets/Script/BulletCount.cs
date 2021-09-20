using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletCount : MonoBehaviour
{
    public Image bullet1;
    public Image bullet2;
    public Image bullet3;
    public Image bullet4;
    public Image bullet5;
    public Image bullet6;

    public Image ReLoading;
    public Slider slider;
    public Image fill;

    //Counting the number of bullets and enables the apporpriate pictures for it.
    public void NumberCount(int bullets)
    {
        if (bullets == 5)
        {
            
            bullet6.enabled = false;
        }
        if (bullets == 4)
        {
            
            bullet5.enabled = false;
        }
        if (bullets == 3)
        {
            
            bullet4.enabled = false;
        }
        if (bullets == 2)
        {
           
            bullet3.enabled = false;
        }
        if (bullets == 1)
        {
           
            bullet2.enabled = false;
        }
        if (bullets == 0)
        {
           
            bullet1.enabled =false;

            bullet6.enabled = false;
            bullet5.enabled = false;
            bullet4.enabled = false;
            bullet3.enabled = false;
            bullet2.enabled = false;

        }
        
       
    }

    public void SetLoading(float time)
    {
        ReLoading.enabled = true;
        slider.maxValue = time;
    }


    public void Loading(float MaxTime)
    {
        slider.value = MaxTime;

        if (slider.value <= 0.001)
        {
            ReLoading.enabled = false;
            bullet6.enabled = true;
            bullet5.enabled = true;
            bullet4.enabled = true;
            bullet3.enabled = true;
            bullet2.enabled = true;
            bullet1.enabled = true;
        }
    }
   
}
