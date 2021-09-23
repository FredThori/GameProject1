using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Textblink : MonoBehaviour
{
    [SerializeField] private Text Text;

    private Color FirstColor;

    private int timer;

    private float timeBetweenBlink;

    [SerializeField] private float CoolDown;

    // Start is called before the first frame update
    void Start()
    {
        FirstColor = Text.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time <= timeBetweenBlink)
        {
            off();
        }
        if(Time.time >= timeBetweenBlink)
        {
            on();
        }
    }

    private void off()
    {
        Text.color = FirstColor;
    }

    private void on()
    {
        if (timer <= 100)
        {
            timer++;
            Text.color = Color.yellow;
        }

        else
        {
            timer = 0;
            timeBetweenBlink = Time.time + CoolDown;
        }
        

    }


}
