using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HoverTextBlink : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Text ButtonText;

    [SerializeField] private Color32 HoverColor;

    [SerializeField] private Color32 On;

    private static int Hovering = 0;

    private Color FirstColor;
    private Outline LightOn;

    private float timeBetweenBlink;
    [SerializeField] private int TimeOn;
    private int timer;
    [SerializeField] private float CoolDown;

    // Taking the first color of the text and the outline component in the child
    void Start()
    {
        FirstColor = ButtonText.color;

       
    }

    void Update()
    {
        
        if (Hovering == 0)
        {
            if (Time.time <= timeBetweenBlink)
            {
                off();
            }
            if (Time.time >= timeBetweenBlink)
            {
                on();
            }
        }
       
    }

    private void off()
    {
        ButtonText.color = FirstColor;
    }

    private void on()
    {
        if (timer <= TimeOn)
        {
            timer++;
            ButtonText.color = On;
        }

        else
        {
            timer = 0;
            timeBetweenBlink = Time.time + CoolDown;
        }


    }

    //Changing the color and enabeling the text outline when mouse is hovering over it
    public void OnPointerEnter(PointerEventData eventData)
    {
        Hovering = 1;

        ButtonText.color = HoverColor;
    }

    //Changing back the color and disabeling the text outline when mouse exits the butto
    public void OnPointerExit(PointerEventData eventData)
    {
        Hovering = 0;

        ButtonText.color = FirstColor;
    }

    public void StartScene()
    {
        SceneManager.LoadScene(1);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
