using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] private Text ButtonText;

    private Color FirstColor;
    private Outline LightOn;

    // Taking the first color of the text and the outline component in the child
    void Start()
    {
        FirstColor = ButtonText.color;

        LightOn = GetComponentInChildren<Outline>();
    }

    //Changing the color and enabeling the text outline when mouse is hovering over it
    public void OnPointerEnter(PointerEventData eventData)
    {
        ButtonText.color = new Color32(215, 5, 242, 155);
        LightOn.enabled = true;

    }

    //Changing back the color and disabeling the text outline when mouse exits the butto
    public void OnPointerExit(PointerEventData eventData)
    {
        LightOn.enabled = false;
        ButtonText.color = FirstColor;
    }



    public void StartScene()
    {
        SceneManager.LoadScene(0);
    }
}
