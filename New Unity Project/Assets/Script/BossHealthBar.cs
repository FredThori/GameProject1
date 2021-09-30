using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public Slider slider;

    public Gradient Gradient;
    public Image fill;
    public Image border;
    public Text Bossname;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = Gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = Gradient.Evaluate(slider.normalizedValue);
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Boss") == true)
        {
            fill.enabled = true;
            border.enabled = true;
            Bossname.enabled = true;
        }
        else
        {
            fill.enabled = false;
            border.enabled = false;
            Bossname.enabled = false;
        }
    }
}
