using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonC : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image circle;
    public Image icon;
    public string title;
    public MenuC myMeny;

    Color defaultColor;

    public void OnPointerEnter (PointerEventData eventData){
        myMeny.selected = this;
        defaultColor = circle.color;
        circle.color = Color.green;
    }
    public void OnPointerExit (PointerEventData eventData){
        myMeny.selected = null;
        circle.color = defaultColor;
    }
}
